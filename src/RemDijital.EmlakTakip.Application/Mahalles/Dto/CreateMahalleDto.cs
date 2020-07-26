using System;
using System.Collections.Generic;
using System.Text;

namespace RemDijital.EmlakTakip.Mahalles.Dto
{
    public class CreateMahalleDto
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
    }
}
