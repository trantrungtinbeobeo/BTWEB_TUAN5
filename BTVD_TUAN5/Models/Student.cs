namespace BTVD_TUAN5.Models
{
    public class Student
    {
        public int studentid { get; set; }  
        public string fristname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;

        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
