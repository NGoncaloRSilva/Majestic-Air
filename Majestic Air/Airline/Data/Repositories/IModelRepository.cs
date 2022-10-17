using Airline.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Airline.Data.Repositories
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        public IQueryable GetAllWithUsers();

        
    }
}
