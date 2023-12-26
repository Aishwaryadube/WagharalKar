using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Wagharalkar.Data;

namespace WagharalKar.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }

        public string SaveReg(ActivityModel model)
        {
            string msg = "Record Save";
            WagharalkarEntities db =new  WagharalkarEntities();
            if (model.Id == 0)
            {

                var savereg = new tblActivity()
                {
                    Id=model.Id,
                    Title = model.Title,
                    Details = model.Details,
                    Image1 = model.Image1,
                    Image2 = model.Image2,
                    Type = model.Type,
                    Date = model.Date,
                    CreateDate = model.CreateDate,
                    UpdateDate = model.UpdateDate,
                    CreatedBy = model.CreatedBy,
                    UpdatedBy = model.UpdatedBy
                };
                db.tblActivities.Add(savereg);
                db.SaveChanges();
            }
            else
            {
                var saveactivity = db.tblActivities.Where(p => p.Id == model.Id).FirstOrDefault();
                if (saveactivity != null)
                {
                    saveactivity.Id = model.Id;
                    saveactivity.Title = model.Title;
                    saveactivity.Details = model.Details;
                    saveactivity.Image1 = model.Image1;
                    saveactivity.Image2 = model.Image2;
                    saveactivity.Type = model.Type;
                    saveactivity.Date = model.Date;
                    saveactivity.CreateDate = model.CreateDate;
                    saveactivity.UpdateDate = model.UpdateDate;
                    saveactivity.CreatedBy = model.CreatedBy;
                    saveactivity.UpdatedBy = model.UpdatedBy;
                };
                db.SaveChanges();
                msg = "Update Successfully";
            }
            return msg;

        }
        public List<ActivityModel> getActivitylist(string Search)
        {
            WagharalkarEntities db = new WagharalkarEntities();
            List<ActivityModel> lstactivity = new List<ActivityModel>();
            var addactivitylist = db.tblActivities.Where(p=>(p.Title.Contains(Search))||
            (p.Details.Contains(Search))||
            (p.Type.Contains(Search))).ToList();
            if (addactivitylist != null)
            {
                foreach (var activity in addactivitylist)
                {
                    lstactivity.Add(new ActivityModel()
                    {
                        Id = activity.Id,
                        Title = activity.Title,
                        Details = activity.Details,
                        Image1 = activity.Image1,
                        Image2 = activity.Image2,
                        Type=activity.Type,
                        Date=activity.Date,
                        CreateDate = activity.CreateDate,
                        UpdateDate = activity.UpdateDate,
                        CreatedBy = activity.CreatedBy,
                        UpdatedBy = activity.UpdatedBy
                    });
                }


            }
            return lstactivity;

        }
        public string DeleteActivity(int Id)
        {
            string msg = "Delete Record";
            WagharalkarEntities db = new WagharalkarEntities();
            var activityData = db.tblActivities. Where(p => p.Id == Id).FirstOrDefault();
            if (activityData != null)
            {
                db.tblActivities.Remove(activityData);
                db.SaveChanges();
            }
            return msg;
        }
        public ActivityModel EditActivity(int Id)
        {
            ActivityModel model = new ActivityModel();
            WagharalkarEntities db = new WagharalkarEntities();
            var editData = db.tblActivities.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.Title = editData.Title;
                model.Details = editData.Details;
                model.Image1 = editData.Image1;
                model.Image2 = editData.Image2;
                model.Type = editData.Type;
                model.Date = editData.Date;
                model.CreateDate = editData.CreateDate;
                model.UpdateDate = editData.UpdateDate;
                model.CreatedBy = editData.CreatedBy;
                model.UpdatedBy = editData.UpdatedBy;
            }
            return model;
        }
    }
}
