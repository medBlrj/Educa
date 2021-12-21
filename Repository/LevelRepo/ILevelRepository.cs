using Educa.Entities.LevelEntities;

namespace Educa.Repository.LevelRepo
{
    public interface ILevelRepository
    {
        Guid AddLevel(Level level);
        Level? GetLevelById(Guid Id);
        IEnumerable<Level> GetAllLevel();
        Guid UpdateLevel(Level level);
        bool LevelExist(Guid Id);
        PagedResult<Level> GetLevel(int page, int pageSize);
    }
}
