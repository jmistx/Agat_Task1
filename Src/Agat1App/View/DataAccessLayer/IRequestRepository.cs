using System.Collections.Generic;
using View.Models;

namespace View.DataAccessLayer {
    public interface IRequestRepository {
        IList<Request> GetAll();
        Request Save(Request request);
        void Delete(int id);
        Request Get(int id);
    }
}