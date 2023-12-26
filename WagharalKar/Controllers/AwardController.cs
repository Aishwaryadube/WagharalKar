using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WagharalKar.Models;

namespace WagharalKar.Controllers
{
    public class AwardController : Controller
    {
        // GET: Award
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveAward(AwardModel model)
        {
            try
            {
                return Json(new { Message = new AwardModel().SaveAward(model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getAwardlist()
        {
            try
            {
                return Json(new { model = new AwardModel().getAwardlist() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteAward(int Id)
        {
            try
            {
                return Json(new { model = (new AwardModel().DeleteAward(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult EditAward(int Id)
        {
            try
            {
                return Json(new { model = (new AwardModel().EditAward(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}