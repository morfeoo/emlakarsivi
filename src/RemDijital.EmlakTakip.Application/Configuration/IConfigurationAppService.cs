using System.Threading.Tasks;
using RemDijital.EmlakTakip.Configuration.Dto;

namespace RemDijital.EmlakTakip.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
