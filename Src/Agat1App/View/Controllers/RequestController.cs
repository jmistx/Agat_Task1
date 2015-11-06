using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.ViewModels;

namespace View.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {
            IList<RequestViewModel> requests = new List<RequestViewModel>();
            return View(requests);
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