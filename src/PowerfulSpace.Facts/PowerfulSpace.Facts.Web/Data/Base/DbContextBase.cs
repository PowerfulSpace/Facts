using Calabonga.EntityFrameworkCore.Entities.Base;
using Calabonga.UnitOfWork;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PowerfulSpace.Facts.Web.Data.Base
{
    public abstract class DbContextBase : IdentityDbContext
    {

        public SaveChangesResult SaveChangesResult { get; set; }


        protected DbContextBase(DbContextOptions options)
           : base(options)
        {
            SaveChangesResult = new SaveChangesResult();
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);
            base.OnModelCreating(builder);
        }



        private void DbSaveChanges()
        {
            const string defaultUser = "System";
            var defaultDate = DateTime.UtcNow;

            var addEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);


            foreach (var entry in addEntities)
            {

                if (entry.Entity is not IAuditable) { return; }

                var createdAt = entry.Property(nameof(IAuditable.CreatedAt)).CurrentValue;
                var createdBy = entry.Property(nameof(IAuditable.CreatedBy)).CurrentValue;

                var updatedAt = entry.Property(nameof(IAuditable.UpdatedAt)).CurrentValue;
                var updatedBy = entry.Property(nameof(IAuditable.UpdatedBy)).CurrentValue;



                if (string.IsNullOrEmpty(createdBy.ToString()))
                    entry.Property(nameof(IAuditable.CreatedBy)).CurrentValue = defaultUser;

                if (string.IsNullOrEmpty(updatedBy.ToString()))
                    entry.Property(nameof(IAuditable.UpdatedBy)).CurrentValue = defaultUser;


                if (DateTime.Parse(createdAt.ToString()!).Year < 1970)
                    entry.Property(nameof(IAuditable.CreatedAt)).CurrentValue = defaultDate;

                if (updatedAt != null && DateTime.Parse(updatedAt.ToString()!).Year < 1970)
                    entry.Property(nameof(IAuditable.UpdatedAt)).CurrentValue = defaultDate;


                SaveChangesResult.AddMessage("Some entities were created");
            }




            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in modifiedEntities)
            {
                if(entry.Entity is IAuditable)
                {
                    var userName = entry.Property(nameof(IAuditable.UpdatedBy)).CurrentValue == null
                        ? defaultUser
                        : entry.Property(nameof(IAuditable.UpdatedBy)).CurrentValue;

                    entry.Property(nameof(IAuditable.UpdatedAt)).CurrentValue = DateTime.UtcNow;
                    entry.Property(nameof(IAuditable.UpdatedBy)).CurrentValue = userName;
                }
            }


        }
    }

}
