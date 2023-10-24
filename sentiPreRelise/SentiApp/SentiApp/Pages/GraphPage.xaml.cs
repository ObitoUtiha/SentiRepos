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
using System.Windows.Interop;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Windows.Forms.VisualStyles;
using SentiApp.Entities;

namespace SentiApp.Pages
{
    /// <summary>
    /// Interaction logic for GraphPage.xaml
    /// </summary>
    public partial class GraphPage : Page
    {

        private DateTime StartDate;
        private DateTime EndDate;

        private Shedule _shedules = new Shedule();
        private List<TimeSlotGroup> timeSlotGroups = new List<TimeSlotGroup>();

        public GraphPage()
        {
            InitializeComponent();

            // Создаем элемент Chart
            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Создаем графиковый ряд и добавляем данные
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series("Количество клиентов");
            series.ChartType = SeriesChartType.Column;

            series.Points.AddXY(new DateTime(2023, 10, 1), 20);
            series.Points.AddXY(new DateTime(2023, 10, 2), 25);
            series.Points.AddXY(new DateTime(2023, 10, 3), 30);
            series.Points.AddXY(new DateTime(2023, 10, 4), 15);
            series.Points.AddXY(new DateTime(2023, 10, 5), 18);

            chart.Series.Add(series);

            // Добавляем Chart в WindowsFormsHost
            chartHost.Child = chart;

        }

        private void DateDayPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            StartDate = Convert.ToDateTime(DateDayStartPicker.SelectedDate);
        }

        private void CmbPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DateDayEndPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDate = Convert.ToDateTime(DateDayEndPicker.SelectedDate);
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedDates = new List<DateTime?>();
            for (var date = StartDate; date <= EndDate; date = date.AddDays(1))
            {
                selectedDates.Add(date);
            }
        }
    }
}
