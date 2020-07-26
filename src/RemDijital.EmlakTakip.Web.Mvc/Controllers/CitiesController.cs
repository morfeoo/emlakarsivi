using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemDijital.EmlakTakip.Cities;
using RemDijital.EmlakTakip.Controllers;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    public class CitiesController : EmlakTakipControllerBase
    {
        private readonly ICityAppService _cs;

        public CitiesController(ICityAppService cs)
        {
            _cs = cs;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
