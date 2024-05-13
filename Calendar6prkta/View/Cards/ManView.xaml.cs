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

namespace Calendar6prkta.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для ManView.xaml
    /// </summary>


    public partial class ManView : Page
    {
        public string ManName { get; set; }

        public bool IsCheked { get; set; }

        public string Image {  get; set; }

        public ManView()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
