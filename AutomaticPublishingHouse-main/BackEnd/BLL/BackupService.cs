using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL
{
    public class BackupService
    {
        private readonly string _backupsPath;
        private readonly Lazy<ApplicationContext> _context;

        public BackupService(IHostEnvironment environment,
            Lazy<ApplicationContext> contex)
        {
            _backupsPath = Path.Combine(environment.ContentRootPath, "backups");
            _context = contex;
        }
        public IEnumerable<string> GetBackups()
        {
            return Directory.GetFiles(_backupsPath, "*.bak").Select(Path.GetFileName);
        }

        public void CreateBackupDatabase()
        {
            //_context.Value.Database.GetConnectionString()
            // read connectionstring from config file
            var connectionString = _context.Value.Database.GetConnectionString();

            // read backup folder from config file ("C:/temp/")
            var backupFolder = _backupsPath;

            var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

            // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")
            var backupFileName = Path.Combine(backupFolder, String.Format("{0}-{1}.bak",
                 sqlConStrBuilder.InitialCatalog,
                DateTime.Now.ToString("yyyy-MM-dd")));

            using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                    sqlConStrBuilder.InitialCatalog, backupFileName);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RestoreDatabase(string backupName)
        {
            var server = new Server("localhost");
            server.ConnectionContext.LoginSecure = true;
            server.ConnectionContext.Connect();

            var restoreDB = new Restore
            {
                Database = "PublishingHouse",
                Action = RestoreActionType.Database,
                ReplaceDatabase = true,
                NoRecovery = false
            };
            restoreDB.Devices.AddDevice(Path.Combine(_backupsPath, backupName), DeviceType.File);

            restoreDB.Information += (sender, args) => Console.WriteLine($"Information: {args.Error}");
            restoreDB.PercentComplete += (sender, args) => Console.WriteLine($"Complete: {args.Percent}. Message: {args.Message}");
            restoreDB.Complete += (sender, args) =>
            {
                Console.WriteLine($"Completed! Error: {args.Error}");
                server.ConnectionContext.Disconnect();
            };

            restoreDB.SqlRestore(server);
        }
    }
}
