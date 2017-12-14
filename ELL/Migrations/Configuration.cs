namespace ELL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ELL.DBContext.ELLDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true; // Data might get lost using this option
            ContextKey = "ELL.DBContext.ELLDBContext";
        }

        protected override void Seed(ELL.DBContext.ELLDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
