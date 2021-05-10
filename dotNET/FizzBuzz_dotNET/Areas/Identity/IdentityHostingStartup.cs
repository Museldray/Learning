using System;
using FizzBuzz_dotNET.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FizzBuzz_dotNET.Areas.Identity.IdentityHostingStartup))]
namespace FizzBuzz_dotNET.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FizzbuzzDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FizzbuzzDBContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FizzbuzzDBContext>();
            });
        }
    }
}