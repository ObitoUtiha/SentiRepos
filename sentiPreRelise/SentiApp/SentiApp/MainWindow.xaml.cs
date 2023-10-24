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
using SentiApp.Pages;
using SentiApp.Windows;

namespace SentiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // AppData.MainFrame.Navigate(new MainMenuPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if(MainFrame.Content is MainMenuPage)
            {
                BackBtn.Visibility = Visibility.Hidden;
            }
            else
                BackBtn.Visibility = Visibility.Visible;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainMenuPage());
            EmployeeCard.Content = EmployeeClass.FirstLastName;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void EmployeeCard_DeleteClick(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
