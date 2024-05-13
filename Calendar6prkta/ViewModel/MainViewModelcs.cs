using Calendar6prkta.Model;
using CalendarPract6.ViewModel.Helpers;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SerDeserLib;
using System.Windows.Media.Animation;
using Calendar6prkta.View.Pages;
using Calendar6prkta.ViewModel.CardsVM;
using Calendar6prkta.View.Cards;

namespace Calendar6prkta.ViewModel.Helpers
{
    class MainViewModelcs : BindingHelpers
    {
        static ObservableCollection<Man> allMans = new ObservableCollection<Man>();
        static ObservableCollection<Day> SaveData = new ObservableCollection<Day>();
        static Day day;
        public MainViewModelcs()
        {
            BackCommand = new BindableCommand(_ => Back());
            ForwardCommand = new BindableCommand(_ => Forward());
            ReturnCommand = new BindableCommand(_ => Return());
            SaveCommand = new BindableCommand(_ => Save());

            Man man1 = new Man("", "..\\..\\..\\Images\\.JPG", false);
            Man man2 = new Man("", "..\\..\\..\\Images\\.jpg", false);
            Man man3 = new Man("", "..\\..\\..\\Images\\.jpg", false);
            Man man4 = new Man("", "..\\..\\..\\Images\\.png", false);
            Man man5 = new Man("", "..\\..\\..\\Images\\.JPG", false);
            Man man6 = new Man("", "..\\..\\..\\Images\\.jpg", false);
            Man man7 = new Man("", "..\\..\\..\\Images\\.JPG", false);
            Man man8 = new Man("", "..\\..\\..\\Images\\.jpg", false);
            Man man9 = new Man("", "..\\..\\..\\Images\\.JPG", false);
            Man man10 = new Man("", "..\\..\\..\\Image\\.png", false);
            allMans.Add(man1); allMans.Add(man2); allMans.Add(man3); allMans.Add(man4); allMans.Add(man5);
            allMans.Add(man6); allMans.Add(man7); allMans.Add(man8); allMans.Add(man9); allMans.Add(man10);

            SavedData = SerDeser.Deserialize<ObservableCollection<Day>>("\\Model\\CalendarData.json");

            CurrentPage.SetCalendar(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), SavedData);

        }

        public void ChangeToChoice(Day day)
        {
            allManView.Clear();
            MainViewModelcs.day = day;
            CurrentPage = new ChoicePage(this);
            allMans = day.Mans;
            foreach (Man man in allMans)
            {
                ManView newMan = new ManView();
                newMan.Image = man.IconPath;
                newMan.ManName = man.ManName;
                newMan.IsChecked = man.IsSelected;
                allMansview.Add(newMan);
            }
            CardDate = day.Date.ToShortDateString();

        }
        private string cardDate;
        public string CardDate
        {
            get { return cardDate; }
            set
            {
                cardDate = value;
                OnPropertyChanged();
            }
        }

        private dynamic currentPage;
        public dynamic CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ManView> allManView = new ObservableCollection<ManView>();
        public ObservableCollection<ManView> allManView
        {
            get { return allManView; }
            set
            {
                allManView = value;
                OnPropertyChanged();
            }
        }

        private string dateLabel;
        public string DateLabel
        {
            get { return dateLabel; }
            set
            {
                dateLabel = value;
                OnPropertyChanged(nameof(DateLabel));
            }
        }

        public BindableCommand SaveCommand { get; set; }
        public BindableCommand ReturnCommand { get; set; }
        public BindableCommand BackCommand { get; set; }
        public BindableCommand ForwardCommand { get; set; }
        private void Return()
        {
            CurrentPage = new CalendarPage(this);
            CurrentPage.SetCalendar(currentMonth, SavedData);
        }

        private void Save()
        {

            ObservableCollection<Crush> crushes = new ObservableCollection<Crush>();
            foreach (var item in AllCrushesView)
            {
                string fileName = item.Image;
                Crush crush = new Crush(item.CrushName, fileName, item.IsChecked);

                crushes.Add(crush);
            }

            bool ifExict = false;
            for (int i = 0; i < SavedData.Count; i++)
            {
                if (SavedData[i].Date == day.Date)
                {
                    SavedData[i].Crushes = crushes;
                    ifExict = true;
                    break;
                }
            }
            if (!ifExict)
            {
                Day newday = new Day(day.Date, crushes);
                SavedData.Add(newday);
            }
            SerDeser.Serialize<ObservableCollection<Day>>(SavedData, "\\Model\\CalendarData.json");
            Return();

            DateTime currentMonthDate = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            CurrentPage.SetCalendar(currentMonthDate, SavedData);
        }
        private DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private void Back()
        {
            currentMonth = currentMonth.AddMonths(-1);
            DateTime firstDayOfPreviousMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            CurrentPage.SetCalendar(firstDayOfPreviousMonth, SavedData);
        }

        private void Forward()
        {
            currentMonth = currentMonth.AddMonths(1);
            DateTime firstDayOfNextMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            CurrentPage.SetCalendar(firstDayOfNextMonth, SavedData);
        }
    }
}
