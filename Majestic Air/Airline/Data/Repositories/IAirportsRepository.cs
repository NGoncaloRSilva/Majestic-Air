using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public interface IAirportsRepository : IGenericRepository<Airports>
    {
        public IQueryable GetAllWithUsers();

       
    }
}
