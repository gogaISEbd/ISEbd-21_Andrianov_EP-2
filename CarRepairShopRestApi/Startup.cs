using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CarRepairShopDatabaseImplement.Implements;
using CarRepairShopBusinessLogic.BusinessLogics;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopBusinessLogic.MailWorker;
using CarRepairShopBusinessLogic.MailWorker.Implements;
using System;
using CarRepairShopContracts.BindingModels;


namespace CarRepairShopRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IRepairStorage, RepairStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IRepairLogic, RepairLogic>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();
            services.AddSingleton<RepairMailWorker, MailKitWorker>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRepairShopRestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRepairShopRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var mailSender = app.ApplicationServices.GetService<RepairMailWorker>();
            mailSender.MailConfig(new MailConfigBindingModel
            {
                MailLogin = Configuration?["MailLogin"]?.ToString(),
                MailPassword = Configuration?["MailPassword"]?.ToString(),
                SmtpClientHost = Configuration?["SmtpClientHost"]?.ToString(),
                SmtpClientPort = Convert.ToInt32(Configuration?["SmtpClientPort"]?.ToString()),
                PopHost = Configuration?["PopHost"]?.ToString(),
                PopPort = Convert.ToInt32(Configuration?["PopPort"]?.ToString())
            });
        }
    }
}
