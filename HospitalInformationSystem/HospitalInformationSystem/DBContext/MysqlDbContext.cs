using HospitalInformationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HospitalInformationSystem.DBContext
{
    public class MysqlDbContext : DbContext
    {
        public MysqlDbContext(DbContextOptions<MysqlDbContext> options)
      : base(options) { }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // 在此处配置连接字符串和启用重试策略
            optionsBuilder.UseMySql(new MariaDbServerVersion(new Version(8, 0, 34)),
             mySqlOptions =>
             {
                 mySqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                     errorNumbersToAdd: null);
             });


        }
    }
}
