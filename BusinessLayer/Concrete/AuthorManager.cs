using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoauth = new Repository<Author>();

        public List<Author> GetAll()
        {

            return repoauth.List();
        }

        public int AddAuthorBL(Author p)
        {
            if(p.AuthorName==""|| p.AboutShort == "" || p.AuthorTitle == "")
            {
                return -1;
            }
            return repoauth.Insert(p);
        }
        public Author FindAuthor(int id)
        {
            return repoauth.Find(x => x.AuthorID == id);
        }

        public int EditAuthor(Author a)
        {
            Author author = repoauth.Find(x => x.AuthorID == a.AuthorID);
            author.AuthorName = a.AuthorName;
            author.AuthorTitle = a.AuthorTitle;
            author.AboutShort = a.AboutShort;
            author.AuthorAbout = a.AuthorAbout;
            author.Mail = a.Mail;
            author.Password = a.Password;
            author.PhoneNumber = a.PhoneNumber;

            return repoauth.Update(author);
        }
    }
}
