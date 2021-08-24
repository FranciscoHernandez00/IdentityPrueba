using System;
using IdentityPrueba.Areas.Identity.Data;
using IdentityPrueba.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentityPrueba.Areas.Identity.IdentityHostingStartup))]
namespace IdentityPrueba.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityPruebaDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityPruebaDBContextConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                })
                .AddDefaultTokenProviders().AddDefaultUI().AddEntityFrameworkStores<IdentityPruebaDBContext>();
            });
        }
    }
}