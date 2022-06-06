using JeansStyle.BLL.DTOs;
using System;
using System.Collections.Generic;

namespace JeansStyle.BLL.Interfaces
{
    public interface ISizeService
    {
        List<SizeDto> GetAll();
        SizeDto GetById(Guid id);
    }
}
