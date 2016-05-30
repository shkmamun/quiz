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
        [HttpPost]
        public ActionResult Index(FormCollection coll)
        {
            string programmeName = coll["ProgrammeName"];
            DateTime startDate= new DateTime();
            if (!String.IsNullOrWhiteSpace(coll["StartDate"]))
            {
                startDate = Convert.ToDateTime(coll["StartDate"]);
            }
            DateTime endDate = new DateTime();
            if (!String.IsNullOrWhiteSpace(coll["EndDate"]))
            {
                 endDate = Convert.ToDateTime(coll["EndDate"]);
            }
            bool isActive = Convert.ToBoolean(coll["IsActive"]);
            bool isHourly = Convert.ToBoolean(coll["IsHourly"]);

            DBGateway db = new DBGateway();
            IList<Programme> model = db.GetAllProgramme(0);

            if (!String.IsNullOrWhiteSpace(programmeName))
            {
                model = model.Where(m => m.ProgrammeName.Contains(programmeName)).ToList();
            }
            if (!String.IsNullOrWhiteSpace(coll["StartDate"]))
            {
                model = model.Where(m => m.StartDate >= startDate).ToList();
            }
            if (!String.IsNullOrWhiteSpace(coll["EndDate"]))
            {
                model = model.Where(m => m.EndDate <= endDate).ToList();
            }
            if (!String.IsNullOrWhiteSpace(coll["IsActive"]))
            {
                model = model.Where(m => m.IsActive==isActive).ToList();
            }
            if (!String.IsNullOrWhiteSpace(coll["IsHourly"]))
            {
                model = model.Where(m => m.IsHourly == isHourly).ToList();
            }
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
        public ActionResult Edit(int Id)
        {
            DBGateway db = new DBGateway();
            Programme model = db.GetAllProgramme(Id).FirstOrDefault();

            return this.RazorView(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Programme model)
        {
            if (ModelState.IsValid)
            {
                var pro = new Programme()
                {
                    ProgrammeId = model.ProgrammeId,
                    ProgrammeName = model.ProgrammeName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    NumOfQuestion = model.NumOfQuestion,
                    TimeLimit = model.TimeLimit,
                    IsHourly = model.IsHourly,
                    IsActive = model.IsActive
                };

                DBGateway db = new DBGateway();
                int result = db.UpdateProgramme(pro);

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