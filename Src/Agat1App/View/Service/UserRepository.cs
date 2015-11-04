using System.Collections.Generic;
using View.Models;

namespace View.Service {
    public class UserRepository : IUserRepository {
        public IList<User> GetUsers() {
            var users = new List<User> {
                new User {FirstName = "Jhon"},
                new User {FirstName = "Larry"}
            };
            return users;
        }
    }
}