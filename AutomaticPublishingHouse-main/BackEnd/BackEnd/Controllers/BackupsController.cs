using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/backups")]
    [ApiController]
    public class BackupsController : ControllerBase
    {
        private readonly BackupService _adminService;

        public BackupsController(BackupService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetBackups()
        {
            return Ok(_adminService.GetBackups());
        }

        [HttpPost]
        public IActionResult Backup()
        {
            _adminService.CreateBackupDatabase();

            return Ok();
        }

        [HttpPost("restore/{backupName}")]
        public IActionResult Restore(string backupName)
        {
            _adminService.RestoreDatabase(backupName);

            return Ok();
        }
    }
}
