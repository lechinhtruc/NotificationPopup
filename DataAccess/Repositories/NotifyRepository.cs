using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class NotifyRepository : INotifyRepository
    {

        private readonly ApplicationDbContext _db;

        public NotifyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> CountUnredNotification()
        {
            return await _db.Tbl_Notify.CountAsync(x => x.IsRead == false && x.End_date < DateTime.Now);
        }

        public async Task<IEnumerable<NotificationModel>> GetAllNotification()
        {
            return await _db.Tbl_Notify.Where(x => x.End_date < DateTime.Now).ToListAsync();
        }
    }
}
