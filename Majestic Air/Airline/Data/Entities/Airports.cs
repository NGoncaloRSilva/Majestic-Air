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

        public string ImageFullPath => ImageId == Guid.Empty ? $"https://majesticair.azurewebsites.net/images/noimage.png"
            : $"https://majesticira.blob.core.windows.net/countryflags/{ImageId}";

        public User User { get; set; }
    }
}
