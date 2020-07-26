using Abp.Application.Services;
using RemDijital.EmlakTakip.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Estates
{
    public interface IEstateAppService : IAsyncCrudAppService<EstateDto>
    {
        Task<bool> EstateAddOrEdit(Estate estate);
        Task<Estate> GetEstateById(int id);
        Task<int> GetEstateCount();
    }
}
