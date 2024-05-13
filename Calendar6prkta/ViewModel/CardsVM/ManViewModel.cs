using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calendar6prkta.ViewModel.CardsVM
{
    class ManViewModel
    {
        public ManViewModelcs(Man man)
        {
            IsChecked = man.IsSelected;
            ManName = man.ManName;
            string imagepath = man.IconPath;
            Image = imagepath;
        }

        #region Переменные
        private string manName;

        public string ManName
        {
            get { return manName; }
            set
            {
                manName = value;
                OnPropertyChanged();
            }
        }

        private bool isChecked;

        public bool IsCheked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
            


        }

        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
            }
             #endregion
        }
}   }
