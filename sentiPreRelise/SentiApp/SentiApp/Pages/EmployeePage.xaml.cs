using Microsoft.EntityFrameworkCore;
using SentiApp.Classes;
using SentiApp.Entities;
using SentiApp.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SentiApp.Pages
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {

        List<EmployeeInfo> _employees = new List<EmployeeInfo>();


        public EmployeePage()
        {
            InitializeComponent();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow((sender as Button).DataContext as EmployeeInfo);
            addEditEmployeeWindow.Show();
            Update();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow(null);
            addEditEmployeeWindow.Show();
            Update();
        }

        private void Update()
        {
            _employees = AppData.Context.EmployeeInfos.ToList();
            DGridEmployee.ItemsSource = _employees;
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Button).DataContext as EmployeeInfo).Status = "Удалён";
            AppData.Context.SaveChanges();
            Update();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
