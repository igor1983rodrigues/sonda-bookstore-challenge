using Microsoft.EntityFrameworkCore;
using SondaBookstoreApi.Business.Impl;
using SondaBookstoreApi.Business;
using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model.Dto;
using SondaBookstoreApi.Model.Repository;
using SondaBookstoreApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SondaBookstoreApi.Model.Entity;

namespace SondaBookstoreTests
{
    public class SubjectBusinessTest
    {
        private readonly ISubjectBusiness business;

        public SubjectBusinessTest()
        {
            business = GenerateBusiness();

        }

        private static ISubjectBusiness GenerateBusiness()
        {
            DbContextOptions<SondaBookstoreContext> option = new DbContextOptionsBuilder<SondaBookstoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            SondaBookstoreContext context = new SondaBookstoreContext(option);
            ISubjectRepository repository = new SubjectRepository(context);

            return new SubjectBusiness(repository);
        }

        [Fact]
        public void AddNewSubject()
        {
            Assert.Empty(business.FindAll());

            var subject = new SubjectDto
            {
                Description = "Testes unitários"
            };

            subject.Id = business.Create(subject);
            Assert.NotEmpty(business.FindAll());

            Assert.True(subject.Id > 0, "O assunto não foi criado");
            Assert.Throws<BusinessException>(() => business.Create(subject));
            Assert.Throws<BusinessException>(() => business.Create(null));
            Assert.Throws<BusinessException>(() => business.Create(new SubjectDto()));
            Assert.Throws<BusinessException>(() => business.Create(new SubjectDto { Description = string.Empty }));
        }

        [Fact]
        public void UpdateSubject()
        {
            int id = business.Create(new SubjectDto
            {
                Description = "Testes unitários"
            });

            const string description = "Teste unitário atualizado";
            var subject = business.Update(id, new SubjectDto { Description = description });
            Assert.NotNull(subject);
            Assert.Equal(description, subject.Description);

            Assert.Throws<BusinessException>(() => business.Update(0, subject));
            Assert.Throws<BusinessException>(() => business.Update(id, null));
            Assert.Throws<BusinessException>(() => business.Update(int.MaxValue, subject));
        }

        [Fact]
        public void DeleteSubject()
        {
            int id = business.Create(new SubjectDto
            {
                Description = "Testes unitários"
            });

            var subject = business.FindById(id);
            Assert.NotNull(subject);
            Assert.Equal(id, subject.Id);

            business.Delete(id);
            Assert.Throws<BusinessException>(() => business.FindById(id));
        }
    }
}
