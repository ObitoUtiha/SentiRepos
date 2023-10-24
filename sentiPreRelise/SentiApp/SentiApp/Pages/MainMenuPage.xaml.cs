using MaterialDesignThemes.Wpf;
using SentiApp.Classes;
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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClientPage());
        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EmployeePage());

        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationsPage());

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(AppData.currentUser.Role.AccessLevel == 0 || AppData.currentUser.Role.AccessLevel == 1)
            {
                EmployeeCard.Visibility = Visibility.Collapsed;
                GraphCard.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnGrapg_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GraphPage());
        }
    }
}
