using JobTrackerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JobTrackerWeb.Controllers
{
    public class LoginController : Controller
    {
        DbJobTrackingEntities _db = new DbJobTrackingEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Companies c)
        {
            var values = _db.Companies.FirstOrDefault(x => x.Mail == c.Mail && x.Password == c.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Mail, false);
                Session["Mail"] = values.Mail.ToString();
                return RedirectToAction("ActiveCalls","Default");

            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}