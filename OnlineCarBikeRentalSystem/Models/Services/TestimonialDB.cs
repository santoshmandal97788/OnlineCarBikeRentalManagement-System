using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class TestimonialDB
    {
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public int AddNewTestimonial(TestimonialViewModel tvm)
        {
            tblTestimonial tb = new tblTestimonial();
            tb.Paragraph = tvm.Paragraph;
            tb.Username = tvm.Username;
            tb.Image = tvm.Image;
            _db.tblTestimonials.Add(tb);
            return _db.SaveChanges();

        }
        public List<TestimonialViewModel> GetTestimonialList()
        {
            List<TestimonialViewModel> lsttst = new List<TestimonialViewModel>();
            List<tblTestimonial> test = _db.tblTestimonials.ToList();
            foreach (var item in test)
            {
                lsttst.Add(new TestimonialViewModel() { Id = item.Id, Paragraph = item.Paragraph, Username = item.Username, Image = item.Image});

            }
            return lsttst;
        }

        public int Edit(TestimonialViewModel tvm)
        {
            tblTestimonial tb = _db.tblTestimonials.Where(t => t.Id == tvm.Id).FirstOrDefault();
            tb.Paragraph = tvm.Paragraph;
            tb.Username = tvm.Username;
            tb.Image = tvm.Image;
            return _db.SaveChanges();

        }
        public int Delete(int id)
        {
            tblTestimonial tb = _db.tblTestimonials.Where(t => t.Id == id).FirstOrDefault();
            _db.tblTestimonials.Remove(tb);
            return _db.SaveChanges();
        }
    }
}
