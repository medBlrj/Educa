using Educa.Entities.ContentEntities;

namespace Educa.Repository.ContenstRepo
{
    public interface IContentRepository
    {
        Guid AddContent(Content content);
        Content? GetContentById(Guid Id);
        IEnumerable<Content> GetAllContent();
        Guid UpdateContent(Content content);
        bool ContentExist(Guid Id);
        PagedResult<Content> GetContent(int page, int pageSize);
    }
}
