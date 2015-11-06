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
        public DbSet<Address> Adresses { get; set; }
        public void AddUser(User user) {
            Users.Add(user);
        }

        void IDataContext.SaveChanges()
        {
            SaveChanges();
        }

        public void DeleteUser(User user) {
            if (user.Address != null) {
                Adresses.Remove(user.Address);    
            }
            Users.Remove(user);
        }

        IQueryable<User> IDataContext.Users {
            get { return Users; }
        }

        public Entities(string connectionString):base(connectionString) {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Address>()
                .HasKey(_ => _.Id)
                .Ignore(_ => _.Street)
                .Ignore(_ => _.BuildingNumber)
                .Ignore(_ => _.ApartmentNumber);


            modelBuilder.Entity<User>()
                .HasKey(_ => _.Id)
                .HasOptional(_ => _.Address).WithRequired().Map(_ => _.MapKey("User")).WillCascadeOnDelete(true);
        }
    }
}