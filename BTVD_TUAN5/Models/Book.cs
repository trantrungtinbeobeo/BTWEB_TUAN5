using System.ComponentModel.DataAnnotations;

namespace BTVD_TUAN5.Models;

public class Book
{
    public int BookId { get; set; }

    [Required(ErrorMessage = "Tên sách là bắt buộc")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Tên sách từ 2 đến 200 ký tự")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tác giả là bắt buộc")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "Tác giả từ 2 đến 120 ký tự")]
    public string Author { get; set; } = string.Empty;

    [Range(1, 10000000, ErrorMessage = "Giá sách phải lớn hơn 0")]
    public decimal Price { get; set; }

    [Range(1, 10000, ErrorMessage = "Số lượng phải lớn hơn 0")]
    public int Quantity { get; set; }

    [StringLength(255, ErrorMessage = "Tên file ảnh tối đa 255 ký tự")]
    public string? ImageFileName { get; set; }

    [Required(ErrorMessage = "Chủ đề là bắt buộc")]
    public int TopicId { get; set; }

    public Topic? Topic { get; set; }
}
