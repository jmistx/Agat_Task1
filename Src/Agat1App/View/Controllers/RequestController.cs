using System;
using System.Web.Mvc;
using View.DataAccessLayer;
using View.Service;
using View.ViewModels;

namespace View.Controllers {
    public class RequestController : Controller {
        private readonly IRequestService service;

        public RequestController() {
            service = new RequestService(new RequestsRepository(new DataContextFactory()));
        }
        public ActionResult Index() {
            return View(service.GetAll());
        }

        public ActionResult Create() {
            throw new NotImplementedException();
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