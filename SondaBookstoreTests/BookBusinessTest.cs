using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SondaBookstoreApi.Business;
using SondaBookstoreApi.Business.Impl;
using SondaBookstoreApi.Helper;
using SondaBookstoreApi.Model;
using SondaBookstoreApi.Model.Dto;
using SondaBookstoreApi.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaBookstoreTests
{
    public class BookBusinessTest
    {
        private readonly IBookBusiness business;

        public BookBusinessTest()
        {
            business = GenerateBusiness();
            
        }

        private static BookBusiness GenerateBusiness()
        {
            DbContextOptions<SondaBookstoreContext> option = new DbContextOptionsBuilder<SondaBookstoreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            SondaBookstoreContext context = new SondaBookstoreContext(option);
            BookRepository repository = new BookRepository(context);
            
            return new BookBusiness(repository);
        }

        [Fact]
        public void AddNewBook()
        {
            Assert.Empty(business.FindAll());

            var book = new BookDto
            {
                Title = "Meu teste unitário",
                Edition = 1,
                Publisher = "Abril",
                PublishingYear = 2005,
            };

            book.Id = business.Create(book);
            Assert.NotEmpty(business.FindAll());

            Assert.True(book.Id > 0, "O livro não foi criado");
            Assert.Throws<BusinessException>(() => business.Create(book));
            Assert.Throws<BusinessException>(() => business.Create(new BookDto {
                Edition = 1,
                Publisher = "Abril",
                PublishingYear = 2005,
            }));
            Assert.Throws<BusinessException>(() => business.Create(new BookDto {
                Title = "Meu teste unitário v2",
                Edition = 0,
                Publisher = "Abril",
                PublishingYear = 2005,
            }));
            Assert.Throws<BusinessException>(() => business.Create(new BookDto {
                Title = "Meu teste unitário v2",
                Publisher = "Abril",
                PublishingYear = 2005,
            }));
            Assert.Throws<BusinessException>(() => business.Create(new BookDto {
                Title = "Meu teste unitário v2",
                Edition = 2,
                Publisher = "",
                PublishingYear = 2005,
            }));
            Assert.Throws<BusinessException>(() => business.Create(new BookDto {
                Title = "Meu teste unitário v2",
                Edition = 2,
                PublishingYear = 2005,
            }));
            Assert.Throws<BusinessException>(() => business.Create(new BookDto {
                Title = "Meu teste unitário v2",
                Edition = 2,
                Publisher = "",
                PublishingYear = 1,
            }));
        }

        [Fact]
        public void UpdateBook()
        {
            int id = business.Create(new BookDto {
                Title = "Meu teste unitário",
                Edition = 1,
                Publisher = "Abril",
                PublishingYear = 1943,
            });
            
            var book = business.Update(id, new BookDto { Title = "Meu teste unitário atualizado" });
            Assert.NotNull(book);

            book = business.Update(id, new BookDto { Edition = 2 });
            Assert.Equal(2, book.Edition);

            Assert.Throws<BusinessException>(() => business.Update(0, book));
            Assert.Throws<BusinessException>(() => business.Update(id, null));
            Assert.Throws<BusinessException>(() => business.Update(int.MaxValue, book));
        }

        [Fact]
        public void DeleteBook()
        {
            int id = business.Create(new BookDto
            {
                Title = "Meu teste unitário",
                Edition = 1,
                Publisher = "Abril",
                PublishingYear = 1943,
            });

            var book = business.FindById(id);
            Assert.NotNull(book);
            Assert.Equal(id, book.Id);

            business.Delete(id);
            Assert.Throws<BusinessException>(() => business.FindById(id));
        }
    }
}
