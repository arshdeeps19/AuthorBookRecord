using System.Collections.Generic;
using Service_Layer.DTO;

namespace Service_Layer.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDTO> GetAllAuthors();
        AuthorDTO GetAuthorById(int id);
        void AddAuthor(AuthorDTO author);
        void UpdateAuthor(AuthorDTO author);
        void DeleteAuthor(int id);
    }
}
