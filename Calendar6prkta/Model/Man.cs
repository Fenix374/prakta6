using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar6prkta.Model
{
    class Man
    {
        public string ManName { get; set; }

        public string IconPath {  get; set; }

        public bool IsSelected { get; set; }

        public Man(string manName, string iconPath, bool isselected)
        {
            this.ManName = manName;
            this.IconPath = iconPath;
            this.IsSelected = isselected;
        }
    }
}
