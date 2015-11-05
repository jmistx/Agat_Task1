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

        public UserViewModel Save(UserViewModel vm)
        {
            var savedUser = _userRepository.Save(toModel(vm));
            return toViewModel(savedUser);
        }

        public UserViewModel GetUser(int id) {
            return toViewModel(_userRepository.Get(id));
        }

        public void Delete(int id) {
            _userRepository.Delete(id);
        }

        private User toModel(UserViewModel vm) {
            return new User {
                Address = new Address(),
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Id = vm.Id
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