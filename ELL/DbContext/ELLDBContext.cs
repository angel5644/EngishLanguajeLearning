using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ELL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ELL.DBContext
{
    public class ELLDBContext : IdentityDbContext<ApplicationUser>
    {
        public ELLDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ELLDBContext Create()
        {
            return new ELLDBContext();
        }

        public System.Data.Entity.DbSet<ELL.Models.EmergencyContact> EmergencyContacts { get; set; }
        public System.Data.Entity.DbSet<ELL.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<ELL.Models.Payment> Payments { get; set; }

        public override int SaveChanges()
        {
            AddTrackingInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTrackingInfo();
            return await base.SaveChangesAsync();
        }

        private void AddTrackingInfo()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name) ? HttpContext.Current.User.Identity.Name : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).UserCreated = currentUsername;
                }

                ((BaseEntity)entity.Entity).DateUpdated = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).UserUpdated = currentUsername;
            }
        }
    }
}