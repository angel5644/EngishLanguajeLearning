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

        public System.Data.Entity.DbSet<ELL.Models.Parent> Parents { get; set; }
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

    //public class DBContext
    //{
    //    public string Server
    //    {
    //        // (localdb)\V11.0
    //        get { return "localhost"; }
    //    }
    //    public string DataSource
    //    {
    //        get { return @"(localdb)\V11.0"; }
    //    }
    //    public string DatabaseName
    //    {
    //        get { return "ell"; }
    //    }
    //    public string UserId
    //    {
    //        get { return @"ANGEL-LAPTOP\Victor LG"; }
    //    }
    //    public string Password
    //    {
    //        get { return ""; }
    //    }
    //    public string ConnectionString
    //    {
    //        get
    //        {
    //            string connectionWindows = string.Format("Server={0};Database={1};Integrated Security=SSPI", this.Server, this.DatabaseName);
    //            //string connection = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", this.DataSource, this.);
    //            return connectionWindows;
    //        }
    //    }

    //    public SqlConnection GetDBConnection()
    //    {
    //        try
    //        {
    //            return new SqlConnection(this.ConnectionString);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //}
}