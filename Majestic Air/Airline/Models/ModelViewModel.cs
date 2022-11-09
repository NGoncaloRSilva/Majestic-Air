using Airline.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    public class ModelViewModel : Model
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }
    }
}
