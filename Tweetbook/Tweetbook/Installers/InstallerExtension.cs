using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tweetbook.Installers
{
    public static class InstallerExtension
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(c =>
                typeof(IInstaller).IsAssignableFrom(c) && (!c.IsAbstract) && (!c.IsInterface)).Select(
                Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer =>
            {
                installer.InstallServices(services, configuration);
            });
        }
        
    }
}