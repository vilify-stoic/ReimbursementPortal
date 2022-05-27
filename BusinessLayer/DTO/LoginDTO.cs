using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email Required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }


        //[Required(ErrorMessage = "Password Required!")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password Address")]
        public string password { get; set; }

    }
}
