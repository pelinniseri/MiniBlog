using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();

        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public int CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" || p.CategoryDescription == "" || p.CategoryName.Length <= 4 || p.CategoryName.Length >= 30) 
            {
                return -1;
            }
            return repocategory.Insert(p);
        }
        public Category FindCategory(int id)
        {
            return repocategory.Find(x => x.CategoryID == id);
        }

        public int EditCategory(Category a)
        {
            Category category = repocategory.Find(x => x.CategoryID == a.CategoryID);
         
            if (a.CategoryName == "" || a.CategoryDescription == "" || a.CategoryName.Length <= 4 || a.CategoryName.Length >= 30)
            {
                return -1;
            }
            category.CategoryName = a.CategoryName;
            category.CategoryDescription = a.CategoryDescription;
            return repocategory.Update(category);
        }
        public int DeleteCategoryBL(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);

            category.Status = false;
            return repocategory.Update(category);
        }
        public int ActiveCategoryBL(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);

            category.Status = true;
            return repocategory.Update(category);
        }
     
    }
}
