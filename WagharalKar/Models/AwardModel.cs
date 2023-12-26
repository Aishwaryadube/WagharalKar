using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wagharalkar.Data;

namespace WagharalKar.Models
{
    public class AwardModel
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

        public string SaveAward(AwardModel model)
        {
            string msg = "Save Successfully";
            WagharalkarEntities db = new WagharalkarEntities();
            if (model.Id == 0)
            {
                var saveaward = new tblAward()

                {
                    Id = model.Id,
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
                db.tblAwards.Add(saveaward);
                db.SaveChanges();
            }
            else
            {
                var saveaward = db.tblAwards.Where(p => p.Id == model.Id).FirstOrDefault();
                if (saveaward != null)
                {
                    saveaward.Id = model.Id;
                    saveaward.Title = model.Title;
                    saveaward.Details = model.Details;
                    saveaward.Image1 = model.Image1;
                    saveaward.Image2 = model.Image2;
                    saveaward.Type = model.Type;
                    saveaward.Date = model.Date;
                    saveaward.CreateDate = model.CreateDate;
                    saveaward.UpdateDate = model.UpdateDate;
                    saveaward.CreatedBy = model.CreatedBy;
                    saveaward.UpdatedBy = model.UpdatedBy;
                };
                db.SaveChanges();
                msg = "Update Successfully";
            }
            return msg;
        }
        public List<AwardModel> getAwardlist()
        {
            WagharalkarEntities db = new WagharalkarEntities();
            List<AwardModel> lstaward = new List<AwardModel>();
            var addawardlist = db.tblAwards.ToList();
            if (addawardlist != null)
            {
                foreach (var award in addawardlist)
                {
                    lstaward.Add(new AwardModel()
                    {
                        Id = award.Id,
                        Title = award.Title,
                        Details = award.Details,
                        Image1 = award.Image1,
                        Image2 = award.Image2,
                        Type = award.Type,
                        Date = award.Date,
                        CreateDate = award.CreateDate,
                        UpdateDate = award.UpdateDate,
                        CreatedBy = award.CreatedBy,
                        UpdatedBy = award.UpdatedBy
                    });
                }


            }
            return lstaward;

        }
         public string DeleteAward(int Id)
        {
            string msg = "Delete Record";
            WagharalkarEntities db = new WagharalkarEntities();
            var awardData = db.tblAwards. Where(p => p.Id == Id).FirstOrDefault();
            if (awardData != null)
            {
                db.tblAwards.Remove(awardData);
                db.SaveChanges();
            }
            return msg;
        }

        public AwardModel EditAward(int Id)
        {
            AwardModel model = new AwardModel();
            WagharalkarEntities db = new WagharalkarEntities();
            var editData = db.tblAwards.Where(p => p.Id == Id).FirstOrDefault();
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
    


    
