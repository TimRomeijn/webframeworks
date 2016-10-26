using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicRator_nologin_.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Display(Name ="Wachtwoord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}