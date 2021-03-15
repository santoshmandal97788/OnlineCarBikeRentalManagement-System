using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class AboutDB
    {
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public int AddAboutSectionContent(AboutSectionViewModel avm)
        {
            tblAboutU tb = new tblAboutU();
            tb.SubHeadingParagraph = avm.SubHeadingParagraph;
            tb.Content = avm.Content;
            tb.Image = avm.Image;
            tb.Icon = avm.Icon;
            tb.CardHeading = avm.CardHeading;
            tb.CardParagraph = avm.CardParagraph;
            _db.tblAboutUs.Add(tb);
            return _db.SaveChanges();

        }
        public List<AboutSectionViewModel> GetAboutSectionContent()
        {
            List<AboutSectionViewModel> lstabt = new List<AboutSectionViewModel>();
            List<tblAboutU> about = _db.tblAboutUs.ToList();
            foreach (var item in about)
            {
                lstabt.Add(new AboutSectionViewModel() { AboutUsId = item.AboutUsId, SubHeadingParagraph = item.SubHeadingParagraph, Content = item.Content, Image=item.Image, Icon=item.Icon, CardHeading=item.CardHeading, CardParagraph=item.CardParagraph });

            }
            return lstabt;
        }

        public int Edit(AboutSectionViewModel avm)
        {
            tblAboutU tb = _db.tblAboutUs.Where(s => s.AboutUsId == avm.AboutUsId).FirstOrDefault();
            tb.SubHeadingParagraph = avm.SubHeadingParagraph;
            tb.Content = avm.Content;
            tb.Image = avm.Image;
            tb.Icon = avm.Icon;
            tb.CardHeading = avm.CardHeading;
            tb.CardParagraph = avm.CardParagraph;
            return _db.SaveChanges();

        }
        //public int Delete(int id)
        //{
        //    tblAboutU tb = _db.tblAboutUs.Where(s => s.AboutUsId == id).FirstOrDefault();
        //    _db.tblAboutUs.Remove(tb);
        //    return _db.SaveChanges();

        //}
    }
}
