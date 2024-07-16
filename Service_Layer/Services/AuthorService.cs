using AutoMapper;
using Service_Layer.DTO;
using Domain_Layer.Interfaces;
using Domain_Layer.Models; // Assuming these are your EF models
using Service_Layer.Interfaces;
using System.Collections.Generic;

namespace Service_Layer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AuthorService()
        {
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            var authors = _unitOfWork.Authors.GetAll();
            return _mapper.Map<List<AuthorDTO>>(authors);
        }

        public AuthorDTO GetAuthorById(int id)
        {
            var author = _unitOfWork.Authors.GetById(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public void AddAuthor(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _unitOfWork.Authors.Insert(author);
            _unitOfWork.Save();
        }

        public void UpdateAuthor(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _unitOfWork.Authors.Update(author);
            _unitOfWork.Save();
        }

        public void DeleteAuthor(int id)
        {
            _unitOfWork.Authors.Delete(id);
            _unitOfWork.Save();
        }

       
    }
}
