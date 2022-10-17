using Airline.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class AirshipViewModel 
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Airship")]
        public string AirshipName { get; set; }
        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name = "Model")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a model.")]
        public int ModelId { get; set; }

        [Display(Name = "Model")]
        public Model model { get; set; }

        public User User { get; set; }




        public IEnumerable<SelectListItem> ListModel { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        
    }
}
