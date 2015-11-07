using System.Collections.Generic;
using View.ViewModels;

namespace View.Service {
    public interface IRequestService {
        IList<RequestViewModel> GetAll();
        RequestCreateViewModel CreateRequest();
        void CreateRequest(RequestCreateViewModel vm);
        void DeleteRequest(int id);
        RequestCreateViewModel UpdateRequest(int id);
        RequestCreateViewModel CreateRequestRenew(RequestCreateViewModel vm);
        RequestCreateViewModel UpdateRequest(RequestCreateViewModel vm);
    }
}