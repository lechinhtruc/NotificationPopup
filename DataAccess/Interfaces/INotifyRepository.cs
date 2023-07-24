using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface INotifyRepository
    {
        public Task<IEnumerable<NotificationModel>> GetAllNotification();

        public Task<int> CountUnredNotification();

    }
}
