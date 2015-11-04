using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.ViewModels;

namespace View.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View(new List<UserViewModel>() {
                new UserViewModel(){FirstName = "Jhon"},
                new UserViewModel(){FirstName = "Larry"}
            });
        }

        public ActionResult Create() {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int id) {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id) {
            throw new NotImplementedException();
        }
    }
}