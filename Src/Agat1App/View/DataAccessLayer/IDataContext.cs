﻿using System;
using System.Linq;
using View.Models;

namespace View.DataAccessLayer {
    public interface IDataContext : IDisposable {
        IQueryable<User> Users { get; }
        void AddUser(User user);
        void SaveChanges();
    }
}