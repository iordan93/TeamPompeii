using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PompeiiSquare.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Path { get; set; }

        public User Author { get; set; }
    }
}
