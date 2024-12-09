using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;
using SondaBookstoreApi.Model.Entity;
using SondaBookstoreApi.Model.Repository;

namespace SondaBookstoreApi.Business.Impl
{
    public class SubjectBusiness : ISubjectBusiness
    {
        private readonly ISubjectRepository repository;

        public SubjectBusiness(ISubjectRepository repository)
        {
            this.repository = repository;
        }

        private SubjectDto convertToDto(Subject entity)
        {
            return new SubjectDto
            {
                Id = entity.Id,
                Description = entity.Description
            };
        }

        private Subject convertToEntity(SubjectDto dto)
        {
            return new Subject
            {
                Id = dto.Id ?? 0,
                Description = dto.Description
            };
        }

        public int Create(SubjectDto dto)
        {
            if (dto == null)
            {
                throw new BusinessException("Informação inválida.");
            }
            
            if (dto.Id.HasValue && dto.Id.Value > 0)
            {
                throw new BusinessException("Este assunto não pode ser inserido.");
            }

            if (string.IsNullOrEmpty(dto.Description))
            {
                throw new BusinessException("A descrição do assunto é um campo obrigatório.");
            }

            Subject subject = convertToEntity(dto);

            return repository.Save(subject);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new BusinessException("Id inválido.");
            }

            Subject subject = repository.FindById(id);
            if (subject == null)
            {
                throw new BusinessException("Assunto não existente.");
            }

            repository.Delete(subject);
        }

        public IEnumerable<SubjectDto> FindAll()
        {
            return repository.FindAll().Select(convertToDto);

        }

        public SubjectDto FindById(int id)
        {
            return convertToDto(repository.FindById(id));
        }

        public SubjectDto Update(int id, SubjectDto dto)
        {
            if (id <= 0)
            {
                throw new BusinessException("Id inválido.");
            }

            if (dto == null)
            {
                throw new BusinessException("Nenhuma informação a ser atualizada.");
            }

            Subject subject = repository.FindById(id);
            if (subject == null)
            {
                throw new BusinessException("Assunto não encontrado.");
            }

            if (!string.IsNullOrEmpty(dto.Description))
            {
                subject.Description = dto.Description;
            }

            repository.Save(subject);

            return convertToDto(subject);
        }
    }
}
