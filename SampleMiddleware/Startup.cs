using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SampleMiddleware.Middlewares;

namespace SampleMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseAuthMiddleware();
            app.UseExceptionHandlerMiddleware();

            //app.Use((context, next) =>
            //{
            //    // Call the next delegate/middleware in the pipeline
            //    return next();
            //});

            //app.Map("/test", (appBuilder) =>
            //{
            //    appBuilder.Map("/test11", builder =>
            //    {
            //        appBuilder.Run(async (context) =>
            //        {
            //            await context.Response.WriteAsync("Hello 123");
            //        });
            //    });
            //});

            //app.Map("/test1", (appBuilder) =>
            //{
            //    appBuilder.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Hello ");
            //    });
            //});

            //app.MapWhen(context => context.Request.Path.Value.Contains("hello"), builder =>
            //{
            //    builder.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("hello world");
            //    });
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
