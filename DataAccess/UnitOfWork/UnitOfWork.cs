using DataAccess.Data;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public INotifyRepository Notify { get; }

        public UnitOfWork(ApplicationDbContext db, INotifyRepository notifyRepository)
        {
            _db = db;
            Notify = notifyRepository;
        }
    }
}
