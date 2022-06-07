using AutoMapper;
using JeansStyle.BLL.DTOs;
using JeansStyle.BLL.Interfaces;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using JeansStyle.DAL.Data.Specifications;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Services
{
    public class SizeService: ISizeService
    {
        private readonly IBaseRepository<Size> _sizeRepository;
        private readonly IMapper _mapper;
        public SizeService(IBaseRepository<Size> sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public List<SizeDto> GetAll()
        {
            return _mapper.Map<List<SizeDto>>(_sizeRepository.GetAll().OrderBy(s=>s.Name));
        }

        public async Task<SizeDto> GetById(Guid id)
        {
            var size = _mapper.Map<SizeDto>(await _sizeRepository.GetBySpecAsync(new SizeByIdSpec(id)));
            _sizeRepository.Clear();
            return size;
        }
    }
}
