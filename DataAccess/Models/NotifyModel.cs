using System.ComponentModel.DataAnnotations;


namespace DataAccess.Models
{
    public class NotifyModel
    {
        [Key]
        public int Notify_Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập nội dung thông báo!")]
        public string? Msg { get; set; }

        [Required(ErrorMessage = "Hãy chọn kiểu thông báo!")]
        public string? Type { get; set; } = "Alarm";

        public DateTime Created_date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Hãy nhập thời gian thông báo sẽ hiển thị!")]
        public DateTime End_date { get; set; }

        public bool IsRead { get; set; } = false;
    }
}
