using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDM.Models;

namespace testDM.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = new DataBase();
        public ActionResult Index()
        {
            var users = db.Users.ToList<User>();

            return View(users);
        }

        public ActionResult ValidUserNick(string nick)
        {
            var users = new DataBase().Users.ToList<User>();

            var result = users.Where(r => r.NickName.StartsWith(nick)).Count() == 0;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(string name, string nick)
        {
            var user = new User();
            user.Name = name;
            user.NickName = nick;

            if (db.Users.Where(r => r.NickName.StartsWith(nick)).Count() != 0) return Json(0, JsonRequestBehavior.AllowGet);

            db.Users.Add(user);

            var result = db.SaveChanges();           

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
