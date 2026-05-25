using Microsoft.EntityFrameworkCore;

namespace BTVD_TUAN5.Models;

public class DBcontext : DbContext
{
    public DBcontext(DbContextOptions<DBcontext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Topic> Topics => Set<Topic>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Topic>().HasData(
            new Topic { TopicId = 1, Name = "Cuộc sống" },
            new Topic { TopicId = 2, Name = "Lập trình" },
            new Topic { TopicId = 3, Name = "Sức khỏe" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, Title = "Sống tích cực", Author = "Nguyễn A", Price = 99000, Quantity = 5, TopicId = 1, ImageFileName = "song-tich-cuc.jpg" },
            new Book { BookId = 2, Title = "Kỹ năng giao tiếp", Author = "Trần B", Price = 120000, Quantity = 3, TopicId = 1, ImageFileName = "ky-nang-giao-tiep.jpg" },
            new Book { BookId = 3, Title = "ASP.NET Core cơ bản", Author = "Lê C", Price = 200000, Quantity = 6, TopicId = 2, ImageFileName = "aspnet-core.jpg" },
            new Book { BookId = 4, Title = "C# nâng cao", Author = "Phạm D", Price = 250000, Quantity = 4, TopicId = 2, ImageFileName = "csharp-nang-cao.jpg" }
        );
    }
}
