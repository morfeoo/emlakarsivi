using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
using RemDijital.EmlakTakip.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Estates
{
    public class EstateAppService : AsyncCrudAppService<Estate, EstateDto, int, GetEstateInput>, IEstateAppService
    {
        private readonly IAbpSession _session;
        public EstateAppService(IRepository<Estate, int> repository, IAbpSession session) : base(repository)
        {
            _session = session;
        }
        public async Task<int> GetEstateCount()
        {
            
            if (_session.TenantId == null)
            {
                return 0;
            } else
            {
                return await Repository.CountAsync(x => x.TenantId == _session.GetTenantId());
            }
        }
        public async Task<PagedResultDto<EstateDto>> Filter(GetEstateInput input)
        {
            try
            {
                var estates = await Repository.GetAll().Where(x => x.TenantId == _session.GetTenantId()).ToListAsync();
                //var estates = await Repository.GetAllIncluding(x => x.TenantId == _session.GetTenantId()).ToListAsync();
                if (!input.Keyword.IsNullOrWhiteSpace())
                    estates = estates.Where(x => x.Name.ToLower().Contains(input.Keyword.ToLower()) || x.Address.ToLower().Contains(input.Keyword.ToLower()) || x.Description.ToLower().Contains(input.Keyword.ToLower())).ToList();
                if (input.EstateTypeId != 0)
                    estates = estates.Where(x => x.EstateTypeId == input.EstateTypeId).ToList();
                if (input.SaleTypeId != 0)
                    estates = estates.Where(x => x.SaleTypeId == input.SaleTypeId).ToList();
                //foreach (var item in estates)
                //{
                //    var a = item.Price.ToString().Substring(0, item.Price.ToString().Length - 3);
                //    for (int i = 1; i < a.Length + 1; i++)
                //    {

                //    }
                //}
                foreach (var item in estates)
                {
                    if (_session.GetUserId() != item.CreatorUserId)
                    {
                        item.CreatorUserId = 0;
                    }
                }
                return new PagedResultDto<EstateDto>
                {
                    TotalCount = estates.Count(),
                    Items = ObjectMapper.Map<List<EstateDto>>(estates)
                };
            }
            catch (Exception ex)
            {
                return new PagedResultDto<EstateDto>
                {
                    TotalCount = 0,
                    Items = null
                };
            }
        }
        public async Task<bool> EstateAddOrEdit(Estate estate)
        {
            if (estate.Id == 0)
            {
                try
                {
                    var e = new Estate();
                    e = estate;
                    e.TenantId = _session.GetTenantId();
                    e.CreatorUserId = _session.GetUserId();
                    await Repository.InsertAsync(e);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    var e = await Repository.FirstOrDefaultAsync(x=>x.Id == estate.Id);
                    e.LastModificationTime = Clock.Now;
                    e.LastModifierUserId = _session.GetUserId();
                    e.Address = estate.Address;
                    e.CityId = estate.CityId;
                    e.Description = estate.Description;
                    e.DistrictId = estate.DistrictId;
                    e.EstateTypeId = estate.EstateTypeId;
                    e.MahalleId = estate.MahalleId;
                    e.Meter = estate.Meter;
                    e.Name = estate.Name;
                    e.Price = estate.Price;
                    e.TenantId = _session.GetTenantId();
                    await Repository.UpdateAsync(e);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                //return false;
            }
        }

        public async Task<Estate> GetEstateById(int id)
        {
            var estate = await Repository.GetAsync(id);
            return estate;
        }
        public Task<PagedResultDto<EstateDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}
