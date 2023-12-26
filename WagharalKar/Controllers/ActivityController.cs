using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WagharalKar.Models;

namespace WagharalKar.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveReg(ActivityModel model)
        {
            try
            {
                return Json(new { Message = new ActivityModel().SaveReg(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {ex.Message},JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult getActivitylist(string Search)
        {
            try
            {
                return Json(new { model = new ActivityModel().getActivitylist(Search) }, JsonRequestBehavior.AllowGet); 

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteActivity(int Id)
        {
            try
            {
                return Json(new { model = (new ActivityModel().DeleteActivity(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult EditActivity(int Id)
        {
            try
            {
                return Json(new { model = (new ActivityModel().EditActivity(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
   
}