using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PompeiiSquare.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public NotificationStatus Status { get; set; }
    }
}
