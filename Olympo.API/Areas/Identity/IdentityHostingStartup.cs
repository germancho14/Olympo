using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Hosting;
using Olympo.API.Identity;

[assembly: HostingStartup(typeof(Olympo.API.Areas.Identity.IdentityHostingStartup))]
namespace Olympo.API.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                // At the ConfigureServices section in Startup.cs
                services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(identity =>
                    {
                        identity.Password.RequiredLength = 8;
                        // other options
                    },
                    mongo =>
                    {
                        mongo.ConnectionString = "mongodb+srv://olympo:g7Hya2523@cluster0.wbxv4.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
                        // other options
                    });

            });
            
            // builder.ConfigureServices((context, services) => {
            //     services.AddDbContext<IdentityDataContext>(options =>
            //         options.UseSqlServer(
            //             context.Configuration.GetConnectionString("IdentityDataContextConnection")));

            //     services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //         .AddEntityFrameworkStores<IdentityDataContext>();
            //});
        }
    }
}