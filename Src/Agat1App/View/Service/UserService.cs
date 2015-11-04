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

        public void Save(UserViewModel vm) {
            var user = toModel(vm);
            userRepository.Save(user);
        }

        private User toModel(UserViewModel vm) {
            return new User {
                Address = new Address(),
                FirstName = vm.FirstName,
                LastName = vm.LastName
            };
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