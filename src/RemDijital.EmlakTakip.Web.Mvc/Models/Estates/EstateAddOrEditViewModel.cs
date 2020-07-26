using RemDijital.EmlakTakip.Cities;
using RemDijital.EmlakTakip.Districts;
using RemDijital.EmlakTakip.Estates;
using RemDijital.EmlakTakip.EstateTypes;
using RemDijital.EmlakTakip.Mahalles;
using RemDijital.EmlakTakip.SaleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Web.Models.Estates
{
    public class EstateAddOrEditViewModel
    {
        public Estate estate { get; set; }
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
        public List<Mahalle> Mahalles { get; set; }
        public List<EstateType> EstateTypes { get; set; }
        public List<SaleType> SaleTypes { get; set; }
    }
}
