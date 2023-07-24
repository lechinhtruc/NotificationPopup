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
        public Task<IEnumerable<NotifyModel>> GetAllNotification();

        public Task<NotifyModel> CreateNotification(NotifyModel notify);

        public Task<int> CountUnredNotification();

        public Task ReadNotification();

    }
}
