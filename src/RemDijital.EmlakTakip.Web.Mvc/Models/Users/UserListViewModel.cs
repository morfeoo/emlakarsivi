using System.Collections.Generic;
using RemDijital.EmlakTakip.Roles.Dto;

namespace RemDijital.EmlakTakip.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
