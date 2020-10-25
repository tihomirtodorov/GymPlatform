using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public class GymRepository : GenericRepository<Gym>, IGymRepository
    {
        public GymRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Gym> Query => dbContext.Gyms.AsQueryable();
    }
}