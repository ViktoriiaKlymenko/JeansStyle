using JeansStyle.DAL.Domain.Models;
using System.Collections.Generic;

namespace JeansStyle.BLL.Models
{
    public class SearchResponse
    {
        public List<Product> Products {get;set;}
        public Config Config { get; set; }
    }
}
