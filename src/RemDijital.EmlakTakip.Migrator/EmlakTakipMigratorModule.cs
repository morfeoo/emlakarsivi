using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RemDijital.EmlakTakip.Configuration;
using RemDijital.EmlakTakip.EntityFrameworkCore;
using RemDijital.EmlakTakip.Migrator.DependencyInjection;

namespace RemDijital.EmlakTakip.Migrator
{
    [DependsOn(typeof(EmlakTakipEntityFrameworkModule))]
    public class EmlakTakipMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public EmlakTakipMigratorModule(EmlakTakipEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(EmlakTakipMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                EmlakTakipConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmlakTakipMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
