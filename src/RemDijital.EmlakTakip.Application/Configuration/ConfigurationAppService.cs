using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using RemDijital.EmlakTakip.Configuration.Dto;

namespace RemDijital.EmlakTakip.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EmlakTakipAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
