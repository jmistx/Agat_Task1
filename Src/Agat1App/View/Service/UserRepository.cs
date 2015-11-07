using System.Collections.Generic;
using System.Data.Entity;
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
                return dataContext.Users.Include(_ => _.Address).ToList();    
            }
        }

        public User Save(User user) {
            using (var dataContext = _dataContextFactory.Create()) {
                if (user.Id == 0) {
                    dataContext.AddUser(user);
                }
                else {
                    dataContext.UpdateUser(user);
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
                var requests = user.Requests.ToList();

                foreach (var request in requests)
                {
                    dataContext.DeleteRequest(request);
                }

                dataContext.DeleteUser(user);
                dataContext.SaveChanges();
            }
        }

        private static User Get(IDataContext dataContext, int id) {
            return dataContext.Users.Where(_ => _.Id == id).Include(_ => _.Address).Single();
        }
    }
}