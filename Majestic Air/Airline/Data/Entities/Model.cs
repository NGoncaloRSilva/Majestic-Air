using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Model")]
        [MaxLength(50, ErrorMessage = "The field{0} can contain {1} characters max lengh")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "1stClass")]
        public int Tickets1stClass { get; set; }
        [Required]
        [Display(Name = "Business")]
        public int TicketsBusiness { get; set; }
        [Required]
        [Display(Name = "PremiumEconomy")]
        public int TicketsPremiumEconomy { get; set; }
        [Required]
        [Display(Name = "Economy")]
        public int TicketsEconomy { get; set; }
        
        [Display(Name = "Total")]
        public int SumTickets
        {
            get
            {
                return Tickets1stClass + TicketsBusiness + TicketsPremiumEconomy + TicketsEconomy;
            }

        }

        public User User { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }


        public string ImageFullPath => ImageId == Guid.Empty ? $"https://magesticair.azurewebsites.net/images/noimage.png"
            : $"https://magesticair01.blob.core.windows.net/models/{ImageId}";
    }
}
