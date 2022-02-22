using JeansStyle.API.Models;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Models
{
    public class SearchResponse
    {
        public List<Product> Products {get;set;}
        public Config Config { get; set; }
    }
}
