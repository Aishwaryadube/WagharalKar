using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WagharalKar.Models;

namespace WagharalKar.Controllers
{
    public class VedioGalleryController : Controller
    {
        // GET: VedioGallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveVedio(VedioGalleryModel model)
        {
            try
            {
                return Json(new { Message = new VedioGalleryModel().SaveVedio(model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult getVediolist()
        {
            try
            {
                return Json(new { model= new VedioGalleryModel().getVediolist() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteVideoGallery(int Id)
        {
            try
            {
                return Json(new { model = (new VedioGalleryModel().DeleteVideoGallery(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult EditVideoGallery(int Id)
        {
            try
            {
                return Json(new { model = (new VedioGalleryModel().EditVideoGallery(Id))}, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                return Json(new {ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}