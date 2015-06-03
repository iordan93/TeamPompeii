using PompeiiSquare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Areas.Administrator.Models
{
    public class UserShowModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HomeCity { get; set; }

        public Gender Gender { get; set; }

        public virtual string Email { get; set; }
    }
}