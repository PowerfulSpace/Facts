using Calabonga.EntityFrameworkCore.Entities.Base;
using Microsoft.EntityFrameworkCore;
using PowerfulSpace.Facts.Web.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerfulSpace.Facts.Web.Data
{
    public class ApplicationDbContext : DbContextBase
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fact> Facts { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }

}
