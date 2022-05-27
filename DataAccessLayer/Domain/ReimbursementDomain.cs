using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace DataAccessLayer.Domain
{
    public class ReimbursementDomain
    {
        [Key]
        public int ReimburementId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string ReimburementType { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        [RegularExpression(@"^[0-9]*(.[0-9]{0,2})?$", ErrorMessage = "Enter Number Only")]
        public string RequestedValue { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Currency { get; set; }


        //[Required]
        [NotMapped]
        public IFormFile Image { get; set; }

        //[Required]
        public string ImageUrl { get; set; }

        [Column(TypeName = "varchar(25)")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string RequestedBy { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string ReceiptAttached { get; set; } 

        [Column(TypeName = "varchar(10)")]
        public string ActiveStatus { get; set; } 

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [Column(TypeName = "varchar(35)")]
        public string ApprovedBy { get; set; }

        [Column(TypeName = "varchar(10)")]
        [RegularExpression(@"^[0-9]*(.[0-9]{0,2})?$", ErrorMessage = "Enter Number Only")]
        public string ApprovedAmount { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string InternalNote { get; set; }

    }
}
