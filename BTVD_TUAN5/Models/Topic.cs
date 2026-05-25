using System.ComponentModel.DataAnnotations;

namespace BTVD_TUAN5.Models;

public class Topic
{
    public int TopicId { get; set; }

    [Required(ErrorMessage = "Tên chủ đề là bắt buộc")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên chủ đề từ 2 đến 100 ký tự")]
    public string Name { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
