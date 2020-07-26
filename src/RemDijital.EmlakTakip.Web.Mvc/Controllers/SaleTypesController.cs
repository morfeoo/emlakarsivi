﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemDijital.EmlakTakip.Authorization;
using RemDijital.EmlakTakip.Controllers;
using RemDijital.EmlakTakip.SaleTypes;
using RemDijital.EmlakTakip.Web.Models.SaleTypes;

namespace RemDijital.EmlakTakip.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_SaleTypes)]
    public class SaleTypesController : EmlakTakipControllerBase
    {
        private readonly ISaleTypeAppService _etAppService;

        public SaleTypesController(ISaleTypeAppService etAppService)
        {
            _etAppService = etAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int roleId)
        {
            var output = await _etAppService.GetEtDtoForEdit(new EntityDto(roleId));
            //var model = ObjectMapper.Map<EditEtModel>(output);
            EditSaleTypeModel model = new EditSaleTypeModel();
            model.Id = output.Id;
            model.Name = output.Name;
            return PartialView("_EditModal", model);
        }
    }
}
