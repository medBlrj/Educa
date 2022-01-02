using Educa;
using Educa.Entities.ContentEntities;
using Educa.Entities.courseEntities;
using Educa.Entities.LevelEntities;
using Educa.Entities.QuestionsEntities;
using Educa.Entities.SubjectsEntities;
using Educa.Repository.Entities;
using Educa.Repository.Entities.QuestionsEntities.Enum;
using Microsoft.EntityFrameworkCore;

public class EducoDbContext : DbContext
{
    public EducoDbContext(DbContextOptions<EducoDbContext> options) : base(options)
    {
    }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Subject>  Subjects { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Content> Contents { get; set; }

}
