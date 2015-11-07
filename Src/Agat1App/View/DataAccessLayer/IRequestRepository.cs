using System.Collections.Generic;
using View.Models;

namespace View.DataAccessLayer {
    public interface IRequestRepository {
        IList<Request> GetAll();
        void Save(Request request);
    }
}