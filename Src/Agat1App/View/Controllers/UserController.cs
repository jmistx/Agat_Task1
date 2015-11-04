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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel vm) {
            UserService.Save(vm);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) {
            var user = UserService.GetUser(id);
            return View(user);
        }

        public ActionResult Delete(int id) {
            throw new NotImplementedException();
        }

        public IUserService UserService;
    }
}