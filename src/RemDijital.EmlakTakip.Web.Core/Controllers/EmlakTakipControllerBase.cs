using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace RemDijital.EmlakTakip.Controllers
{
    public abstract class EmlakTakipControllerBase: AbpController
    {
        protected EmlakTakipControllerBase()
        {
            LocalizationSourceName = EmlakTakipConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
