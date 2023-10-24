using SentiApp.Classes;
using SentiApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SentiApp.Windows
{
    /// <summary>
    /// Interaction logic for AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {

        EmployeeInfo _employeeInfo;

        public AddEditEmployeeWindow(EmployeeInfo employee)
        {
            InitializeComponent();
            _employeeInfo = employee;
            StatusCmb.ItemsSource = new string[] { "Активный", "Удалённый" };
            if(_employeeInfo != null)
            {
               FirstNameTb.Text = _employeeInfo.FirstName;
               LastNameTb.Text = _employeeInfo.LastName;
               PatronymicTb.Text = _employeeInfo.Patronymic;
               StatusCmb.SelectedItem = _employeeInfo.Status;
               AcceptanceDatePicker.SelectedDate = _employeeInfo.AcceptanceDate;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string er = "";
            if (string.IsNullOrWhiteSpace(FirstNameTb.Text))
                er += "Вы не ввели имя\n";
            if (string.IsNullOrWhiteSpace(LastNameTb.Text))
                er += "Вы не ввели фамилию\n";
            if (AcceptanceDatePicker.SelectedDate == null)
                er += "Вы не выбрали дату поступления\n";
            if (StatusCmb.SelectedIndex == -1)
                er += "Вы не выбрали статус сотрудника\n";
            if (!string.IsNullOrEmpty(er))
                MessageBox.Show(er);

            if (_employeeInfo != null)
            {
                _employeeInfo.FirstName = FirstNameTb.Text;
                _employeeInfo.AcceptanceDate = AcceptanceDatePicker.SelectedDate;
                _employeeInfo.Status = StatusCmb.SelectedItem.ToString();
                _employeeInfo.LastName = LastNameTb.Text;
                _employeeInfo.Patronymic = PatronymicTb.Text;
            }
            else
            {
                EmployeeInfo employeeInfo = new EmployeeInfo()
                {
                    FirstName = FirstNameTb.Text,
                    LastName = LastNameTb.Text,
                    Patronymic = PatronymicTb.Text,
                    Status = StatusCmb.SelectedItem.ToString(),
                    AcceptanceDate = AcceptanceDatePicker.SelectedDate
                };
                AppData.Context.Add(employeeInfo);
            }
            AppData.Context.SaveChanges();
        }
    }
}
