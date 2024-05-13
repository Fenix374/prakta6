using Calendar6prkta.View.Cards;
using Calendar6prkta.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Calendar6prkta.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalnedarPage.xaml
    /// </summary>
    public partial class CalnedarPage : Page
    {
        static MainViewModelcs mainViewModelcs;


        public CalnedarPage(MainViewModelcs mainViewModelcs)
        {
            CalendarPage.MainViewModelcd = mainViewModelcs;
            InitializeComponent();
            if(App.Theme == "LightTheme")
            {
                ThemeToggle.IsCheked = true;
            }
            DataContext = mainViewModelcs;
        }

        public SetCalendar(DateTime dateDefault, ObservableCollection<Day> data)
        {
            DayWrap.Children.Clear();
            ObservableCollection<Man> mans = new ObservableCollection<Man>();
            int dayNum = DateTime.DaysInMonth(dateDefault.Year, dateDefault.Month);

            for (int i = 1; i <= dayNum; i++)
            {
                DateTime date = new DateTime(dateDefault.Year, dateDefault.Month, i);
                mans = data[0].Mans;
                for (int j = 0; j < data.Count; j++)
                {
                    if (data[j] == date)
                    {
                        mans = data[j].Mans;
                    }
                }
                foreach (var dayDate in data)
                {
                    if(dayDate == date)
                    {
                        mans = dayDate.Mans;
                        break;
                    }
                }

                DayOfWeek newday = new Day (date, mans);
                DayView day = new DayView(newday, mainViewModelcs);
                DayWrap.Children.Add(day);

            }

            string monthyear = new DateTime(dateDefault.Year, dateDefault.Month, 1).ToString("MMMM, yyyy");
            mainViewModelcs.DateLabel = monthYear;

        }

        private void ToggleButton_Ckecked(object sender, System.Windows.RoutedEventArgs e)
        {
            App.Theme = "LightTheme";
        }

        private void ToggleButton_Uncheked(object sender, System.Windows.RoutedEvent e)
        {
            App.Theme = "DarkTheme";
        }
    }
}
