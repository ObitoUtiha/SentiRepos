using SentiApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SentiApp.Classes
{
    class AppData
    {
        public static SentiDbContext Context = new SentiDbContext();
        public static Frame MainFrame = new Frame();
       //public static int UserRole;
        public static User currentUser = new User();
        //public static string LastFirstName; 
    }
}
