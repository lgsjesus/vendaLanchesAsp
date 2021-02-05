using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Context;
using vendaLanchesAsp.Models;
using vendaLanchesAsp.Repositories;

namespace vendaLanchesAsp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             *    var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
             */

            if (Configuration["BancoDados"].Equals("SqlServer"))
            {
                services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            }

            //Transient o objeto vai ser criado toda x que for requisitado
            services.AddTransient<ICategorias, CategoriaRepository>();
            services.AddTransient<ILanches, LancheRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            //Singleton todos os controllers recebem a mesma instancia
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //quer dizer que cada requisição tem sua instancia, se 2 pessoas pedem o carrinho
            // ao mesmo tempo cada uma pega a sua
            services.AddScoped(cp => CarrinhoCompra.GetCarrinho(cp));
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSession();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/StaticFiles"
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "categoriaFiltro",
                   pattern: "lanches/{action}/{categoria?}",
                   defaults: new { Controller = "Lanches", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
