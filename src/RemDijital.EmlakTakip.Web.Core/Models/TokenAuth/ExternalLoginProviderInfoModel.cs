using Abp.AutoMapper;
using RemDijital.EmlakTakip.Authentication.External;

namespace RemDijital.EmlakTakip.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
