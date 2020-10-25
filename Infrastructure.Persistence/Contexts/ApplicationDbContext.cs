using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService dateTimeService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // Preventing EF caching;
            this.dateTimeService = dateTimeService;
        }

        public DbSet<Gym> Gyms { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = dateTimeService.NowUtc;
                        //entry.Entity.CreatedBy = _authenticatedUser.UserId; // TODO
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = dateTimeService.NowUtc;
                        //entry.Entity.LastModifiedBy = _authenticatedUser.UserId; // TODO
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}