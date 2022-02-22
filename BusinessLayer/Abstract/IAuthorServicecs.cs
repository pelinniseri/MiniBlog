using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorServicecs
    {
        List<Author> GetList();
        void AuthorAdd(Author author);
        Author GetByID(int id);
        void AuthorDelete(Author author);
        void AuthorUpdate(Author author);
    }
}
