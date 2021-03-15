using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class SliderDB
    {
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public int AddSliderContent(SliderViewModel svm)
        {
            tblSlider tb = new tblSlider();
            tb.Title = svm.Title;
            tb.Description = svm.Description;
            _db.tblSliders.Add(tb);
            return _db.SaveChanges();

        }
        public List<SliderViewModel> GetAllSliderContent()
        {
            List<SliderViewModel> lstslider = new List<SliderViewModel>();
            List<tblSlider> slide = _db.tblSliders.ToList();
            foreach (var item in slide)
            {
                lstslider.Add(new SliderViewModel() { SliderId = item.SliderId, Title = item.Title, Description = item.Description });

            }
            return lstslider;
        }

        public int Edit(SliderViewModel svm)
        {
            tblSlider tb = _db.tblSliders.Where(s => s.SliderId == svm.SliderId).FirstOrDefault();
            tb.Title = svm.Title;
            tb.Description = svm.Description;
            return _db.SaveChanges();

        }
        public int Delete(int id)
        {
            tblSlider tb = _db.tblSliders.Where(s => s.SliderId == id).FirstOrDefault();
            _db.tblSliders.Remove(tb);
            return _db.SaveChanges();

        }
    }
}
   