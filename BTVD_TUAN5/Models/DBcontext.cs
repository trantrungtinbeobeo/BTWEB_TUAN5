using BTVD_TUAN5.Models;
using Microsoft.EntityFrameworkCore;

namespace BTVD_TUAN5.Models

{
    public class DBcontext : DbContext

    {
        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {
        }
       public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }


    }
}
