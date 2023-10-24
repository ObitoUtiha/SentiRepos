using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SentiApp.Entities
{
    public partial class EmployeeInfo
    {
        public string SpeciAlization => string.Join(", ", EmployeeSpecializations.Where(p => p.EmployeeId == EmployeeInfoId).Select(p => p.Specialization?.SpecializationName)).ToLower();

        public string FullName => $"{LastName} {FirstName} {Patronymic}";

        public bool clientStatus
        {
            get
            {
                return Status == "Удалён" ? false : true;
            }
        }

        public Visibility ButtonDelVisibility
        {
            get
            {
                return clientStatus == true ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
