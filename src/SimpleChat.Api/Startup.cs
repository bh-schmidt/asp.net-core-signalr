using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleChat.Api.Notifiers;
using SimpleChat.Business;
using SimpleChat.Business.Notifiers;
using SimpleChat.SignalR.Hubs;

namespace SimpleChat.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddControllersAsServices();

            services.AddSignalR();

            services.AddTransient<IMessageNotifier, MessageNotifier>();
            services.AddTransient<ISendMessage, SendMessage>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureHubs(app);
            ConfigureControllers(app);
        }

        public void ConfigureHubs(IApplicationBuilder app)
        {
            app.Map("/hubs", builder =>
            {
                builder.UseCors(cors => {
                    cors.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(x => true);
                });

                builder.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                builder.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<MessageHub>("message-hub");
                });
            });
        }

        private void ConfigureControllers(IApplicationBuilder app)
        {
            app.Map("/api", builder =>
            {
                builder.UseCors(cors => {
                    cors.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                });

                builder.UseRouting();
                builder.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        }
    }
}
