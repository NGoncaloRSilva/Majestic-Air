using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Airline.Data.Entities
{
    public class Airports : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public Guid ImageId { get; set; }


        public string ImageFullPath => ImageId == Guid.Empty ? $"https://supershop20220902144406.azurewebsites.net/images/noimage.png"
            : $"https://supershopngrs.blob.core.windows.net/products/{ImageId}";

        public User User { get; set; }
    }
}
