using Abp.AspNetCore.Mvc.ViewComponents;

namespace RemDijital.EmlakTakip.Web.Views
{
    public abstract class EmlakTakipViewComponent : AbpViewComponent
    {
        protected EmlakTakipViewComponent()
        {
            LocalizationSourceName = EmlakTakipConsts.LocalizationSourceName;
        }
    }
}
