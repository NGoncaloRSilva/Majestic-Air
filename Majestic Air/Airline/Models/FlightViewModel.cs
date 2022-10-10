using Airline.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class FlightViewModel : Flight
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
