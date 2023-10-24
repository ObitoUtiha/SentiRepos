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
    /// Interaction logic for CloseRegistrationWindow.xaml
    /// </summary>
    public partial class CloseRegistrationWindow : Window
    {
        Appointment appointments = new Appointment();
        public CloseRegistrationWindow(Appointment curentAppointment)
        {
            InitializeComponent();
            appointments = curentAppointment;
            NameLb.Content = appointments.Registration.Client.FullName;

         }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string er = "";
            if (string.IsNullOrWhiteSpace(PaymentTb.Text))
                er += "Вы не ввели цену\n";
            if (!string.IsNullOrEmpty(er))
                MessageBox.Show(er, "Не все поля заполнены", MessageBoxButton.OK, MessageBoxImage.Error);
            appointments.Comment = CommentTb.Text;
            appointments.Payment = float.Parse(PaymentTb.Text);
            appointments.Registration.Status = "Закрыта";
            AppData.Context.SaveChanges();
            this.Close();
        }
    }
}
