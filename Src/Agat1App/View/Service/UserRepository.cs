using System.Collections.Generic;
using System.Linq;
using View.DataAccessLayer;
using View.Models;

namespace View.Service {
    public class UserRepository : IUserRepository {
        private readonly IDataContextFactory _dataContextFactory;

        public UserRepository(IDataContextFactory dataContextFactory) {
            _dataContextFactory = dataContextFactory;
        }

        public IList<User> GetUsers() {
            using (var dataContext = _dataContextFactory.Create())
            {
                return dataContext.Users.ToList();    
            }
        }

        public void Save(User user) {
            using (var dataContext = _dataContextFactory.Create()) {
                if (user.Id == 0) {
                    dataContext.AddUser(user);
                }
                dataContext.SaveChanges();
            }
        }
    }
}