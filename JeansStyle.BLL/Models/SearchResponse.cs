using JeansStyle.BLL.DTOs;
using System.Collections.Generic;

namespace JeansStyle.BLL.Models
{
    public class SearchResponse
    {
        public List<ProductDto> Products {get;set;}
        public Config Config { get; set; }
    }
}
