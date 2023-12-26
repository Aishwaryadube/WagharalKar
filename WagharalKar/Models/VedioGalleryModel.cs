using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc.Razor;
using Wagharalkar.Data;

namespace WagharalKar.Models
{
    public class VedioGalleryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string YouTubeUrl { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }

        public string SaveVedio(VedioGalleryModel model)
        {
            string msg = "Save Successfully";
            WagharalkarEntities db = new WagharalkarEntities();

            if (model.Id == 0)
            {
                var savevedio = new tblVideoGallery()

                {
                    Id = model.Id,
                    Title = model.Title,
                    YouTubeUrl = model.YouTubeUrl,
                    Type = model.Type,
                    CreateDate = model.CreateDate,
                    UpdateDate = model.UpdateDate,
                    CreatedBy = model.CreatedBy,
                    UpdatedBy = model.UpdatedBy
                };
                db.tblVideoGalleries.Add(savevedio);
                db.SaveChanges();
            }
            else
            {
                var data = db.tblVideoGalleries.Where(p => p.Id == model.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Id = model.Id;
                    data.Title = model.Title;
                    data.YouTubeUrl = model.YouTubeUrl;
                    data.Type = model.Type;
                    data.CreateDate = model.CreateDate;
                    data.UpdateDate = model.UpdateDate;
                    data.CreatedBy = model.CreatedBy;
                    data.UpdatedBy = model.UpdatedBy;

                };
                db.SaveChanges();
                msg = "Update SuccessFully";
            }
            return msg;
        }


        public List<VedioGalleryModel> getVediolist()
        {
            WagharalkarEntities db = new WagharalkarEntities();
            List<VedioGalleryModel> lstvedio = new List<VedioGalleryModel>();
            var addVlist = db.tblVideoGalleries.ToList();
            if (addVlist != null)
            {
                foreach (var vedio in addVlist)
                {
                    lstvedio.Add(new VedioGalleryModel()
                    {
                        Id = vedio.Id,
                        Title = vedio.Title,
                        YouTubeUrl = vedio.YouTubeUrl,
                        Type = vedio.Type,
                        CreateDate = vedio.CreateDate,
                        UpdateDate = vedio.UpdateDate,
                        CreatedBy = vedio.CreatedBy,
                        UpdatedBy = vedio.UpdatedBy
                    });
                }


            }
            return lstvedio;

        }

        public string DeleteVideoGallery(int Id)
        {
            string msg = "Delete Record";
            WagharalkarEntities db = new WagharalkarEntities();
            var videogalleryData = db.tblVideoGalleries.Where(p => p.Id == Id).FirstOrDefault();
            if (videogalleryData != null)
            {
                db.tblVideoGalleries.Remove(videogalleryData);
                db.SaveChanges();
            }
            return msg;
        }
        public VedioGalleryModel EditVideoGallery(int Id)
        {
            VedioGalleryModel model = new VedioGalleryModel();
            WagharalkarEntities db = new WagharalkarEntities();
            var editData = db.tblVideoGalleries.Where(p => p.Id == Id).FirstOrDefault();
            if(editData!=null)
            {
                model.Id=editData.Id;
                model.Title = editData.Title;
                model.YouTubeUrl = editData.YouTubeUrl;
                model.Type = editData.Type;
                model.CreateDate = editData.CreateDate;
                model.UpdateDate = editData.UpdateDate;
                model.CreatedBy = editData.CreatedBy;
                model.UpdatedBy = editData.UpdatedBy;
            }
            return model;
        }
    }
}
