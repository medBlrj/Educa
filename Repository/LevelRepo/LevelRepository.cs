using Educa.Entities.LevelEntities;
using Microsoft.EntityFrameworkCore;

namespace Educa.Repository.LevelRepo
{
    public class LevelRepository : ILevelRepository
    {
        
        private readonly EducoDbContext educoDbContext;
        public LevelRepository(EducoDbContext educoDbContext)
        {
            this.educoDbContext = educoDbContext;
        }

        public Guid AddLevel(Level level)
        {
           educoDbContext.Levels.Add(level);
           educoDbContext.SaveChanges();
            return level.LevelId;
        }

        public IEnumerable<Level> GetAllLevel()
        {
            return educoDbContext.Levels;
        }

        public PagedResult<Level> GetLevel(int page, int pageSize)
        {
            return educoDbContext.Levels.Include(s => s.Subjects).OrderBy(l => l.LevelId).GetPaged(page, pageSize);
        }

        public Level? GetLevelById(Guid Id)
        {
            return educoDbContext.Levels.FirstOrDefault(l => l.LevelId == Id);
        }

        public bool LevelExist(Guid Id)
        {
            return educoDbContext.Levels.Any(l => l.LevelId == Id); 
        }

        public Guid UpdateLevel(Level level)
        {
            educoDbContext.Levels.Update(level);
            educoDbContext.SaveChanges();
            return level.LevelId;
        }
    }
}
