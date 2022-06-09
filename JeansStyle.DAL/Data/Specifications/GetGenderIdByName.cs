using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;

namespace JeansStyle.BLL.Services
{
    public class GetGenderIdByName : Specification<Gender>
    {
        public GetGenderIdByName(string gender)
        {
            if (!(string.IsNullOrEmpty(gender)))
                Query.Where(g => g.Name == gender);
        }
    }
}