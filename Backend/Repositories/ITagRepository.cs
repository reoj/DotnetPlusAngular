namespace Backend.Controllers
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();
        Task<Tag> GetTag(Guid id);
        Task<Tag> CreateTag(Tag tag);
        Task<Tag> UpdateTag(Tag tag);
        Task<Tag> DeleteTag(Guid id);
    }
}