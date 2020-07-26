using Abp.AutoMapper;
using RemDijital.EmlakTakip.Roles.Dto;
using RemDijital.EmlakTakip.Web.Models.Common;

namespace RemDijital.EmlakTakip.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
