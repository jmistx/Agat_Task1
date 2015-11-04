using System.Collections.Generic;
using System.Linq;
using View.Models;
using View.ViewModels;

namespace View.Service {
    public class UserService : IUserService {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public IList<UserViewModel> GetAllUsers() {
            IList<User> users = userRepository.GetUsers();
            return users.Select(toViewModel).ToList();
        }

        private UserViewModel toViewModel(User user) {
            return new UserViewModel {
                Address = new AddressViewModel(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id
            };
        }
    }
}