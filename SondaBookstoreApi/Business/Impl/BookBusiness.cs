using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;
using SondaBookstoreApi.Model.Entity;
using SondaBookstoreApi.Model.Repository;

namespace SondaBookstoreApi.Business.Impl
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository repository;

        public BookBusiness(IBookRepository repository) => this.repository = repository;

        private BookDto convertToDto(Book entity)
        {
            return new BookDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Publisher = entity.Publisher,
                Edition = entity.Edition,
                PublishingYear = entity.PublishingYear
            };
        }

        private Book convertToEntity(BookDto dto)
        {
            return new Book
            {
                Id = dto.Id ?? 0,
                Title = dto.Title,
                Publisher = dto.Publisher,
                Edition = dto.Edition,
                PublishingYear = dto.PublishingYear
            };
        }

        public int Create(BookDto dto)
        {
            if (dto.Id.HasValue && dto.Id.Value > 0)
            {
                throw new BusinessException("Este livro não pode ser inserido.");
            }

            if (string.IsNullOrEmpty(dto.Title))
            {
                throw new BusinessException("Título do livro é um campo obrigatório.");
            }

            if (string.IsNullOrEmpty(dto.Publisher))
            {
                throw new BusinessException("Editora do livro é um campo obrigatório.");
            }

            if (dto.Edition <= 0)
            {
                throw new BusinessException("A edição do livro precisa ser um ou superior.");
            }

            if (dto.PublishingYear < 1200)
            {
                throw new BusinessException("Ano de publicação do livro é inválido.");
            }

            Book book = convertToEntity(dto);

            return repository.Save(book);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new BusinessException("Id inválido.");
            }

            Book book = repository.FindById(id);
            if (book == null)
            {
                throw new BusinessException("Livro não existente.");
            }

            repository.Delete(book);
        }

        public IEnumerable<BookDto> FindAll()
        {
            return repository.FindAll().Select(convertToDto);

        }

        public BookDto FindById(int id)
        {
            return convertToDto(repository.FindById(id));
        }

        public BookDto Update(int id, BookDto dto)
        {
            if (id <= 0)
            {
                throw new BusinessException("Id inválido.");
            }

            if (dto == null)
            {
                throw new BusinessException("Nenhuma informação a ser atualizada.");
            }

            Book book = repository.FindById(id);
            if (book == null)
            {
                throw new BusinessException("Livro não encontrado.");
            }

            if (!string.IsNullOrEmpty(dto.Title))
            {
                book.Title = dto.Title;
            }

            if (!string.IsNullOrEmpty(dto.Publisher))
            {
                book.Publisher = dto.Publisher;
            }

            if (dto.Edition > 0)
            {
                book.Edition = dto.Edition;
            }

            if (dto.PublishingYear > 1200)
            {
                book.PublishingYear = dto.PublishingYear;
            }

            repository.Save(book);

            return convertToDto(book);
        }
    }
}
