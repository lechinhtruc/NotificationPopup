using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace NotificationPopup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotifyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<IEnumerable<NotifyModel>> GetAll()
        {
            return _unitOfWork.Notify.GetAllNotification();
        }

        [HttpGet]
        [Route("CountUnRead")]
        public Task<int> CountUnreadNotify()
        {
            return _unitOfWork.Notify.CountUnredNotification();
        }

        [HttpPut]
        [Route("ReadNotify")]
        public Task ReadNotification()
        {
            return _unitOfWork.Notify.ReadNotification();
        }

        [HttpPost]
        [Route("AddNotify")]
        public Task<NotifyModel> AddNotify(NotifyModel notify)
        {
            return _unitOfWork.Notify.CreateNotification(notify);
        }
    }
}
