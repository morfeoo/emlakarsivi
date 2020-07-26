using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RemDijital.EmlakTakip.Configuration;

namespace RemDijital.EmlakTakip.Web.Host.Startup
{
    [DependsOn(
       typeof(EmlakTakipWebCoreModule))]
    public class EmlakTakipWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EmlakTakipWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmlakTakipWebHostModule).GetAssembly());
        }
    }
}
