using Abp.MultiTenancy;
using RemDijital.EmlakTakip.Authorization.Users;

namespace RemDijital.EmlakTakip.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
