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
using System.Windows.Shapes;

namespace SentiApp.Windows
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginAndPassword = AppData.Context.Users.ToList();
            var currentUser = loginAndPassword.FirstOrDefault(i => i.Login == LoginTb.Text);
            if (currentUser != null)
            {

            }
            if (currentUser?.Password == PasswordTb.Password)
            {
                AppData.currentUser = currentUser;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                //AppData.UserRole = (int)currentUser.Role.AccessLevel;
                this.Close();
            }
            else 
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
        }


        private void PasswordTb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text != "" && PasswordTb.Password != "")
                BadgeImage.Badge = "";
  //          else
 //               BadgeImage.Badge = "Alert";
        }

        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginTb.Text != "" && PasswordTb.Password != "")
                BadgeImage.Badge = "";
  //          else
         //       BadgeImage.Badge = MaterialDesignThemes.Wpf.PackIconExtension() ;
        }
    }
}
