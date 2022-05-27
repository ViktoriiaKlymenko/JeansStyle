using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Models.Filters
{
    public class PriceFilter
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
