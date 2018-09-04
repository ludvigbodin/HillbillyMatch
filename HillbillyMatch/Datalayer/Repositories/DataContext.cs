using Datalayer.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;

namespace Datalayer.Repositories
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Posts)
            //    .WithRequired(x => x.Reciever);

           base.OnModelCreating(modelBuilder);

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Request> Requests { get; set; }
    }
}
