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

        public User Save(User user) {
            using (var dataContext = _dataContextFactory.Create()) {
                if (user.Id == 0) {
                    dataContext.AddUser(user);
                }
                else {
                    var dbUser = Get(dataContext,user.Id);
                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                }
                dataContext.SaveChanges();
                return user;
            }
        }

        public User Get(int id) {
            using (var dataContext = _dataContextFactory.Create()) {
                return Get(dataContext, id);
            }
        }

        public void Delete(int id) {
            using (var dataContext = _dataContextFactory.Create()) {
                var user = Get(dataContext, id);
                dataContext.DeleteUser(user);
                dataContext.SaveChanges();
            }
        }

        private static User Get(IDataContext dataContext, int id) {
            return dataContext.Users.Single(_ => _.Id == id);
        }
    }
}