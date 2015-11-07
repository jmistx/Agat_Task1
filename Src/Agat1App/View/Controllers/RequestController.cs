using System;
using System.Web.Mvc;
using View.DataAccessLayer;
using View.Service;
using View.ViewModels;

namespace View.Controllers {
    public class RequestController : Controller {
        private readonly IRequestService service;

        public RequestController() {
            var dataContextFactory = new DataContextFactory();
            service = new RequestService(new RequestsRepository(dataContextFactory), new UserRepository(dataContextFactory));
        }

        public ActionResult Index() {
            return View(service.GetAll());
        }

        public ActionResult Create() {
            var requestViewModel = service.CreateRequest();
            return View(requestViewModel);
        }

        [HttpPost]
        public ActionResult Create(RequestCreateViewModel vm) {
            service.CreateRequest(vm);  
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id) {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id) {
            throw new NotImplementedException();
        }
    }
}