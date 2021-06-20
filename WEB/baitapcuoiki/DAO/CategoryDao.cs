using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
    public class CategoryDao
    {
        private Dbcontextweb db = null;
        public CategoryDao()
        {
            db = new Dbcontextweb();
        }
        public string Insert(Category entityUser)
        {
            var user = Find(entityUser.CategoryID);
            if (user == null)
            {
                db.Categories.Add(entityUser);
            }
            else
            {
                user.CategoryID = entityUser.CategoryID;
                if (!String.IsNullOrEmpty(entityUser.Name))
                {
                    user.Name = entityUser.Name;
                }
                if (!String.IsNullOrEmpty(entityUser.Description))
                {
                    user.Description = entityUser.Description;
                }
            }
            db.SaveChanges();
            return entityUser.CategoryID;
        }
        public Category Find(string Name)
        {

            return db.Categories.Find(Name);
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Category> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public bool Delete(string ID)
        {
            try
            {
                var user = db.Categories.Find(ID);
                db.Categories.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       


    }
}

