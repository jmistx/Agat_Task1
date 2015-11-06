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
            
            var address = new Address();
            if (vm.Address != null) {
                address.Id = vm.Address.Id;
                address.City = vm.Address.City;
                address.Street = vm.Address.Street;
                address.BuildingNumber = vm.Address.BuildingNumber;
                address.ApartmentNumber = vm.Address.ApartmentNumber;
            }

            return new User {
                Address = address,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Id = vm.Id
            };
        }

        private UserViewModel toViewModel(User user) {
            if (user == null) {
                throw new NullReferenceException();
            }

            var address = new AddressViewModel();

            if (user.Address != null) {
                address.Id = user.Address.Id;
                address.City = user.Address.City;
                address.Street = user.Address.Street;
                address.BuildingNumber = user.Address.BuildingNumber;
                address.ApartmentNumber = user.Address.ApartmentNumber;
            }

            return new UserViewModel {
                Address = address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id
            };
        }
    }
}