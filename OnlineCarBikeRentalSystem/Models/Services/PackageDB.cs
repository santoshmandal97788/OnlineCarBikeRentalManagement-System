using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class PackageDB
    {
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public int AddPackages(PackageViewModel pvm)
        {
            tblPackageContent tb = new tblPackageContent();
            tb.PackageHeading = pvm.PackageHeading;
            tb.ListPackage = pvm.ListPackage;
            _db.tblPackageContents.Add(tb);
            return _db.SaveChanges();

        }
        public List<PackageViewModel> GetAllPackage()
        {
            List<PackageViewModel> lstpackage = new List<PackageViewModel>();
            List<tblPackageContent> pack = _db.tblPackageContents.ToList();
            foreach (var item in pack)
            {
                lstpackage.Add(new PackageViewModel() { PackageId = item.PackageId, PackageHeading = item.PackageHeading, ListPackage = item.ListPackage });

            }
            return lstpackage;
        }

        public int Edit(PackageViewModel pvm)
        {
            tblPackageContent tb = _db.tblPackageContents.Where(p => p.PackageId == pvm.PackageId).FirstOrDefault();
            tb.PackageHeading = pvm.PackageHeading;
            tb.ListPackage = pvm.ListPackage;
            return _db.SaveChanges();

        }
        public int Delete(int id)
        {
            tblPackageContent tb = _db.tblPackageContents.Where(p => p.PackageId == id).FirstOrDefault();
            _db.tblPackageContents.Remove(tb);
            return _db.SaveChanges();

        }
    }
}
  