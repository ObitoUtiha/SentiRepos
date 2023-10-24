using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace SentiApp.Entities
{
    public partial class User
    {
        public Visibility BtnVisible
        {
            get
            {
                return Role?.AccessLevel == 1 ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }


    public partial class Registration
    {


        public bool RegistrationStatus
        {
            get
            {
                return Status == "Активна" ? false : true;
            }
        }

        public Brush RegistrationColor
        {
            get
            {
                return RegistrationStatus == false ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush((Colors.White));
            }
        }

        public Visibility ButtonVisibility
        {
            get
            {
                return RegistrationStatus == true ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility ButtonVisibilityRole
        {
            get
            {
                return Employee.User.Role.AccessLevel == 1 ? Visibility.Collapsed : Visibility.Visible;
            }
        }


    }
}
