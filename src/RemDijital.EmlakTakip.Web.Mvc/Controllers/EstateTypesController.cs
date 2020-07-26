using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemDijital.EmlakTakip.Authorization;
using RemDijital.EmlakTakip.Controllers;
using RemDijital.EmlakTakip.EstateTypes;
using RemDijital.EmlakTakip.Web.Models.EstateTypes;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    //[AbpMvcAuthorize(PermissionNames.Pages_EstateTypes)]
    public class EstateTypesController : EmlakTakipControllerBase
    {
        private readonly IEstateTypeAppService _estateTypeAppService;

        public EstateTypesController(IEstateTypeAppService estateTypeAppService)
        {
            _estateTypeAppService = estateTypeAppService;
        }

        public ActionResult Index()
        {
            var model = new EstateTypeListViewModel();
            return View(model);
        }
    }
}
