using System;
using System.Collections.Generic;
using System.Linq;
using View.Models;
using View.ViewModels;

namespace View.Service {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public IList<UserViewModel> GetAllUsers() {
            var users = _userRepository.GetUsers();
            return users.Select(toViewModel).ToList();
        }

        public void Save(UserViewModel vm) {
            var user = toModel(vm);
            _userRepository.Save(user);
        }

        public UserViewModel GetUser(int id) {
            return toViewModel(_userRepository.Get(id));
        }

        private User toModel(UserViewModel vm) {
            return new User {
                Address = new Address(),
                FirstName = vm.FirstName,
                LastName = vm.LastName
            };
        }

        private UserViewModel toViewModel(User user) {
            if (user == null) {
                throw new NullReferenceException();
            }

            return new UserViewModel {
                Address = new AddressViewModel(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id
            };
        }
    }
}