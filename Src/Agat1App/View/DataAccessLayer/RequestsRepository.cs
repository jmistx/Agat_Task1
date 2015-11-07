using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return dataContext.Requests.Include(_ => _.Author).ToList();
            }
        }

        public void Save(Request request) {
            using (var dataContext = _dataContextFactory.Create()) {
                dataContext.CreateRequest(request);
                dataContext.SaveChanges();
            }
        }

        public void Delete(int id) {
            using (var dataContext = _dataContextFactory.Create()) {
                var request = dataContext.Requests.Single(_ => _.Id == id);
                dataContext.DeleteRequest(request);
                dataContext.SaveChanges();
            }
        }
    }
}