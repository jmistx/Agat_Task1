using System;
using System.Linq;
using View.Models;

namespace View.DataAccessLayer {
    public interface IDataContext : IDisposable {
        IQueryable<User> Users { get; }
        IQueryable<Request> Requests { get; }
        void AddUser(User user);
        void SaveChanges();
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}