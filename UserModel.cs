using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Models
{
    public class UserModel
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter your UserName")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter your email")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }


        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(([A-za-z]+[@]+[0-9]+))$", ErrorMessage = "Enter Password Types(abcd@123)")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter the 12 digit UIN Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Addhar Number.")]
        public long? AddharNo { get; set; }


        [Required(ErrorMessage = "Enter first(4)CherName And Last(4)AddharNum")]
        [StringLength(8, MinimumLength = 8)]
        [RegularExpression(@"^(([A-za-z]+[0-9]+))$")]
        public string CreateRefer { get; set; }


        [Required(ErrorMessage = "Please Chack Male / Female")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Please enter 1000 Amount")]
        [RegularExpression(@"^([0-1]{4})$", ErrorMessage = "Enter Amount:-1000.")]
        public long? Amount { get; set; }


        [Required(ErrorMessage = "Please enter the AdminReferCode")]
        [StringLength(8, MinimumLength = 8)]
        [RegularExpression(@"^(([A-za-z]+[0-9]+))$")]
        public string AdminReferCode { get; set; }


        [Required(ErrorMessage = "Please enter the Country")]
        public string Country { get; set; }


        [Required(ErrorMessage = "Please enter the State")]
        public string State { get; set; }


        [Required(ErrorMessage = "Please enter the City")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter the 10 digit Phone_No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invali Phone_No.")]
        public long? PhoneNo { get; set; }


        [Required(ErrorMessage = "Please enter the ImageTitle")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Please enter the ImagePath")]
        [NotMapped]
        public IFormFile ImageData { get; set; }

        public string FilePath { get; set; }
    }
}
