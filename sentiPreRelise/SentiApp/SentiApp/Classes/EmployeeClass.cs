using SentiApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentiApp.Classes
{
     class EmployeeClass : AppData
    {
        public static string FirstLastName => $"{currentUser.UserNavigation.LastName} {currentUser.UserNavigation.FirstName}";
    }
}
