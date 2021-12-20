using Educa;
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
    public DbSet<Questions> Questions { get; set; }
    public DbSet<Subjects>  Subjects { get; set; }

}
