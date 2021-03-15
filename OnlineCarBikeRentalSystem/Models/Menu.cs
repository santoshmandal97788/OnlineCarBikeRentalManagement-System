using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarBikeRentalSystem.Models
{
    public static class Menu
    {
        
        public static List<tblMenu> LaodMenu()
        {
            using (var context = new OnlineCarBikeRentalDBEntities())
            {
                return context.tblMenus.ToList();
            }
        }
        public static List<tblSubMenu> LoadSubMenu(int menuid)
        {
            using (var context = new OnlineCarBikeRentalDBEntities())
            {
                return context.tblSubMenus.Where(m => m.MenuId == menuid).ToList();
            }
        }
    }
}