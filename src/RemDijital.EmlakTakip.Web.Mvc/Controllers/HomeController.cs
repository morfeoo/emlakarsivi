using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using RemDijital.EmlakTakip.Controllers;
using RemDijital.EmlakTakip.Estates;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : EmlakTakipControllerBase
    {
        private readonly IEstateAppService _estateAppService;

        public HomeController(IEstateAppService estateAppService)
        {
            _estateAppService = estateAppService;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.EstateCount = await _estateAppService.GetEstateCount();
            return View();
        }
    }
}
