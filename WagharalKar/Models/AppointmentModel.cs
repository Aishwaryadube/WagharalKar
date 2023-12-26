using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wagharalkar.Data;

namespace WagharalKar.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }
        public string AppointmentDate { get; set; }
        public string Gender { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        public string SaveAppointment(AppointmentModel model)
        {
            string msg = "Save Successfully";
            WagharalkarEntities db = new WagharalkarEntities();
            if (model.Id == 0)
            {


                var saveappointment = new tblAppoinment()
                {
                    Id=model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    City = model.City,
                    MobileNo = model.MobileNo,
                    AppointmentDate = model.AppointmentDate,
                    Gender = model.Gender,
                    Message = model.Message,
                    UpdateDate = model.UpdateDate,
                    CreatedBy = model.CreatedBy,
                    UpdatedBy = model.UpdatedBy,
                    CreateDate = model.CreateDate
                };
                db.tblAppoinments.Add(saveappointment);
                db.SaveChanges();
            }
            else
            {
                var saveappointment = db.tblAppoinments.Where(p => p.Id == model.Id).FirstOrDefault();
                if (saveappointment != null)
                {
                    saveappointment.Id = model.Id;
                    saveappointment.Name = model.Name;
                    saveappointment.Email = model.Email;
                    saveappointment.City = model.City;
                    saveappointment.MobileNo = model.MobileNo;
                    saveappointment.AppointmentDate = model.AppointmentDate;
                    saveappointment.Gender = model.Gender;
                    saveappointment.Message = model.Message;
                    saveappointment.CreateDate = model.CreateDate;
                    saveappointment.UpdateDate = model.UpdateDate;
                    saveappointment.CreatedBy = model.CreatedBy;
                    saveappointment.UpdatedBy = model.UpdatedBy;
                };
                db.SaveChanges();
                msg = "Update Successfully";
            }
            return msg;
        
        }
        public List<AppointmentModel> getAppointmentlist()
        {
            WagharalkarEntities db = new WagharalkarEntities();
            List<AppointmentModel> lstappointment = new List<AppointmentModel>();
            var addappintmentlist = db.tblAppoinments.ToList();
            if (addappintmentlist != null)
            {
                foreach (var appointment in addappintmentlist)
                {
                    lstappointment.Add(new AppointmentModel()
                    {
                        Id = appointment.Id,
                        Name = appointment.Name,
                        Email = appointment.Email,
                        City = appointment.City,
                        MobileNo = appointment.MobileNo,
                        AppointmentDate = appointment.AppointmentDate,
                        Gender = appointment.Gender,
                        Message = appointment.Message,
                        CreateDate = appointment.CreateDate,
                        UpdateDate = appointment.UpdateDate,
                        CreatedBy = appointment.CreatedBy,
                        UpdatedBy = appointment.UpdatedBy
                    });
                }


            }
            return lstappointment;

        }

        public string DeleteAppointment(int Id)
        {
            string msg = "Delete Record";
            WagharalkarEntities db = new WagharalkarEntities();
            var appintmentData = db.tblAppoinments.Where(p => p.Id == Id).FirstOrDefault();
            if (appintmentData != null)
            {
                db.tblAppoinments.Remove(appintmentData);
                db.SaveChanges();
            }
            return msg;
        }
        public AppointmentModel EditAppointment(int Id)
        {
            AppointmentModel model = new AppointmentModel();
            WagharalkarEntities db = new WagharalkarEntities();
            var editData = db.tblAppoinments.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.Name = editData.Name;
                model.Email = editData.Email;
                model.City = editData.City;
                model.MobileNo = editData.MobileNo;
                model.AppointmentDate = editData.AppointmentDate;
                model.Gender = editData.Gender;
                model.Message = editData.Message;
                model.CreateDate = editData.CreateDate;
                model.UpdateDate = editData.UpdateDate;
                model.CreatedBy = editData.CreatedBy;
                model.UpdatedBy = editData.UpdatedBy;
            }
            return model;
        }

    }
}
    
