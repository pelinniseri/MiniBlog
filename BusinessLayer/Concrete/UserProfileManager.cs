using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repo = new Repository<Author>();
        Repository<Blog> repoUserBlog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repo.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoUserBlog.List(x => x.AuthorID == id);
        }
        public int EditAuthor(Author a)
        {
            Author author = repo.Find(x => x.AuthorID == a.AuthorID);
            author.AuthorName = a.AuthorName;
            author.AuthorTitle = a.AuthorTitle;
            author.AboutShort = a.AboutShort;
            author.AuthorAbout = a.AuthorAbout;
            author.Mail = a.Mail;
            author.Password = a.Password;
            author.PhoneNumber = a.PhoneNumber;

            return repo.Update(author);
        }
    }
}
