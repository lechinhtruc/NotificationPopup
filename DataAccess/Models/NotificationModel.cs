using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class NotificationModel
    {
        public int Notify_Id { get; set; }

        public string? Msg { get; set; }

        public string? Type { get; set; }

        public DateTime Created_date { get; set; }

        public DateTime End_date { get; set; }

        public bool IsRead { get; set; }
    }
}
