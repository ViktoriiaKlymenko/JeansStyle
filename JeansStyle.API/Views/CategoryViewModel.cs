using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JeansStyle.WEB.Views
{
    public class CategoryViewModel
    {
        [Display(Name = "Category")]
        public int SelectedId { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
    }
}
