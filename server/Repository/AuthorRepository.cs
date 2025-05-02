using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(a => a.Name)
                .ToListAsync();

        public async Task<Author> GetAuthorByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(a => a.AuthorId.Equals(id), trackChanges)
                .Include(a => a.Reports)
                .SingleOrDefaultAsync();

        public void CreateAuthor(Author author) => Create(author);

        public void UpdateAuthor(Author author) => Update(author);

        public void DeleteAuthor(Author author) => Delete(author);
    }
} 