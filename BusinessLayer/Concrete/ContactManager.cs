using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> repocon = new Repository<Contact>();

        public int BLContactAdd(Contact c)
        {
            if(c.Mail=="" || c.Message==""|| c.Subject=="" || c.Name == "" || c.Surname == "" ||
                c.Mail.Length<=20 || c.Subject.Length <= 3)
            {
                return -1;
            }
            return repocon.Insert(c);
        }

        public List<Contact> GetAll()
        {
            
            return repocon.List();
        }
        public Contact GetContactDetails(int id)
        {
            return repocon.Find(x => x.ContactId == id);
        }   
    }
}
