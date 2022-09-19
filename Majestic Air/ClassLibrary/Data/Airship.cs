using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class Airship
    {
        public int Id { get; set; }
        public string AirshipName { get; set; }
        public Model model { get; set; }
    }
}
