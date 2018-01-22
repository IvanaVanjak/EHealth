using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EHealth.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Insert your username.", AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Insert your password.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}