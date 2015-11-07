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
            if (ModelState.IsValid) {
                service.CreateRequest(vm);
                return RedirectToAction("Index");
            }
            else {
                return View(service.CreateRequestRenew(vm));
            }
        }

        public ActionResult Edit(int id) {
            var requestViewModel = service.UpdateRequest(id);
            return View(requestViewModel);
        }

        [HttpPost]
        public ActionResult Edit(RequestCreateViewModel vm)
        {
            var requestViewModel = service.UpdateRequest(vm);
            return View(requestViewModel);
        }

        public ActionResult Delete(int id) {
            service.DeleteRequest(id);
            return RedirectToAction("Index");
        }
    }
}