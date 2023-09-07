using JobTrackerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JobTrackerWeb.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {

        // GET: Default
        DbJobTrackingEntities _db = new DbJobTrackingEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActiveCalls()
        {
            var mail = (string)Session["Mail"];
            var id = _db.Companies.Where(x=>x.Mail ==  mail).Select(y=>y.ID).FirstOrDefault();

            var calls = _db.Call.Where(x => x.Situation == true && x.CallCompany == id).ToList();
            return View(calls);
        }

        public ActionResult PassiveCalls()
        {
            var mail = (string)Session["Mail"];
            var id = _db.Companies.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var calls = _db.Call.Where(x => x.Situation == false && x.CallCompany == id).ToList();
            return View(calls);
        }

        [HttpGet]
        public ActionResult AddCall()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCall(Call c)
        {
            var mail = (string)Session["Mail"];
            var id = _db.Companies.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();

            c.Situation = true;
            c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CallCompany = id;
            _db.Call.Add(c);
            _db.SaveChanges();
            return RedirectToAction("ActiveCalls");
        }

        public ActionResult CallDetail(int id)
        {
            var call = _db.CallDetails.Where(x => x.Call == id).ToList();
            return View(call);
        }

        [HttpGet]
        public ActionResult GetCall(int id)
        {
            var call = _db.Call.Find(id);
            return View("GetCall", call);
        }

        [HttpPost]
        public ActionResult GetCall(Call c)
        {
            var call = _db.Call.Find(c.ID);
            call.Subject = c.Subject;
            call.Description = c.Description;
            _db.SaveChanges();
            return RedirectToAction("ActiveCalls");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var call = _db.Call.Find(id);
            return View("GetCall", call);
        }

        [HttpPost]
        public ActionResult Update (Call p)
        {
            var call = _db.Call.Find(p.ID);
            call.Description = p.Description;
            call.Subject = p.Subject;
            _db.SaveChanges();
            return RedirectToAction("ActiveCalls");
        }

        [HttpGet]
        public ActionResult ProfileEdit ()
        {
            var value = (string)Session["Mail"];
            var id = _db.Companies.Where(x => x.Mail == value).Select(y => y.ID).FirstOrDefault();
            var profile = _db.Companies.Where(x=>x.ID == id).FirstOrDefault();
            return View(profile);
        }
        public ActionResult MainPage()
        {
            var mail = (string)Session["Mail"];
            var id = _db.Companies.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var totalCall = _db.Call.Where(x=>x.CallCompany == id).Count();
            ViewBag.c1 = totalCall;
           
            var activeCall = _db.Call.Where(x=>x.CallCompany== id && x.Situation== true).Count();
            ViewBag.c2 = activeCall;

            var passiveCall = _db.Call.Where(x => x.CallCompany == id && x.Situation == false).Count();
            ViewBag.c3 = activeCall;
            var companyMan = _db.Companies.Where(x=>x.ID == id).Select(y => y.Authorized).FirstOrDefault();
            ViewBag.c4 = companyMan;
            var sektor = _db.Companies.Where(x=>x.ID == id).Select(x=>x.Sektor).FirstOrDefault();
            ViewBag.c5 = sektor;
            var companyName = _db.Companies.Where(x=> x.ID == id).Select(y=>y.Name).FirstOrDefault();
            ViewBag.c6 = companyName;
            var image = _db.Companies.Where(x=>x.ID == id).Select(y=>y.Image).FirstOrDefault();
            ViewBag.c7 = image;
            return View();
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Mail"];
            var id = _db.Companies.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var messages = _db.Messages.Where(x=>x.ReceiverId == id && x.Situation==true).ToList();

            var messageCount = _db.Messages.Where(x=>x.ReceiverId == id && x.Situation==true).Count();
            ViewBag.m1 = messageCount;

            return PartialView(messages);
        }

        public PartialViewResult Partial2()
        {
            var mail = (string)Session["Mail"];
            var id = _db.Companies.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();

            var calls = _db.Call.Where(x=>x.CallCompany == id && x.Situation == true).ToList();
            var callcount = _db.Call.Where(x=> x.CallCompany == id && x.Situation == true).Count();
            ViewBag.m2 = callcount;
            return PartialView(calls);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index" , "Login");
        }

        public PartialViewResult Partial3()
        {
            return PartialView();
        }
    }
}