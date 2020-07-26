using System.Collections.Generic;
using RemDijital.EmlakTakip.Roles.Dto;

namespace RemDijital.EmlakTakip.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
