using Calendar6prkta.Model;
using Calendar6prkta.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calendar6prkta.ViewModel.CardsVM
{
    internal class DayViewModel : BindingHelper
    {
        static MainViewModelcs mainViewModelcs;

        public Day DayExact {  get; set; }
        public DayViewModel(Day day, MainViewModelcs mainViewModelcs)
        {
            this.DayExact = day;
            DayViewModel.mainViewModelcs = mainViewModelcs;
            Date = day.Date.Day.ToString();

            string imagepath = "..\\..\\..\\Images\\Default.png";
            for (int i = 0; i < day.Mans.Count; i++)
            {
                if (day.Mans[i].IsSelected == true)
                {
                    imagepath = day.Mans[i].IconPath;
                    break;
                }
            }
            FirsImage = imagepath;

            OpenCommand = new BindableCommand(_ => Open());
            CleanCommand = new BindableCommand(_ => Clean());
        }

        #region Переменные 
        private string date;

        public string Date
        {
            get { return date; }
            set { 
                date = value;
                OnPropertyChanged();
            }
        }

        private string firstimage;

        public string FirstImage
        {
            get { return firstimage; }
            set
            {
                firstimage = value;
                OnPropertyChanged();
            }

            #endregion

            #region Команды 
            public BindableCommand OpenCommand { get; set; }
            public BindableCommand CleanCommand { get; private set; }
            
            public void Open()
            {
                mainViewModelcs.ChangeToChoice(this.DayExact);
            }
            
            public void Clean()
            {

            }
            
            #endregion
    }
}
