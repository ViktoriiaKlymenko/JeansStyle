using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;

namespace JeansStyle.BLL.Services
{
    public class OrderService: IOrderService
    {
        private readonly IBaseRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IBaseRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(OrderDto orderDto)
        {
            _repository.Add(_mapper.Map<Order>(orderDto));
        }
    }
}
