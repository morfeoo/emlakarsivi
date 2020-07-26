using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RemDijital.EmlakTakip.Configuration;

namespace RemDijital.EmlakTakip.Web.Startup
{
    [DependsOn(typeof(EmlakTakipWebCoreModule))]
    public class EmlakTakipWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EmlakTakipWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<EmlakTakipNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmlakTakipWebMvcModule).GetAssembly());
        }
    }
}
