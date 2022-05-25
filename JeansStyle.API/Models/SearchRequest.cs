using System.ComponentModel.DataAnnotations;

namespace JeansStyle.API.Models
{
    public class SearchRequest
    {
        [Required(ErrorMessage = "Field Cannot be Blank Or Whitespace")]
        [StringLength(15, ErrorMessage = "Request cannot exceed 15 characters. ")]
        public string Request { get; set; }
    }
}