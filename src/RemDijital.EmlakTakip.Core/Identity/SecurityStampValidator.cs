using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using RemDijital.EmlakTakip.Authorization.Roles;
using RemDijital.EmlakTakip.Authorization.Users;
using RemDijital.EmlakTakip.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace RemDijital.EmlakTakip.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
