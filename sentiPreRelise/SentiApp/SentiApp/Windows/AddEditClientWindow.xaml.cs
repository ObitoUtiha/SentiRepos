using SentiApp.Classes;
using SentiApp.Entities;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
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
    /// Interaction logic for AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        Client _client = new Client(); 
        public AddEditClientWindow(Client currentClient)
        {
            InitializeComponent();
            StatusCmb.ItemsSource = new string[] { "Активен", "Удалён" };
            _client = currentClient;
            if(_client != null)
            {
                CommentTb.Text = _client.Comment;
                FirstNameTb.Text = _client.FirstName;
                LastNameTb.Text = _client.LastName;
                PatronymicTb.Text = _client.Patronymic;
                MedHistoryTb.Text = _client.MedHistory;
                PhoneNumberTb.Text = _client.ContactInfo;
                StatusCmb.SelectedItem = _client.Status;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string er = "";
            if (string.IsNullOrWhiteSpace(CommentTb.Text))
                CommentTb.Text = " ";
            if (string.IsNullOrWhiteSpace(FirstNameTb.Text))
                er += "Вы не ввели имя\n";
            if (string.IsNullOrWhiteSpace(LastNameTb.Text))
                er += "Вы не ввели фамилию\n";
            if (string.IsNullOrWhiteSpace(PhoneNumberTb.Text))
                er += "Вы не ввели номер телефона\n";
            if (StatusCmb.SelectedIndex == -1)
                er += "Вы не выбрали статус клиента\n";
            if(!string.IsNullOrEmpty(er))
                MessageBox.Show(er);

            if (_client != null)
            {
                _client.Comment = CommentTb.Text;
                _client.FirstName = FirstNameTb.Text;
                _client.LastName = LastNameTb.Text;
                _client.Patronymic = PatronymicTb.Text;
                _client.Status = StatusCmb.SelectedItem.ToString();
                _client.ContactInfo = PhoneNumberTb.Text;
                _client.MedHistory = MedHistoryTb.Text;
            }
            else
            {
                Client client = new Client()
                {
                    Comment = CommentTb.Text,
                    FirstName = FirstNameTb.Text,
                    LastName = LastNameTb.Text,
                    Patronymic = PatronymicTb.Text,
                    Status = StatusCmb.SelectedItem.ToString(),
                    ContactInfo = PhoneNumberTb.Text,
                    MedHistory = MedHistoryTb.Text

                };
                AppData.Context.Clients.Add(client);
            }
            AppData.Context.SaveChanges();
            this.Close();
        }
    }
}
