using Microsoft.EntityFrameworkCore;

public class QuizContext : DbContext
{
    public DbSet<User> Usuarios { get; set; }

    public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Usuario");
    }
}
