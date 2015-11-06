using System;
using System.Collections.Generic;
using System.Linq;
using View.Models;

namespace View.DataAccessLayer {
    public class RequestsRepository : IRequestRepository {
        private readonly IDataContextFactory _dataContextFactory;

        public RequestsRepository(IDataContextFactory dataContextFactory) {
            _dataContextFactory = dataContextFactory;
        }

        public IList<Request> GetAll() {
            using (var dataContext = _dataContextFactory.Create()) {
                return dataContext.Requests.ToList();
            }
        }
    }
}