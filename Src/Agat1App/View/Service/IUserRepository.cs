using System.Collections.Generic;
using View.Models;

namespace View.Service {
    public interface IUserRepository {
        IList<User> GetUsers();
        User Save(User user);
        User Get(int id);
    }
}