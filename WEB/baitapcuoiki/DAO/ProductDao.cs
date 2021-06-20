using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
    public class ProductDao
    {
        private Dbcontextweb db = null;
        public ProductDao()
        {
            db = new Dbcontextweb();
        }
        public string Insert(Product entityUser)
        {
            var user = Find(entityUser.ID);
            if (user == null)
            {
                db.Products.Add(entityUser);
            }
            else
            {
                user.ID = entityUser.ID;
                if (!String.IsNullOrEmpty(entityUser.Name))
                {
                    user.Name = entityUser.Name;
                }
                user.UnitCost = entityUser.UnitCost;
                user.Quantity = entityUser.Quantity;
                user.Description = entityUser.Description;
                user.Status = entityUser.Status;
                user.Image = entityUser.Image;
                user.CategoryID = entityUser.CategoryID;

                
            }
            db.SaveChanges();
            return entityUser.ID;
        }
        public Product Find(string Name)
        {      

            return db.Products.Find(Name);
        }

        public List<Product> ListAll()
        {

            return db.Products.OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
            
        }
        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
        public bool Delete(string name )
        {
            try
            {
                var user = db.Products.Find(name);
                db.Products.Remove(user);
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
