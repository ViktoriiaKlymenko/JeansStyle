using JeansStyle.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.BLL.Interfaces
{
    public interface ISizeService
    {
        List<SizeDto> GetAll();
        Task<SizeDto> GetById(Guid id);
    }
}
