using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Domain.Models;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class AdminService: IAdminService
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IMapper _mapper;

        public AdminService(IBaseRepository<Product> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Add(product);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Update(product);
        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Delete(product);
        }
    }
}
