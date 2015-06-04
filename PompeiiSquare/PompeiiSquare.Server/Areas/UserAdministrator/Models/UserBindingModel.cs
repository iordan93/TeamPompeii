using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Areas.UserAdministrator.Models
{
    public class UserBindingModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        [Required, Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Home city")]
        public string HomeCity { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}