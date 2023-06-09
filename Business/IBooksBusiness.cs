﻿using AspNetRest.Data.VO;
using AspNetRest.Model;
using System.Collections.Generic;

namespace AspNetRest.Business
{
    public interface IBooksBusiness
    {
        BooksVO Create(BooksVO book);
        BooksVO FindByID(long id);
        List<BooksVO> FindAll();
        BooksVO Update(BooksVO book);
        void Delete(long id);
    }
}
