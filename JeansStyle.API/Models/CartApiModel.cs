using JeansStyle.WEB.Models;

namespace JeansStyle.WEB.Controllers
{
    internal class CartApiModel
    {

        public Product Product { get; set; }
        public ProductSize ProductSize { get; set; }
        public int Amount { get; set; }
    }
}