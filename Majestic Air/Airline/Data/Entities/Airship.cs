using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Airline.Data.Entities
{
    public class Airship : IEntity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string AirshipName { get; set; }
        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Display(Name = "Model")]
        public Model model { get; set; }

        public User User { get; set; }
    }
}
