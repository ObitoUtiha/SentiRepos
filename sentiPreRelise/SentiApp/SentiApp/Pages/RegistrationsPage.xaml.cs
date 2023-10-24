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
    /// Interaction logic for RegistrationsPage.xaml
    /// </summary>
    public partial class RegistrationsPage : Page
    {

        private List<Appointment> _appointments = new List<Appointment>();

        public RegistrationsPage()
        {
            InitializeComponent();
        }

        private void Update()
        {
            if(AppData.currentUser.Role?.AccessLevel == 0)
                _appointments = AppData.Context.Appointments.Where(i => i.Registration.EmployeeId == AppData.currentUser.UserId).ToList();
            else
                _appointments = AppData.Context.Appointments.ToList();

            if(!string.IsNullOrWhiteSpace(SearchTb.Text))
            {
                _appointments = _appointments.Where(p => p.Registration.Client.LastName.ToLower().Trim().Contains(SearchTb.Text.ToLower().Trim())).ToList();
            }

            if(FiltrCmb.SelectedIndex != -1)
            {
                switch(FiltrCmb.SelectedIndex)
                {
                    case 1:
                        _appointments = _appointments.OrderBy(p => p.Registration?.Status).ToList();
                        break;
                    case 2:
                        _appointments = _appointments.OrderBy(p => p.Registration?.Status).Reverse().ToList();
                        break;
                    default:
                        break;  
                }
            }

            if(!string.IsNullOrEmpty(ClientDeta.Text) || ClientDeta.SelectedDate != null)
            {
                _appointments = _appointments.Where(p => p.Registration?.DateTime.Value.ToShortDateString() == ClientDeta.SelectedDate.Value.ToShortDateString()).ToList();
            }

            if (_appointments.Count <= 0)
                NullTb.Visibility = Visibility.Visible;
            else
                NullTb.Visibility = Visibility.Hidden;

            RegisterList.ItemsSource = _appointments;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FiltrCmb.ItemsSource = new List<string>() { "Без сортировки", "Активна", "Закрыта" };
            Update();
        }



        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FiltrCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
            }

        private void ClientDeta_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            CloseRegistrationWindow closeRegistrationWindow = new CloseRegistrationWindow((sender as Button).DataContext as Appointment);
            closeRegistrationWindow.ShowDialog();
            Update();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            AddEditRegistrationWindow addEditRegistrationWindow = new AddEditRegistrationWindow((sender as Button).DataContext as Appointment);
            addEditRegistrationWindow.ShowDialog();
            Update();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditRegistrationWindow addEditRegistrationWindow = new AddEditRegistrationWindow(null);
            addEditRegistrationWindow.ShowDialog();
            Update();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintRegistrationWindow printRegistrationPage = new PrintRegistrationWindow((sender as Button).DataContext as Appointment);
            printRegistrationPage.ShowDialog();
        }
    }
}
