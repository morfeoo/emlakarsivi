using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RemDijital.EmlakTakip.Authorization.Roles;
using RemDijital.EmlakTakip.Authorization.Users;
using RemDijital.EmlakTakip.MultiTenancy;
using RemDijital.EmlakTakip.Cities;
using RemDijital.EmlakTakip.Districts;
using RemDijital.EmlakTakip.EstateTypes;
using RemDijital.EmlakTakip.SaleTypes;
using RemDijital.EmlakTakip.Mahalles;
using RemDijital.EmlakTakip.Estates;

namespace RemDijital.EmlakTakip.EntityFrameworkCore
{
    public class EmlakTakipDbContext : AbpZeroDbContext<Tenant, Role, User, EmlakTakipDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<City> Cities { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<EstateType> EstateTypes { get; set; }
        public DbSet<SaleType> SaleTypes { get; set; }
        public DbSet<Mahalle> Mahalles { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public EmlakTakipDbContext(DbContextOptions<EmlakTakipDbContext> options)
            : base(options)
        {
        }
    }
}
