using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using View.Models;

namespace View.DataAccessLayer
{
    public class Entities : DbContext, IDataContext {
        public DbSet<User> Users { get; set; }

        IQueryable<User> IDataContext.Users {
            get { return Users; }
        }

        public Entities(string connectionString):base(connectionString) {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>()
                .HasKey(_ => _.Id)
                .Ignore(_ => _.Address);
        }
    }
}