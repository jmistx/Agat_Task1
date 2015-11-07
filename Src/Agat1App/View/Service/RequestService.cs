using System;
using System.Collections.Generic;
using System.Linq;
using View.DataAccessLayer;
using View.Models;
using View.ViewModels;

namespace View.Service {
    public class RequestService : IRequestService {
        private readonly IRequestRepository _requestsRepository;
        private readonly IUserRepository _userRepository;

        public RequestService(IRequestRepository requestsRepository, IUserRepository userRepository) {
            this._requestsRepository = requestsRepository;
            _userRepository = userRepository;
        }

        public IList<RequestViewModel> GetAll() {
            IList<Request> requests = _requestsRepository.GetAll();
            return requests.Select(_toViewModel).ToList();
        }

        public RequestCreateViewModel CreateRequest() {
            var users = _userRepository.GetUsers();

            return new RequestCreateViewModel() {
                Users = users.Select(_toViewModel).ToList(),
                Author = new AuthorViewModel()
            };
        }

        public void CreateRequest(RequestCreateViewModel vm) {
            var request = _toModel(vm);
            request.DateCreated = DateTime.UtcNow;
            _requestsRepository.Save(request);
        }

        public void DeleteRequest(int id) {
            _requestsRepository.Delete(id);
        }

        public RequestCreateViewModel UpdateRequest(int id)
        {
            var request = _requestsRepository.Get(id);
            return _toCreateViewModel(request);
        }

        public RequestCreateViewModel CreateRequestRenew(RequestCreateViewModel vm) {
            return _setUsersCollection(vm);
        }

        public RequestCreateViewModel UpdateRequest(RequestCreateViewModel vm)
        {
            var request = _toModel(vm);
            var savedRequest = _requestsRepository.Save(request);
            return _toCreateViewModel(savedRequest);
        }

        private RequestCreateViewModel _setUsersCollection(RequestCreateViewModel vm)
        {
            var users = _userRepository.GetUsers();
            vm.Users = users.Select(_toViewModel).ToList();
            return vm;
        }

        private Request _toModel(RequestCreateViewModel vm) {
            var author = _userRepository.Get(vm.Author.Id);

            return new Request {
                Id = vm.Id,
                Author = author,
                Description = vm.Description
            };
        }

        private RequestCreateViewModel _toCreateViewModel(Request request)
        {
            var requestUpdateViewModel = new RequestCreateViewModel
            {
                Id = request.Id,
                Author = _toViewModel(request.Author),
                DateCreated = request.DateCreated.ToString("g"),
                Description = request.Description,
            };
            _setUsersCollection(requestUpdateViewModel);
            return requestUpdateViewModel;
        }

        private RequestViewModel _toViewModel(Request request)
        {
            return new RequestViewModel {
                Id = request.Id,
                Author = _toViewModel(request.Author),
                DateCreated = request.DateCreated.ToString("g")
            };
        }

        private AuthorViewModel _toViewModel(User user)
        {
            return new AuthorViewModel
            {
                Id = user.Id,
                Name = String.Format("{0} {1}", user.FirstName, user.LastName)
            };
        }
    }
}