using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using RemDijital.EmlakTakip.Controllers;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : EmlakTakipControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
