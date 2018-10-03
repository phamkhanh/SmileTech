using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmileTech.Model.Models;

namespace SmileTech.Data
{
    public class SmileTechDbContext : IdentityDbContext<ApplicationUser>
    {
        public SmileTechDbContext() : base("SmileTechConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Error> Errors { set; get; }

        public static SmileTechDbContext Create()
        {
            return new SmileTechDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}