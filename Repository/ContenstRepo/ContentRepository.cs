using Educa.Entities.ContentEntities;
using Microsoft.EntityFrameworkCore;

namespace Educa.Repository.ContenstRepo
{
    public class ContentRepository : IContentRepository
    {
        private readonly EducoDbContext educoDbContext;
        public ContentRepository(EducoDbContext educoDbContext)
        {
            this.educoDbContext = educoDbContext;
        }


        public Guid AddContent(Content content)
        {
            educoDbContext.Contents.Add(content);
            educoDbContext.SaveChanges();
            return content.ContentId;
        }

        public bool ContentExist(Guid Id)
        {
            return educoDbContext.Contents.Any(c =>c.ContentId == Id);
        }

        public IEnumerable<Content> GetAllContent()
        {
            return educoDbContext.Contents;
        }

        public PagedResult<Content> GetContent(int page, int pageSize)
        {
            return educoDbContext.Contents.OrderBy(c => c.ContentId).GetPaged(page, pageSize);
        }

        public Content? GetContentById(Guid Id)
        {
            return educoDbContext.Contents.FirstOrDefault(c => c.ContentId == Id);
        }

        public Guid UpdateContent(Content content)
        {
            educoDbContext.Contents.Update(content);
            educoDbContext.SaveChanges();
            return content.ContentId;
        }
    }
}
