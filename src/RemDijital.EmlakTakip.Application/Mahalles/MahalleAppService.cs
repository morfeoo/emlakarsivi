using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
using RemDijital.EmlakTakip.Mahalles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RemDijital.EmlakTakip.Mahalles
{
    public class MahalleAppService : AsyncCrudAppService<Mahalle, MahalleDto, int, GetMahalleInput>, IMahalleAppService
    {
        private readonly IAbpSession _session;
        public MahalleAppService(IRepository<Mahalle, int> repository, IAbpSession session) : base(repository)
        {
            _session = session;
        }
        public async Task<PagedResultDto<MahalleDto>> Filter(GetMahalleInput input)
        {
            try
            {
                var t = _session.GetTenantId();
                var a = await Repository.GetAllListAsync();
                var x = a.WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.Name.Contains(input.Keyword));
                var b = x.Skip(input.SkipCount).Take(input.MaxResultCount);
                return new PagedResultDto<MahalleDto>
                {
                    TotalCount = x.Count(),
                    Items = ObjectMapper.Map<List<MahalleDto>>(b)
                };
            }
            catch (Exception ex)
            {
                return new PagedResultDto<MahalleDto>
                {
                    TotalCount = 0,
                    Items = null
                };
            }
        }
        public async Task<bool> EtCreate(CreateMahalleDto input)
        {
            try
            {
                var et = new Mahalle
                {
                    CreationTime = Clock.Now,
                    CreatorUserId = _session.GetUserId(),
                    Name = input.Name
                };
                await Repository.InsertAsync(et);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> EtUpdate(MahalleDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                et.Name = input.Name;
                et.LastModificationTime = Clock.Now;
                et.LastModifierUserId = _session.GetUserId();
                await Repository.UpdateAsync(et);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<MahalleDto> GetEtDtoForEdit(EntityDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                return ObjectMapper.Map<MahalleDto>(et);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> EtDelete(EntityDto input)
        {
            try
            {
                var et = await Repository.GetAsync(input.Id);
                await Repository.DeleteAsync(et);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<Mahalle>> GetAllMahalles()
        {
            return await Repository.GetAllListAsync();
        }
        public async Task<List<Mahalle>> GetMahallesByDistrictId(int id)
        {
            return await Repository.GetAll().Where(x => x.DistrictId == id).OrderBy(x => x.Name).ToListAsync();
        }
        public Task<PagedResultDto<MahalleDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}
