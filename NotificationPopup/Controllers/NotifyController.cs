using DataAccess.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotificationPopup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public NotifyController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public Task<IEnumerable<NotificationModel>> GetAll()
        {
            return _unitOfWork.Notify.GetAllNotification();
        }

        [HttpGet]
        [Route("CountUnRead")]
        public Task<int> CountUnreadNotify()
        {
            return _unitOfWork.Notify.CountUnredNotification();
        }
    }
}
