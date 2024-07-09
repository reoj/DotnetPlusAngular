using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Controllers;

namespace Backend.Repositories
{
    public class TagRepository : ITagRepository
    {
        public ProductivAPIDbContext Db { get; }

        public TagRepository(ProductivAPIDbContext db)
        {
            this.Db = db;
        }
        public async Task<Tag> CreateTag(Tag tag)
        {
            await Db.Tags.AddAsync(tag);
            await Db.SaveChangesAsync();
            return tag;
        }

        public Task<Tag> DeleteTag(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetTag(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tag>> GetTags()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> UpdateTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
