using AspNetRest.Data.Converter.Implementations;
using AspNetRest.Data.VO;
using AspNetRest.Model;
using AspNetRest.Repository;
using System.Collections.Generic;

namespace AspNetRest.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {

        private readonly IRepository<Books> _repository;

        private readonly BooksConverter _converter;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
            _converter = new BooksConverter();
        }

        public BooksVO Create(BooksVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BooksVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BooksVO Update(BooksVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
