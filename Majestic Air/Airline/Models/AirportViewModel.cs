using Airline.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class AirportViewModel : Airports
    {


        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        
    }
}
