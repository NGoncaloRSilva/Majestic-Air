using Airline.Data.Entities;
using Airline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Data.Repositories
{
    public class AirshipRepository : GenericRepository<Airship>, IAirshipRepository
    {
        private readonly DataContext _context;

        public AirshipRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Airship> GetByIdAsyncwithModel(int id)
        {
            return await _context.Set<Airship>().Include(p => p.model)
                .OrderBy(p => p.AirshipName).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<AirshipViewModel>AddModelAsync(AirshipViewModel model)
        {
             

            var modelo = await _context.Models.FindAsync(model.ModelId);

            model.model = modelo;

            return model;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Airships
                .Include(p => p.User)
                .Include(p => p.model);
        }

        public IEnumerable<SelectListItem> GetComboModels()
        {
            var list = _context.Models.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString(),

            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a model...)",
                Value = "0",
            });

            return list;
        }
    }
}
