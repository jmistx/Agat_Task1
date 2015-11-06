﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using View.Models;

namespace View.DataAccessLayer
{
    public class Entities : DbContext, IDataContext {
        public Entities(string connectionString):base(connectionString) {
        }

        public DbSet<User> Users { get; set; }

        IQueryable<Request> IDataContext.Requests {
            get { return Requests; }
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Request> Requests { get; set; }

        IQueryable<User> IDataContext.Users {
            get { return Users; }
        }

        void IDataContext.SaveChanges()
        {
            SaveChanges();
        }

        void IDataContext.AddUser(User user)
        {
            Users.Add(user);
        }

        void IDataContext.DeleteUser(User user)
        {
            if (user.Address != null) {
                Addresses.Remove(user.Address);    
            }
            Users.Remove(user);
        }

        void IDataContext.UpdateUser(User user)
        {
            Attach(user);
            Attach(user.Address);
        }

        private void Attach(User user)
        {
            Users.Attach(user);
            Entry(user).State = EntityState.Modified;
        }

        private void Attach(Address address)
        {
            Addresses.Attach(address);
            Entry(address).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Address>()
                .HasKey(_ => _.Id)
                .Property(_ => _.BuildingNumber).HasColumnName("BuildingNum");

            modelBuilder.Entity<Address>()
                .Property(_ => _.ApartmentNumber).HasColumnName("ApartmentNum");

            modelBuilder.Entity<User>()
                .HasKey(_ => _.Id)
                .HasOptional(_ => _.Address).WithRequired().Map(_ => _.MapKey("User")).WillCascadeOnDelete(true);

            modelBuilder.Entity<Request>()
                .HasKey(_ => _.Id)
                .Ignore(_ => _.Author)
                .Ignore(_ => _.DateCreate)
                .Ignore(_ => _.Description);
        }
    }
}