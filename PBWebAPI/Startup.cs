using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PBShared.DBContexts;
using PBShared.Security;

namespace PBWebAPI
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;
        public Startup(IConfigurationRoot configurationRoot)
        {
            _appConfiguration = configurationRoot;
        }
        public void Configure(WebApplication app,
            IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(_appConfiguration["App:VirtualDirectory"] + "/swagger/v1/swagger.json", "PB Service V1");
            });

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("MyHeader", "GotItWorking!!!");
                    return Task.FromResult(0);
                });
                await next();
            });

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseRouting();
            //app.UseAuthorization();
            //app.MapRazorPages();
            //app.Run();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            var startupConnectionStrings = GetConnectionStrings();
            ConfigureDatabases(services, startupConnectionStrings);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PB Service API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });
        }
        private StartupConnectionString GetConnectionStrings()
        {
            return new StartupConnectionString
            {
                DecryptedCoreConnectionString = GetConnectionString(ApplicationConsts.ConnectionStringPBManageServiceDbContext)
            };
        }
        private string GetConnectionString(string connectionStringName)
        {
            return EncriptConnString.DecryptString(_appConfiguration.GetConnectionString(connectionStringName));
        }
        private void ConfigureDatabases(IServiceCollection services, StartupConnectionString connectionStrings)
        {
            services.AddDbContext<PBManageServiceContext>(options =>
                options.UseSqlServer(connectionStrings.DecryptedCoreConnectionString));
        }
    }
}
