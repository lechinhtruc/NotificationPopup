using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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
            return await _db.Tbl_Notify.CountAsync(x => x.IsRead == false && x.End_date <= DateTime.Now);
        }

        public async Task<NotifyModel> CreateNotification(NotifyModel notify)
        {
            NotifyModel notifi = new()
            {
                Msg = notify.Msg,
                Type = notify.Type,
                Created_date = DateTime.Now,
                End_date = notify.End_date,
                IsRead = false
            };
            await _db.Tbl_Notify.AddAsync(notifi);
            await _db.SaveChangesAsync();
            return notifi;
        }

        public async Task<IEnumerable<NotifyModel>> GetAllNotification()
        {
            return await _db.Tbl_Notify.Where(x => x.End_date <= DateTime.Now).OrderByDescending(x => x.Created_date).ToListAsync();
        }

        public async Task ReadNotification()
        {
            var notify = await _db.Tbl_Notify.Where(x => x.IsRead == false).ToListAsync();
            notify.ForEach(m => m.IsRead = true);
            await _db.SaveChangesAsync();
        }
    }
}
