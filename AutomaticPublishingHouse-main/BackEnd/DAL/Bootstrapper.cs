using Autofac;
using System.Linq;
using System.Reflection;

namespace DAL
{
    public class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.Name.EndsWith("Service"))
                .AsSelf()
                .InstancePerDependency();
        }
    }
}
