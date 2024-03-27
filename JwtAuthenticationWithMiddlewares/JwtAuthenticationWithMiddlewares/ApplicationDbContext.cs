using JwtAuthenticationWithMiddlewares.Models;
using Microsoft.EntityFrameworkCore;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;

namespace JwtAuthenticationWithMiddlewares
{  
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }

        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<StoryModel> Story { get; set; }

        public virtual DbSet<LoginDetailModel> LoginDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GlobalAttributes.mysqlConfiguration.connectionString, ServerVersion.AutoDetect(GlobalAttributes.mysqlConfiguration.connectionString));
            }
        }

    }
}
