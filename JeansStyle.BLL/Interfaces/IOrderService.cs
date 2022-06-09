using JeansStyle.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface IOrderService
    {
        void Create(OrderDto order);
        List<OrderDto> GetAll();
        Task Complete(Guid id);
    }
}