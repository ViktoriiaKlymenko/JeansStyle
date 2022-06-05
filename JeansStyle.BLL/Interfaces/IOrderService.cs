using JeansStyle.BLL.DTOs;

namespace JeansStyle.BLL.Interfaces
{
    public interface IOrderService
    {
        void Create(OrderDto order);
    }
}