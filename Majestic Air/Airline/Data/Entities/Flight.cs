using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Data.Entities
{
    public class Flight : IEntity
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Day { get; set; }
        [Required]
        [Display(Name = "Airship")]
        public Airship AirshipName { get; set; }
        [Required]
        [Display(Name = "Price 1stClass")]
        public decimal Price1stClass { get; set; }
        [Required]
        [Display(Name = "Price Business")]
        public decimal PriceBusiness { get; set; }
        [Required]
        [Display(Name = "Price PremiumEconomy")]
        public decimal PricePremiumEconomy { get; set; }
        [Required]
        [Display(Name = "Price Economy")]
        public decimal PriceEconomy { get; set; }


        //public List<Seats> Seats1stClass { get; set; }
        //public List<Seats> SeatsBusiness { get; set; }
        //public List<Seats> SeatsPremiumEconomy { get; set; }
        //public List<Seats> SeatsEconomy { get; set; }

        public List<Seats> Seatss { get; set; }

        public int Stock => Stock1stClass + StockBusiness + StockPremiumEconomy + StockEconomy;

        public int Stock1stClass
        {
            get
            {
                int count1stclass = 0;

                foreach (var item in Seatss)
                {
                    if (item.Available == true)
                    {
                        if(item.Classe.Class == "1st Class")
                        {
                            count1stclass++;
                        }


                    }
                }
                

                return count1stclass;

                //return 1;
            }

        }

        public int StockBusiness
        {
            get
            {
                int countBusiness = 0;

                foreach (var item in Seatss)
                {
                    if (item.Available == true)
                    {
                       

                        if (item.Classe.Class == "Business Class")
                        {
                            countBusiness++;
                        }

                        

                        


                    }
                }


                return countBusiness ;

                //return 1;
            }

        }

        public int StockPremiumEconomy
        {
            get
            {
                int countPremiumEconomy = 0;

                foreach (var item in Seatss)
                {
                    if (item.Available == true)
                    {
                        

                        if (item.Classe.Class == "Premium Economy Class")
                        {
                            countPremiumEconomy++;
                        }

                        


                    }
                }


                return countPremiumEconomy ;

                //return 1;
            }

        }

        public int StockEconomy
        {
            get
            {
                int countEconomy = 0;

                foreach (var item in Seatss)
                {
                    if (item.Available == true)
                    {
                        
                        if (item.Classe.Class == "Economy Class")
                        {
                            countEconomy++;
                        }


                    }
                }


                return countEconomy;

                //return 1;
            }

        }

        [Display(Name = "Is Available")]
        public bool Available => Stock1stClass + StockBusiness + StockPremiumEconomy + StockEconomy != 0;

        [Required]
        public Airports Origin { get; set; }
        [Required]
        public Airports Destination { get; set; }

        

        

        public User User { get; set; }
    }
}
