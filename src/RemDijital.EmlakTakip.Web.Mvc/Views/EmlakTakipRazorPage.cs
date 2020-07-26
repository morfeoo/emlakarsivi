using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace RemDijital.EmlakTakip.Web.Views
{
    public abstract class EmlakTakipRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected EmlakTakipRazorPage()
        {
            LocalizationSourceName = EmlakTakipConsts.LocalizationSourceName;
        }
    }
}
