using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Data.Specifications;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IBaseRepository<ProductSize> _productSizeRepository;
        private readonly IMapper _mapper;

        public OrderService(IBaseRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(OrderDto orderDto)
        {
            _repository.Add(_mapper.Map<Order>(orderDto));
           
            _repository.Clear();
        }

        public async Task Complete(Guid id)
        {

            var order = await _repository.GetBySpecAsync(new GetOrderByIdSpec(id));
            foreach(var productSize in order.ProductSizes)
            {
                var productSizeById = await _productSizeRepository.GetBySpecAsync(new ProductSizeByIdSpec(id));
                productSize.Amount -= productSizeById.Amount;
            }
            
           
            _productSizeRepository.UpdateRange(order.ProductSizes);
            _repository.Clear();
        }

        public List<OrderDto> GetAll()
        {
            var orders = _mapper.Map<List<OrderDto>>(_repository.GetAll());
            return orders;
        }
    }
}
