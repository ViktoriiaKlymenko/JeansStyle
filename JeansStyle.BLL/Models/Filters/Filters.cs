using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Models.Filters
{
    public class Filters
    {
        public GenderFilter GenderFilter { get; set; }
        public SeasonFilter SeasonFilter { get; set; }
        public PriceFilter PriceFilter { get; set; }
    }
}
