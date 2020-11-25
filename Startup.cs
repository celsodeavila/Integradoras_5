using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CaoLendario.Models;

namespace CaoLendario
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:CaoLendario:ConnectionString"]));
            services.AddTransient<IAnimalRepositorio, EFAnimalRepositorio>();
            services.AddTransient<IAdotanteRepositorio, EFAdotanteRepositorio>();
            services.AddTransient<IInteresseRepositorio, EFInteresseRepositorio>();
            services.AddTransient<IMedicoVeterinarioRepositorio, EFMedicoVeterinarioRepositorio>();
            services.AddTransient<IProcedimentosPreAdocaoRepositorio, EFProcedimentosPreAdocaoRepositorio>();
            services.AddTransient<IProcedimentosPosAdocaoRepositorio, EFProcedimentosPosAdocaoRepositorio>();
            services.AddMvc();                        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Dashboard", action = "Index" });
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
