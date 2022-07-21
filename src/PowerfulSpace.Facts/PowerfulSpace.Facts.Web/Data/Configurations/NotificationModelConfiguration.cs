using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Data.Configurations
{
    public class NotificationModelConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.UpdatedBy).HasMaxLength(50);

            builder.Property(x => x.Subject).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(3000);
            builder.Property(x => x.AddAdressFrom).IsRequired().HasMaxLength(128);
            builder.Property(x => x.AddAdressTo).IsRequired().HasMaxLength(128);
            builder.Property(x => x.IsCompleted);

            builder.HasIndex(x => x.AddAdressFrom);
            builder.HasIndex(x => x.AddAdressTo);
            builder.HasIndex(x => x.Content);
            builder.HasIndex(x => x.Subject);

        }
    }
}
