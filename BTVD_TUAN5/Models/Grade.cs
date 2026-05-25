using System.ComponentModel.DataAnnotations;

namespace BTVD_TUAN5.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        public string Gradename { get; set; }

        public List<Student> Students { get; set; }

    }
}
