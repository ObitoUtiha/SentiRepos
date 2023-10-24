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
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private List<Entities.Client> _clients = new List<Entities.Client>();
        public ClientPage()
        {
            InitializeComponent();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Button).DataContext as Client).Status = "Удалён";
            AppData.Context.SaveChanges();
            Update();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            AddEditClientWindow addEditClientWindow = new AddEditClientWindow((sender as Button).DataContext as Client);
            addEditClientWindow.ShowDialog();
            Update();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditClientWindow addEditClientWindow = new AddEditClientWindow(null);
            addEditClientWindow.ShowDialog();
            Update();
        }

        private void Update()
        {
            _clients = AppData.Context.Clients.ToList();

             if (!string.IsNullOrWhiteSpace(SearchTb.Text))
            {
                _clients = _clients.Where(p => p.Patronymic.ToLower().Trim().Contains(SearchTb.Text.ToLower().Trim()) ||
                p.FirstName.ToLower().Trim().Contains(SearchTb.Text.ToLower().Trim()) ||
                p.LastName.ToLower().Trim().Contains(SearchTb.Text.ToLower().Trim())).ToList();
            }    
            DGridClients.ItemsSource = _clients;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(AppData.currentUser.Role?.AccessLevel == 0)
            {
                ColumnDel.Visibility = Visibility.Collapsed;
                ColumnEdit.Visibility = Visibility.Collapsed;
            }
            Update();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
