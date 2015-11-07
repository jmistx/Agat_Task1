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

        public Request Save(Request request)
        {
            using (var dataContext = _dataContextFactory.Create()) {
                if (request.Id == 0) {
                    return _createRequest(request, dataContext);
                }
                return _updateRequest(request, dataContext);
            }
        }

        private static Request _updateRequest(Request request, IDataContext dataContext) {
            var dbRequest = dataContext.Requests.Single(_ => _.Id == request.Id);
            var dbAuthor = dataContext.Users.Single(_ => _.Id == request.Author.Id);
            dbRequest.Author = dbAuthor;
            dbRequest.Description = request.Description;
            dataContext.SaveChanges();
            return dbRequest;
        }

        private static Request _createRequest(Request request, IDataContext dataContext) {
            dataContext.CreateRequest(request);
            dataContext.SaveChanges();
            return request;
        }

        public void Delete(int id) {
            using (var dataContext = _dataContextFactory.Create()) {
                var request = dataContext.Requests.Single(_ => _.Id == id);
                dataContext.DeleteRequest(request);
                dataContext.SaveChanges();
            }
        }

        public Request Get(int id) {
            using (var dataContext = _dataContextFactory.Create()) {
                var request = dataContext.Requests.Where(_ => _.Id == id).Include(_ => _.Author).Single();
                return request;
            }
        }
    }
}