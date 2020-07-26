using Abp.Dependency;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Districts
{
    public class DistrictAppService : IDistrictAppService, ITransientDependency
    {
        private readonly IRepository<District, int> _repository;

        public DistrictAppService(IRepository<District, int> repository)
        {
            _repository = repository;
        }
        public async Task<List<District>> GetDistrictByCityId(int id)
        {
            return await _repository.GetAll().Where(x => x.CityId == id).OrderBy(x=>x.Name).ToListAsync();
            //return await _repository.GetAllIncluding(x => x.CityId == id).ToListAsync();
        }
        public async Task<List<District>> GetAllDistricts()
        {
            return await _repository.GetAllListAsync();
        }
    }
}
