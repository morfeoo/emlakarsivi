using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RemDijital.EmlakTakip.Authorization;
using RemDijital.EmlakTakip.Cities;
using RemDijital.EmlakTakip.Controllers;
using RemDijital.EmlakTakip.Districts;
using RemDijital.EmlakTakip.Estates;
using RemDijital.EmlakTakip.Et;
using RemDijital.EmlakTakip.Mahalles;
using RemDijital.EmlakTakip.SaleTypes;
using RemDijital.EmlakTakip.Web.Models.Estates;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_EstateTypes)]
    public class EstateController : EmlakTakipControllerBase
    {
        private readonly IEstateAppService _estateAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IDistrictAppService _districtAppService;
        private readonly IMahalleAppService _mahalleAppService;
        private readonly IEtAppService _etAppService;
        private readonly ISaleTypeAppService _saleTypeAppService;

        public EstateController(IEstateAppService estateAppService,ICityAppService cityAppService, IEtAppService etAppService, ISaleTypeAppService saleTypeAppService,IDistrictAppService districtAppService,IMahalleAppService mahalleAppService)
        {
            _estateAppService = estateAppService;
            _cityAppService = cityAppService;
            _etAppService = etAppService;
            _saleTypeAppService = saleTypeAppService;
            _mahalleAppService = mahalleAppService;
            _districtAppService = districtAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new EstateListViewModel();
            var peopleSelectListItems = (await _etAppService.GetEstateTypeComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = "Kategori Seçiniz..", Selected = true });
            model.EstateTypes = peopleSelectListItems;
            var people2SelectListItems = (await _saleTypeAppService.GetCitiesSaleTypesComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            people2SelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = "Satış Tipi Seçiniz..", Selected = true });
            model.SaleTypes = people2SelectListItems;
            return View(model);
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            var model = new EstateAddOrEditViewModel();
            model.Cities = await _cityAppService.GetAllCities();
            model.EstateTypes = await _etAppService.GetAllEstateTypes();
            model.SaleTypes = await _saleTypeAppService.GetAllsaleTypes();
            if (id != null)
            {
                var e = await _estateAppService.GetEstateById(id.Value);
                model.Districts = await _districtAppService.GetDistrictByCityId(e.CityId);
                model.Mahalles = await _mahalleAppService.GetMahallesByDistrictId(e.DistrictId);
                model.estate = e;
                model.estate.Price = Convert.ToDecimal(e.Price.ToString().Substring(0,e.Price.ToString().Length -3));
                //model.estate.Price = Convert.ToDecimal(e.Price.ToString().Replace(',','.'));
            }
            //model.Districts = await _districtAppService.GetAllDistricts();
            //model.Mahalles = await _mahalleAppService.GetAllMahalles();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Estate estate)
        {
            var aa = await _estateAppService.EstateAddOrEdit(estate);
            return View();
        }
        public async Task<JsonResult> GetDistrict(int id)
        {
            var d = await _districtAppService.GetDistrictByCityId(id);
            return Json(d);
        }
        public async Task<JsonResult> GetMahalle(int id)
        {
            var d = await _mahalleAppService.GetMahallesByDistrictId(id);
            return Json(d);
        }

        public async Task<ActionResult> EditModal(int roleId)
        {
            //var output = await _etAppService.GetEtDtoForEdit(new EntityDto(roleId));
            ////var model = ObjectMapper.Map<EditEtModel>(output);
            //EditEtModel model = new EditEtModel();
            //model.Id = output.Id;
            //model.Name = output.Name;
            //return PartialView("_EditModal", model);
            return PartialView();
        }
    }
}
