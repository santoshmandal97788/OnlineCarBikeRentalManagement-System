using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class RentalContentDB
    {
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public int AddRentalContent(RentalContentViewModel rcvm)
        {
            tblRentalContent tb = new tblRentalContent();
            tb.Heading = rcvm.Heading;
            tb.FeatureList = rcvm.FeatureList;
            _db.tblRentalContents.Add(tb);
            return _db.SaveChanges();

        }
        public List<RentalContentViewModel> GetAllRentalContent()
        {
            List<RentalContentViewModel> ltsrental = new List<RentalContentViewModel>();
            List<tblRentalContent> rental = _db.tblRentalContents.ToList();
            foreach (var item in rental)
            {
                ltsrental.Add(new RentalContentViewModel() { Id = item.Id, Heading = item.Heading, FeatureList = item.FeatureList });

            }
            return ltsrental;
        }

        public int Edit(RentalContentViewModel rcvm)
        {
            tblRentalContent tb = _db.tblRentalContents.Where(r => r.Id == rcvm.Id).FirstOrDefault();
            tb.Heading   = rcvm.Heading;
            tb.FeatureList = rcvm.FeatureList;
            return _db.SaveChanges();

        }
        public int Delete(int id)
        {
            tblRentalContent tb = _db.tblRentalContents.Where(r => r.Id == id).FirstOrDefault();
            _db.tblRentalContents.Remove(tb);
            return _db.SaveChanges();

        }
    }
}
  