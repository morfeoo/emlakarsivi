using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using RemDijital.EmlakTakip.Authorization.Users;
using RemDijital.EmlakTakip.Editions;

namespace RemDijital.EmlakTakip.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
