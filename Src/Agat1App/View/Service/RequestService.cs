using System.Collections.Generic;
using System.Linq;
using View.DataAccessLayer;
using View.Models;
using View.ViewModels;

namespace View.Service {
    public interface IRequestService {
        IList<RequestViewModel> GetAll();
    }

    public class RequestService : IRequestService {
        private readonly IRequestRepository _requestsRepository;

        public RequestService(IRequestRepository requestsRepository) {
            this._requestsRepository = requestsRepository;
        }

        public IList<RequestViewModel> GetAll() {
            IList<Request> requests = _requestsRepository.GetAll();
            return requests.Select(toViewModel).ToList();
        }

        private RequestViewModel toViewModel(Request request)
        {
            return new RequestViewModel();
        }
    }
}