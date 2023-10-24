using Microsoft.VisualBasic;
using SentiApp.Classes;
using SentiApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for AddEditRegistrationWindow.xaml
    /// </summary>
    public partial class AddEditRegistrationWindow : Window
    {
        string selectedTime;
        List<TimeSlotGroup> _shedules = new List<TimeSlotGroup>();
        Appointment _appointment = new Appointment();
        List<Shedule> curShedule = new List<Shedule>();
        List<EmployeeInfo> employeeInfosList = new List<EmployeeInfo>();
        List<Client> clientsList = new List<Client>();
        public AddEditRegistrationWindow(Appointment currentAppointment)
        {
            InitializeComponent();
            curShedule = AppData.Context.Shedules.ToList();
            _shedules = AppData.Context.TimeSlotGroups.ToList();
            _appointment = currentAppointment;
            employeeInfosList = AppData.Context.EmployeeInfos.ToList();
            clientsList = AppData.Context.Clients.ToList();

            StatusCmb.ItemsSource = new string[] { "Активна", "Закрыта" };
            ClientCmb.ItemsSource = clientsList;
            EmployeeCmb.ItemsSource = employeeInfosList;

            if (AppData.currentUser.Role.AccessLevel == 0)
            {
                EmployeeCmb.SelectedIndex = AppData.currentUser.UserId - 1;
                EmployeeCmb.IsEnabled = false;
            }

                if (_appointment != null )
            {
                PhoneTb.Text = $"+{_appointment.Registration.Client.ContactInfo}";
                ClientCmb.SelectedIndex = _appointment.Registration.Client.ClientId - 1;
                EmployeeCmb.SelectedIndex = _appointment.Registration.Employee.EmployeeInfoId - 1;
                StatusCmb.Text = _appointment.Registration.Status;
                DetaPicker.SelectedDate = _appointment.Registration.DateTime;
                CostTb.Text = _appointment.Payment.ToString();
                CommentTb.Text = _appointment.Comment;
            }
        }

        private void BtnSelectDate_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {


            string er = "";
            if (ClientCmb.SelectedIndex == -1)
                er = "Вы не выбрали клиента\n";
            if (EmployeeCmb.SelectedIndex == -1)
                er = "Вы не выбрали врача\n";
            if (DetaPicker.SelectedDate == null || string.IsNullOrEmpty(DetaPicker.Text))
                er = "Вы не выбрали дату\n";
            //if (string.IsNullOrWhiteSpace(TimePicker.Text))
            //    er = "Вы не выбрали время\n";
            if (string.IsNullOrWhiteSpace(CostTb.Text))
                CostTb.Text = "0";
            if(string.IsNullOrWhiteSpace(CommentTb.Text))
                CommentTb.Text = " ";
            if (!string.IsNullOrWhiteSpace(er))
            {
                MessageBox.Show(er);
                return;
            }

            var result = MessageBox.Show(
                   "Вы не сохранили изменения\nСохранить?",
                   "Предупреждение",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.No)
                return;
            try
            {

                if (_appointment != null)
                {
                    _appointment.Payment = float.Parse(CostTb.Text);
                    _appointment.Comment = CommentTb.Text;
                    _appointment.Registration.Client = (ClientCmb.SelectedItem as Client);
                    _appointment.Registration.Employee = (EmployeeCmb.SelectedItem as EmployeeInfo);
                    _appointment.Registration.Status = StatusCmb.SelectedItem.ToString();
                    string DataTime = DetaPicker.SelectedDate.Value.Day.ToString() + "." + DetaPicker.SelectedDate.Value.Month.ToString() + "." + DetaPicker.SelectedDate.Value.Year.ToString() + " " + selectedTime;
                     _appointment.Registration.DateTime = Convert.ToDateTime(DataTime);

                    TimeSlotGroup timeSlotGroup = new TimeSlotGroup();
                    timeSlotGroup.TimeSlot = TimeSpan.Parse(selectedTime);
                    timeSlotGroup.SheduleId = curShedule.Where(p => p.Day == DetaPicker.SelectedDate && p.EmployeeId == (EmployeeCmb.SelectedItem as EmployeeInfo).EmployeeInfoId).Select(p => p.SheduleId).Last();
                    AppData.Context.TimeSlotGroups.Add(timeSlotGroup);
                }
                else
                {
                    Appointment appointment = new Appointment();
                    Registration registration = new Registration();
                    registration.Client = (ClientCmb.SelectedItem as Client);
                    registration.Employee = (EmployeeCmb.SelectedItem as EmployeeInfo);
                    registration.Status = StatusCmb.SelectedItem.ToString();
                    string DataTime = DetaPicker.SelectedDate.Value.Day.ToString() + "." + DetaPicker.SelectedDate.Value.Month.ToString() + "." + DetaPicker.SelectedDate.Value.Year.ToString() + " " + selectedTime;
                    registration.DateTime = Convert.ToDateTime(DataTime);
                    registration.RegistrationDate = DateAndTime.Now;
                    AppData.Context.Registrations.Add(registration);

                    TimeSlotGroup timeSlotGroup = new TimeSlotGroup();
                    timeSlotGroup.TimeSlot = TimeSpan.Parse(selectedTime);
                    timeSlotGroup.SheduleId = curShedule.Where(p => p.Day == DetaPicker.SelectedDate && p.EmployeeId == (EmployeeCmb.SelectedItem as EmployeeInfo).EmployeeInfoId).Select(p => p.SheduleId).Last();
                    AppData.Context.TimeSlotGroups.Add(timeSlotGroup);

                    appointment.Payment = float.Parse(CostTb.Text);
                    appointment.Comment = CommentTb.Text;
                    appointment.Registration = registration;
                    AppData.Context.Appointments.Add(appointment);

                }
                AppData.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте корректность введённых данных");
                return;
            }

            this.Close();
        }

        private void ClientCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedItem = ClientCmb.SelectedIndex + 1;
            PhoneTb.Text = string.Join("", clientsList.Where(p => p.ClientId == selectedItem).Select(p => p.ContactInfo));
        }

        private void DetaPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
          {
            var buttonsToRemove = TimerSKPnl.Children.OfType<Button>().ToList();
            foreach (var button in buttonsToRemove)
            {
                TimerSKPnl.Children.Remove(button);
            }
            if (EmployeeCmb.SelectedIndex == -1)
            {
                DetaPicker.SelectedDate = null;
                MessageBox.Show("Выберите врача");
                return;
            }
            var isDateCorrect = curShedule.Where(p => p.Day == DetaPicker.SelectedDate && p.EmployeeId == (EmployeeCmb.SelectedItem as EmployeeInfo).EmployeeInfoId).Any();
            if (isDateCorrect == false)
            {
                TbNullState.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                Shedule SheduleCur = curShedule.Where(p => p.Day == DetaPicker.SelectedDate && p.EmployeeId == (EmployeeCmb.SelectedItem as EmployeeInfo).EmployeeInfoId).Last();
                TbNullState.Visibility = Visibility.Collapsed;
                int timeEnd = Convert.ToInt32(string.Join("", (_shedules.Where(p => p.SheduleId == SheduleCur.SheduleId).Select(p => p.Shedule.EndTime.Value.Hours))));
                int timeStart = Convert.ToInt32(string.Join("", (_shedules.Where(p => p.SheduleId == SheduleCur.SheduleId).Select(p => p.Shedule.StartTime.Value.Hours))));

                int HourNumber = (timeEnd - timeStart);
                List<Shedule> shedules = AppData.Context.Shedules.Where(p => p.Day == DetaPicker.SelectedDate && p.EmployeeId == (EmployeeCmb.SelectedItem as EmployeeInfo).EmployeeInfoId).ToList();
                if(shedules.Count > 1 ) 
                {
                    MessageBox.Show("Обратитесь к администратору!");
                }
                Shedule CurrentShedule = shedules[0];
                for (int i = 0; i<=HourNumber; i++)
                {
                    if (Convert.ToInt32(CurrentShedule.StartTime.Value.Hours) % 2 == 1)
                    {
                        if (i % 2 == 1)
                            continue;
                    }
                    else if (Convert.ToInt32(CurrentShedule.StartTime.Value.Hours) % 2 == 0)
                    {
                        if (i % 2 == 1)
                            continue;
                    }
                    Button button = new Button();
                    button.Width = 100;
                    button.Height = 30;
                    button.Margin = new Thickness(10,0,0,0);
                    button.Click += ButtonSelectTime_Click;
                    int buttonContent = Convert.ToInt32(CurrentShedule.StartTime.Value.Hours) + i;
                    if (buttonContent >= CurrentShedule.EndTime.Value.Hours)
                        continue;
                    button.Content = buttonContent;
                    TimerSKPnl.Children.Add(button);
                }

                string buttonsContent =  string.Join(",", _shedules.Where(p => p.SheduleId == SheduleCur.SheduleId).Select(p => p.TimeSlot.Value.Hours.ToString()));
                string[] buttonsTostring = buttonsContent.Split(',');
                foreach(Button buttons in TimerSKPnl.Children.OfType<Button>()) 
                {
                    for(int i = 0; i<buttonsTostring.Length;i++)
                    {
                        if (buttons.Content.ToString() == buttonsTostring[i].ToString())
                            buttons.IsEnabled = false;
                    }
                    buttons.Content += ":00";
                }
            }
        }

        private void ButtonSelectTime_Click(object sender, RoutedEventArgs e)
        {
            selectedTime = (sender as Button).Content.ToString();
            (sender as Button).Background = Brushes.Gray;
            foreach(Button button in TimerSKPnl.Children.OfType<Button>())
            {
                if(button.Content.ToString() != selectedTime)
                    button.Background = Brushes.Purple;
            }

                
        }
    }   
}
