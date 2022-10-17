using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public interface IAirshipRepository : IGenericRepository<Airship>
    {
        public IQueryable GetAllWithUsers();

        public  Task<Airship> GetByIdAsyncwithModel(int id);

        public IEnumerable<SelectListItem> GetComboModels();

        Task<AirshipViewModel> AddModelAsync(AirshipViewModel model);
    }
}
