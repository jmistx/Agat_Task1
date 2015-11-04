using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.DataAccessLayer;
using View.Service;
using View.ViewModels;

namespace View.Controllers
{
    public class UserController : Controller
    {
        public UserController() {
            UserService = new UserService(new UserRepository(new DataContextFactory()));
        }

        public ActionResult Index() {
            var users = UserService.GetAllUsers();
            return View(users);
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

        public IUserService UserService;
    }
}