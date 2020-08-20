using Microsoft.AspNetCore.Hosting;


[assembly: HostingStartup(typeof(PatientScheduler.Areas.Identity.IdentityHostingStartup))]
namespace PatientScheduler.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}