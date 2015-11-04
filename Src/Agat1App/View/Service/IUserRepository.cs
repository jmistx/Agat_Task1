using System.Collections.Generic;
using View.Models;

namespace View.Service {
    public interface IUserRepository {
        IList<User> GetUsers();
        void Save(User user);
    }
}