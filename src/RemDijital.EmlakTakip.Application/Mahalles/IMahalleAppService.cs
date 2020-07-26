using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RemDijital.EmlakTakip.Mahalles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Mahalles
{
    public interface IMahalleAppService : IAsyncCrudAppService<MahalleDto>
    {
        Task<List<Mahalle>> GetAllMahalles();
        Task<MahalleDto> GetEtDtoForEdit(EntityDto input);
        Task<List<Mahalle>> GetMahallesByDistrictId(int id);
    }
}
