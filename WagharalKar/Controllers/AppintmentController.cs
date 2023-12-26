using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WagharalKar.Models;
namespace WagharalKar.Controllers
{
    public class AppintmentController : Controller
    {
        // GET: Appintment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveAppointment(AppointmentModel model)
         
        {
            try
            {
                return Json(new { Message = new AppointmentModel().SaveAppointment(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {ex.Message},JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getAppointmentlist()
        {
            try
            {
                return Json(new { model = new AppointmentModel().getAppointmentlist() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteAppointment(int Id)
        {
            try
            {
                return Json(new { model = (new AppointmentModel().DeleteAppointment(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult EditAppointment(int Id)
        {
            try
            {
                return Json(new { model = (new AppointmentModel().EditAppointment(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}