using System;
using System.Collections.Generic;
using System.Linq;
using View.DataAccessLayer;
using View.Models;
using View.ViewModels;

namespace View.Service {
    public interface IRequestService {
        IList<RequestViewModel> GetAll();
        CreateRequestViewModel CreateRequest();
        void CreateRequest(CreateRequestViewModel vm);
    }

    public class RequestService : IRequestService {
        private readonly IRequestRepository _requestsRepository;
        private readonly IUserRepository _userRepository;

        public RequestService(IRequestRepository requestsRepository, IUserRepository userRepository) {
            this._requestsRepository = requestsRepository;
            _userRepository = userRepository;
        }

        public IList<RequestViewModel> GetAll() {
            IList<Request> requests = _requestsRepository.GetAll();
            return requests.Select(toViewModel).ToList();
        }

        public CreateRequestViewModel CreateRequest() {
            var users = _userRepository.GetUsers();

            return new CreateRequestViewModel() {
                Users = users.Select(toViewModel).ToList(),
                Author = new RequestUserViewModel()
            };
        }

        public void CreateRequest(CreateRequestViewModel vm) {
            var request = _toModel(vm);
            request.DateCreated = DateTime.UtcNow;
            _requestsRepository.Save(request);
        }

        private Request _toModel(CreateRequestViewModel vm) {
            var author = _userRepository.Get(vm.Author.Id);

            return new Request {
                Id = vm.Id,
                Author = author,
                Description = vm.Description
            };

        }

        private RequestViewModel toViewModel(Request request)
        {
            return new RequestViewModel();
        }

        private RequestUserViewModel toViewModel(User user) {
            return new RequestUserViewModel {
                Id = user.Id,
                Name = String.Format("{0} {1}", user.FirstName, user.LastName)
            };
        }
    }
}