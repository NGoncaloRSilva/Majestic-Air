using Airline.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Airline.Data.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        private readonly DataContext _context;
        public ModelRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Models.Include(p => p.User);
        }
    }
}
