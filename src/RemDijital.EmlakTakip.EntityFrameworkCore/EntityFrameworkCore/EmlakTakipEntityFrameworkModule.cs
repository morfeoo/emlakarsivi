using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using RemDijital.EmlakTakip.EntityFrameworkCore.Seed;

namespace RemDijital.EmlakTakip.EntityFrameworkCore
{
    [DependsOn(
        typeof(EmlakTakipCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class EmlakTakipEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<EmlakTakipDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        EmlakTakipDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        EmlakTakipDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmlakTakipEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
