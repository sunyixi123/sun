using HospitalInformationSystem.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using AutoMapper;

namespace HospitalInformationSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    // 记录异常信息到日志
                    var logger = context.RequestServices.GetRequiredService<ILogger<Startup>>();
                    logger.LogError($"An unhandled exception occurred: {exception}");

                    // 返回适当的响应给客户端
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("An error occurred. Please try again later.");
                });
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MysqlDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection"),
                    new MariaDbServerVersion(new Version(8, 0, 34)));
                options.EnableSensitiveDataLogging(); // 启用敏感数据日志
            });
            // 添加 AutoMapper 的配置
            services.AddAutoMapper(typeof(Startup));

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
