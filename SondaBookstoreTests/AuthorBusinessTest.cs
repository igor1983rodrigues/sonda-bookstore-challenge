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

namespace SondaBookstoreTests
{
    public class AuthorBusinessTest
    {
        private readonly IAuthorBusiness business;

        public AuthorBusinessTest()
        {
            business = GenerateBusiness();

        }

        private static AuthorBusiness GenerateBusiness()
        {
            DbContextOptions<SondaBookstoreContext> option = new DbContextOptionsBuilder<SondaBookstoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            SondaBookstoreContext context = new SondaBookstoreContext(option);
            var repository = new AuthorRepository(context);

            return new AuthorBusiness(repository);
        }

        [Fact]
        public void AddNewAuthor()
        {
            Assert.Empty(business.FindAll());

            var author = new AuthorDto
            {
                Name = "Autor desconhecido"
            };

            author.Id = business.Create(author);
            Assert.NotEmpty(business.FindAll());

            Assert.True(author.Id > 0, "O autor não foi criado");
            Assert.Throws<BusinessException>(() => business.Create(author));
            Assert.Throws<BusinessException>(() => business.Create(null));
            Assert.Throws<BusinessException>(() => business.Create(new AuthorDto()));
        }

        [Fact]
        public void UpdateAuthor()
        {
            int id = business.Create(new AuthorDto
            {
                Name = "Autor desconhecido"
            });

            const string authorName = "Autor desconhecido 2";
            var author = business.Update(id, new AuthorDto { Name = authorName });
            Assert.NotNull(author);
            Assert.Equal(authorName, author.Name);

            Assert.Throws<BusinessException>(() => business.Update(0, author));
            Assert.Throws<BusinessException>(() => business.Update(id, null));
            Assert.Throws<BusinessException>(() => business.Update(int.MaxValue, author));
        }

        [Fact]
        public void DeleteAuthor()
        {
            int id = business.Create(new AuthorDto
            {
                Name = "Autor desconhecido"
            });

            var book = business.FindById(id);
            Assert.NotNull(book);
            Assert.Equal(id, book.Id);

            business.Delete(id);
            Assert.Throws<BusinessException>(() => business.FindById(id));
        }
    }
}
