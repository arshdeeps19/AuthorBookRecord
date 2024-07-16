using Domain_Layer.Models;

namespace Domain_Layer.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {   
        Author GetAuthorWithBooks(int authorId);
    }
}
