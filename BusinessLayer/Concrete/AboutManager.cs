using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoabout = new Repository<About>();

        public List<About> GetAll()
        {

            return repoabout.List();
        }
        public int UpdateAboutBM(About p)
        {
            About about = repoabout.Find(x => x.AboutId == p.AboutId);
            about.AboutContent = p.AboutContent;
            about.AboutContent2 = p.AboutContent2;
            about.AboutImage1 = p.AboutImage1;
            about.AboutId = p.AboutId;

            about.AboutImage2 = p.AboutImage2;
            return repoabout.Update(about);
        }
    }
}
