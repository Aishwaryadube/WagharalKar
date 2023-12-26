using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WagharalKar.Models;

namespace WagharalKar.Controllers
{
    public class PhotoGalleryController : Controller
    {
        // GET: PhotoGallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SavePhoto(PhotoGalleryModel model)
       
        {
            try
            {

                HttpPostedFileBase fb1 = null;
                HttpPostedFileBase fb2 = null;
                for (int i = 0;i<Request.Files.Count;i++)
                {
                    fb1 = Request.Files[0];
                    fb2 = Request.Files[1];
                }
               
               
              
                return Json(new { Message = new PhotoGalleryModel().SavePhoto(fb1,fb2, model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getPhotolist(string Search)
        {
            try
            {
                return Json(new { model = new PhotoGalleryModel().getPhotolist(Search) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeletePhotoGallery(int Id)
        {
            try
            {
                return Json(new { model = (new PhotoGalleryModel().DeletePhotoGallery(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult EditPhotoGallery(int Id)
        {
            try
            {
                return Json(new { model = (new PhotoGalleryModel().EditPhotoGallery(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}