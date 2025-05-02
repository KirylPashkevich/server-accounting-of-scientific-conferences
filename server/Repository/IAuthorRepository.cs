using server.Models;

namespace server.Repository
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        Task<Author> GetAuthorByIdAsync(int id, bool trackChanges);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
} 