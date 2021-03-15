using OnlineCarBikeRentalSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models.Services
{
    public class CommentDB
    {
        OnlineCarBikeRentalDBEntities _db = new OnlineCarBikeRentalDBEntities();
        public int ADDComment(CommentViewModel cvm)
        {
            tblComment tb = new tblComment();
            tb.Fullname = cvm.Fullname;
            tb.Email = cvm.Email;
            tb.Comment = cvm.Comment;
            //tb.CommentDate = System.DateTime.Now;
            _db.tblComments.Add(tb);
            return _db.SaveChanges();
        }
    }
}