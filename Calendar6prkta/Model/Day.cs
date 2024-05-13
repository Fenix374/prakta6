using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar6prkta.Model
{
    class Day
    {
        public DateTime Date { get; set; }

        public ObservableCollection<Man> Mans { get; set; }

        public Day(DateTime date, ObservableCollection<Man> mans) {
        this.Date = date;
        this.Mans = mans;
        }
    }
}
