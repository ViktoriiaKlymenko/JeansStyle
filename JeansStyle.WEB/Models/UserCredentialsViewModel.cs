using System.ComponentModel.DataAnnotations;

namespace JeansStyle.WEB.Models
{
    public class UserCredentialsViewModel
    {
        [Required(ErrorMessage = "FirstNameError")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "MiddleNameError")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "LastNameError")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailError")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumberError")]
        [Display(Name = "PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9\\-/@#$%^&_+=() ]+", ErrorMessage = "InvalidPhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "AddressError")]
        [Display(Name = "Address")]
        [DataType(DataType.PhoneNumber)]
        public string Address { get; set; }
    }
}
