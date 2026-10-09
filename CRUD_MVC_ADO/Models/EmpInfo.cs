using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_MVC_ADO.Models
{
    public class EmpInfo
    {
        [Key]
        public int EmpId { get; set; }

        [Required] 

        public string EmpName { get; set; }

        //[Required]
        //[RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Invalid E-Mail")] 
        //public string EmpEmail { get; set; }

        //[Required]
        //[RegularExpression("[6-9][0-9]{9}",ErrorMessage ="First digit should be 6 to 9 and number should be 10")]
        //public string EmpPhone { get; set; }

        [Required] 
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
    }
}