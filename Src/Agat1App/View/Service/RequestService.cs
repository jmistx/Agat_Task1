﻿using System;
using System.Collections.Generic;
using System.Linq;
using View.DataAccessLayer;
using View.Models;
using View.ViewModels;

namespace View.Service {
    public interface IRequestService {
        IList<RequestViewModel> GetAll();
        RequestCreateViewModel CreateRequest();
        void CreateRequest(RequestCreateViewModel vm);
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

        public RequestCreateViewModel CreateRequest() {
            var users = _userRepository.GetUsers();

            return new RequestCreateViewModel() {
                Users = users.Select(toViewModel).ToList(),
                Author = new AuthorViewModel()
            };
        }

        public void CreateRequest(RequestCreateViewModel vm) {
            var request = _toModel(vm);
            request.DateCreated = DateTime.UtcNow;
            _requestsRepository.Save(request);
        }

        private Request _toModel(RequestCreateViewModel vm) {
            var author = _userRepository.Get(vm.Author.Id);

            return new Request {
                Id = vm.Id,
                Author = author,
                Description = vm.Description
            };

        }

        private RequestViewModel toViewModel(Request request)
        {
            return new RequestViewModel {
                Author = toViewModel(request.Author),
                DateCreated = request.DateCreated.ToString("g")
            };
        }

        private AuthorViewModel toViewModel(User user)
        {
            return new AuthorViewModel
            {
                Id = user.Id,
                Name = String.Format("{0} {1}", user.FirstName, user.LastName)
            };
        }
    }
}