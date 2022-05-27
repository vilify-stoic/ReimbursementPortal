using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "Email Required!")]
        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password Address")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ReEnter Password Required!")]
        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.Password, ErrorMessage = "Invalid ReEnter Password Address")]
        public string ReEnterPassword { get; set; }

        [Required(ErrorMessage = "Full Name Required!")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = " Maximum character can be 25")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "PAN Number Required!")]
        [Column(TypeName = "varchar(10)")]
        [MaxLength(10, ErrorMessage = " Maximum character can be 10")]
        [MinLength(10, ErrorMessage = "Enter Correct Pan Number")]
        [RegularExpression(@"^([A-Z]{5}[0-9]{4}[A-Z]{1})", ErrorMessage = "Enter Valid Pan Number")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Bank Name Required!")]
        [Column(TypeName = "varchar(25)")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Account Number Required!")]
        [Column(TypeName = "varchar(15)")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Account number should have minimum 12 digits")]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Enter Valid Account Number")]
        [MinLength(12, ErrorMessage = "Account number should have Max 12 digits")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string isApprover { get; set; }
    }
}
