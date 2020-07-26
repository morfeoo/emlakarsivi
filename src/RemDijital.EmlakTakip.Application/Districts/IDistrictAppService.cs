using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Districts
{
    public interface IDistrictAppService
    {
        Task<List<District>> GetAllDistricts();
        Task<List<District>> GetDistrictByCityId(int id);
    }
}
