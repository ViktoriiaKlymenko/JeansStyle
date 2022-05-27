using JeansStyle.BLL.Models;
using JeansStyle.BLL.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class FilterService
    {
        public SearchResponse FilterProducts(SearchResponse response, Filters filters)
       {
            if (filters != null)
            {
                //response = response.Products.Where(p => p.Gender == filters.GenderFilter.Gender);

                response.Products = response.Products.Where(p => p.Price <= filters.PriceFilter.MaxPrice && p.Price <= filters.PriceFilter.MinPrice).ToList();
                //response.Products = response.Products.Where(p => p.Season.Contains(filters.SeasonFilter.Season));
                return response;
            }
            return response;
        }
    }
}
