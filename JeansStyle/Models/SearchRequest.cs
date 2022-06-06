using System.ComponentModel.DataAnnotations;

namespace JeansStyle.WEB.Models
{
    public class SearchRequest
    {
        [StringLength(15, ErrorMessage = "Request cannot exceed 15 characters. ")]
        public string Request { get; set; }
    }
}