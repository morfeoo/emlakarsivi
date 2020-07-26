using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using RemDijital.EmlakTakip.Controllers;
using RemDijital.EmlakTakip.Mahalles;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    public class MahallesController : EmlakTakipControllerBase
    {
        private readonly IMahalleAppService _etAppService;

        public MahallesController(IMahalleAppService etAppService)
        {
            _etAppService = etAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        //public async Task<ActionResult> EditModal(int roleId)
        //{
        //    var output = await _etAppService.GetEtDtoForEdit(new EntityDto(roleId));
        //    //var model = ObjectMapper.Map<EditEtModel>(output);
        //    //EditSaleTypeModel model = new EditSaleTypeModel();
        //    model.Id = output.Id;
        //    model.Name = output.Name;
        //    return PartialView("_EditModal", model);
        //}
    }
}
