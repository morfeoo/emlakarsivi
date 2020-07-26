using System.Collections.Generic;

namespace RemDijital.EmlakTakip.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
