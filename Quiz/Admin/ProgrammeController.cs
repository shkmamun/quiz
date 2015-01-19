using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Admin
{
    public class ProgrammeController : Controller
    {
        //
        // GET: /Programme/
        public ActionResult Index()
        {          
            DBGateway db = new DBGateway();
            IList<Programme> model = db.GetAllProgramme(0);
            return this.RazorView(model);
            //return View();
        }
        public ActionResult Create()
        {
            return this.RazorView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Programme model)
        {
            if (ModelState.IsValid)
            {
                var pro = new Programme() { ProgrammeName = model.ProgrammeName, StartDate = model.StartDate, EndDate = model.EndDate, NumOfQuestion = model.NumOfQuestion,
                                            TimeLimit = model.TimeLimit,IsHourly = model.IsHourly, IsActive=model.IsActive};

                DBGateway db = new DBGateway();
               int result = db.InsertProgramme(pro);

               if (result > 0)
               {
                   return RedirectToAction("Index", "Programme");
               }
               else
               {
                   ModelState.AddModelError("db", "Programme already exist with the same date.");
               }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
    public static class ControllerExtensions
    {
        public static ViewResult RazorView(this Controller controller)
        {
            return RazorView(controller, null, null);
        }

        public static ViewResult RazorView(this Controller controller, object model)
        {
            return RazorView(controller, null, model);
        }

        public static ViewResult RazorView(this Controller controller, string viewName)
        {
            return RazorView(controller, viewName, null);
        }

        public static ViewResult RazorView(this Controller controller, string viewName, object model)
        {
            if (model != null)
                controller.ViewData.Model = model;

            controller.ViewBag._ViewName = GetViewName(controller, viewName);

            return new ViewResult
            {
                ViewName = "RazorView",
                ViewData = controller.ViewData,
                TempData = controller.TempData
            };
        }

        static string GetViewName(Controller controller, string viewName)
        {
            return !string.IsNullOrEmpty(viewName)
                ? viewName
                : controller.RouteData.GetRequiredString("action");
        }
    }
}