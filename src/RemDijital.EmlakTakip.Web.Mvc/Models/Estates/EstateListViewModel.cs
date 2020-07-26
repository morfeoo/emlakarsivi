using Microsoft.AspNetCore.Mvc.Rendering;
using RemDijital.EmlakTakip.Cities;
using RemDijital.EmlakTakip.Districts;
using RemDijital.EmlakTakip.Mahalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemDijital.EmlakTakip.Web.Models.Estates
{
    public class EstateListViewModel
    {
        //public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> EstateTypes { get; set; }
        public List<SelectListItem> SaleTypes { get; set; }
        //public List<City> Cities { get; set; }
        //public List<District> Districts { get; set; }
        //public List<Mahalle> Mahalles { get; set; }
    }
}
