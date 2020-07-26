using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RemDijital.EmlakTakip.Authorization;

namespace RemDijital.EmlakTakip
{
    [DependsOn(
        typeof(EmlakTakipCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EmlakTakipApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EmlakTakipAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EmlakTakipApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
