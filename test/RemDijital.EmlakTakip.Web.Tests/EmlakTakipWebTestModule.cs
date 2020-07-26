using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RemDijital.EmlakTakip.EntityFrameworkCore;
using RemDijital.EmlakTakip.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace RemDijital.EmlakTakip.Web.Tests
{
    [DependsOn(
        typeof(EmlakTakipWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class EmlakTakipWebTestModule : AbpModule
    {
        public EmlakTakipWebTestModule(EmlakTakipEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmlakTakipWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(EmlakTakipWebMvcModule).Assembly);
        }
    }
}