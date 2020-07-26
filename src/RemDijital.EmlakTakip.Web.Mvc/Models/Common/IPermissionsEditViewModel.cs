using System.Collections.Generic;
using RemDijital.EmlakTakip.Roles.Dto;

namespace RemDijital.EmlakTakip.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}