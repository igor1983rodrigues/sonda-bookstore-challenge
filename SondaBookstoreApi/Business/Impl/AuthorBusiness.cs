using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;
using SondaBookstoreApi.Model.Entity;
using SondaBookstoreApi.Model.Repository;

namespace SondaBookstoreApi.Business.Impl
{
    public class AuthorBusiness : IAuthorBusiness
    {
        private readonly IAuthorRepository repository;

        public AuthorBusiness(IAuthorRepository repository) {
            this.repository = repository;
        }

        private AuthorDto convertToDto(Author entity)
        {
            return new AuthorDto {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private Author convertToEntity(AuthorDto dto)
        {
            return new Author
            {
                Id = dto.Id ?? 0,
                Name = dto.Name
            };
        }

        public int Create(AuthorDto dto)
        {
            if (dto == null)
            {
                throw new BusinessException("Não há informações a inserir");
            }

            if (dto.Id.HasValue  && dto.Id.Value > 0)
            {
                throw new BusinessException("O author que desejas inserir já existe.");
            }

            if (string.IsNullOrEmpty(dto.Name))
            {
                throw new BusinessException("Nome é um campo obrigatório.");
            }

            Author author = convertToEntity(dto);

            return repository.Save(author);
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new BusinessException("Id inválido");
            }

            Author author = repository.FindById(id);
            if (author == null)
            {
                throw new BusinessException("Autor não encontrado.");
            }

            repository.Delete(author);
        }

        public IEnumerable<AuthorDto> FindAll()
        {
            return repository.FindAll().Select(entity => convertToDto(entity));
        }

        public AuthorDto FindById(int id)
        {
            Author author = repository.FindById(id);
            if (author == null)
            {
                throw new BusinessException("Nenhum autor foi encontrado");
            }
            
            return convertToDto(author);
        }

        public AuthorDto Update(int id, AuthorDto dto)
        {
            if (id <= 0)
            {
                throw new BusinessException("Id inválido.");
            }

            if (dto == null)
            {
                throw new BusinessException("Nenhuma informação a ser atualizada.");
            }

            Author author = repository.FindById(id);
            if (author == null)
            {
                throw new BusinessException("Autor não encontrado.");
            }

            if (!string.IsNullOrEmpty(dto.Name))
            {
                author.Name = dto.Name;
            }

            repository.Save(author);

            return convertToDto(author);
        }
    }
}
