using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для CalendarPagexaml.xaml
    /// </summary>
    public partial class CalendarPagexaml : System.Windows.Controls.Page
    {
        public CalendarPagexaml()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Today;
        }

        private void ForevardButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = datePicker.SelectedDate.Value.AddMonths(1);
            datePicker.SelectedDate = newDate;
        }

        private void BacvardButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = datePicker.SelectedDate.Value.AddMonths(-1);
            datePicker.SelectedDate = newDate;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            createCards();
        }

        public void createCards()
        {
            int daysInMonth = DateTime.DaysInMonth(datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month);

            calendarWrap.Children.Clear();

            for(int i = 1; i<=daysInMonth; i++)
            {
                var card = new CalendarCard();
                card.dayBlock.Text = i.ToString();

                DateTime dateTime = new DateTime(year: datePicker.SelectedDate.Value.Year, datePicker.SelectedDate.Value.Month, i);
                card.selectedDate = dateTime;

                if(DateNote.days != null)
                {
                    foreach(var day in DateNote.days)
                    {
                        if (day.day == dateTime)
                        {
                            foreach (var item in day.notes)
                            {
                                if (item.isSelected)
                                {                                    
                                    BitmapImage bitmapImage = new BitmapImage(new Uri(item.iconPath, UriKind.Absolute));

                                    
                                    card.cardImage.Source = bitmapImage;
                                    card.cardImage.Height = bitmapImage.PixelHeight;
                                    card.cardImage.Width = bitmapImage.PixelWidth;
                                    break;
                                }
                            }
                        }
                    }
                }
                calendarWrap.Children.Add(card);
            }

            
        }
    }
}
