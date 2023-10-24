using MSHTML;
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
    /// Interaction logic for PrintRegistrationWindow.xaml
    /// </summary>
    public partial class PrintRegistrationWindow : Window
    {
        private Appointment _registration;

        public PrintRegistrationWindow(Appointment registration)
        {
            InitializeComponent();
            _registration = registration;


            var clientName = registration.Registration.Client.FullName;
            var doctorName = registration.Registration.Employee.FullName;
            var cost = registration.Payment;  
            var comment = registration.Comment;

            var appointmentDate = registration.Registration.DateTime;  

            var todayDate = DateTime.Now.Date;
            var currentDate = $"{todayDate.Day:00} {todayDate.ToString("MMMM")} {todayDate.Year} г.";

            StringBuilder report = new StringBuilder();
            report.AppendLine("<!DOCTYPE html>");
            report.AppendLine("<html>");
            report.AppendLine("<head>");
            report.AppendLine("<meta charset=\"utf-8\">");
            report.AppendLine("<style>");
            report.AppendLine("  body { text-align: left; border: 2px solid #000; padding: 4px; }");
            report.AppendLine("  .header { text-align: right; }");
            report.AppendLine("  .right-align { text-align: right; }");
            report.AppendLine("  .center-align { text-align: center; }");
            report.AppendLine("  .line { border-top: 1px solid #000; margin: 10px 0; }");
            report.AppendLine("  .underline { text-decoration: underline; }");
            report.AppendLine("</style>");
            report.AppendLine("</head>");
            report.AppendLine("<body>");

            report.AppendLine("<p class=\"center-align\"><strong>Senti - психологическая помощь</strong></p>");
            report.AppendLine("<div class=\"line\"></div>");
            report.AppendLine("<p class=\"right-align\"><strong>Дата записи: </strong><br>" + appointmentDate.Value.Date.ToString("dd MMMM yyyy") + "г.</p>");
            report.AppendLine("<p class=\"left-align\"><strong>ФИО врача: </strong>" + doctorName + "</p>");
            report.AppendLine("<p class=\"left-align\"><strong>ФИО пациента: </strong>" + clientName + "</p>");
            report.AppendLine("<p><strong>Заключение и рекомендации: </strong><span class=\"underline\">" + comment + "</span></p>");
            report.AppendLine("<p><strong>Стоимость:</strong>" + cost + "р.</p>");
            report.AppendLine("<div class=\"line\"></div>");
            report.AppendLine("<p class=\"left-align\"><strong>Дата печати:</strong><br>" + currentDate + "</p>");
            report.AppendLine("<p class=\"center-align\">МП. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Подпись врача:______</p>");

            report.AppendLine("</body>");
            report.AppendLine("</html>");


            //StringBuilder report = new StringBuilder();
            //report.AppendLine("<!DOCTYPE html>");
            //report.AppendLine("<html>");
            //report.AppendLine("<head>");
            //report.AppendLine("<meta charset=\"utf-8\">");
            //report.AppendLine("</head>");
            //report.AppendLine("<body>");
            //report.AppendLine($"<p align=\"right\" style=\"margin: 20px;\">Квитанция об оплате<br>" +
            //$"от «{_registration.Registration.DateTime.Value.Hour:00}» {registration.Registration.DateTime.Value.ToString("MMMM")} {registration.Registration.DateTime.Value.Year}г.<br>" +
            //    $"Пациент {_registration.Registration.Client.FirstName}</p>");
            //report.AppendLine("<p><h3 align=\"center\">Смета на стоматологическое лечение и протезирование</h3></p>");
            //report.AppendLine("<table border=\"1\" align=\"justify\" style=\"width: 900px; margin:0 auto;\">");
            //report.AppendLine("<tbody>");
            //report.AppendLine("<tr>");
            //report.AppendLine("<th>№ п/п</th>");
            //report.AppendLine("<th>Наименование</th>");
            //report.AppendLine("<th>Стоимость</th>");
            //report.AppendLine("</tr>");

            ////report.AppendLine("<tr>");
            ////report.AppendLine($"<td>{_registration..ID}</td>");
            ////report.AppendLine($"<td>{service.Name}</td>");
            ////report.AppendLine($"<td>{service.Price}</td>");
            ////report.AppendLine("</tr>");

            //report.AppendLine("<tr>");
            //report.AppendLine($"<td colspan=\"2\" align=\"right\"><b>Итого:</b></td>");
            //report.AppendLine($"<td>{_registration.Payment.ToString()}</td>");
            //report.AppendLine("</tr>");
            //report.AppendLine("</tbody>");
            //report.AppendLine("</table>");
            //report.AppendLine("<p style=\"margin: 10px 0px;\">Работа принята_________________________________(подпись пациента)<br>" +
            //    "Замечаний к качеству, сроку и объему оказанных услуг нет.</p>");
            //report.AppendLine($"<p style=\"margin: 10px 0px;\" align=\"right\">«{DateTime.Now.Day:00}» {DateTime.Now.ToString("MMMM")} {DateTime.Now.Year}г.</p>");
            //report.AppendLine("<p style=\"margin: 10px 0px;\" align=\"right\">_________________________________(подпись)</p>");
            //report.AppendLine("</body>");
            //report.AppendLine("</html>");
            WBrowserReport.NavigateToString(report.ToString());
            _registration = registration;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            var doc = WBrowserReport.Document as IHTMLDocument2;
            doc.execCommand("Print");
        }
    }
}
