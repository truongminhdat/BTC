using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
    public class UserDao
    {
        private WebDbContext db = null;

        public UserDao()
        {
            db = new WebDbContext();
        }


        public int login(string user, string pass)
        {
            var result = db.Users.SingleOrDefault(x => x.Username.Contains(user) && x.Password.Contains(pass));
            if(result == null)
            {
                return 0;

            }
            else
            {
                return 1;
            }
        }

        public string Insert(User entityUser)
        {
            var user = Find(entityUser.Username);
            if(user == null)
            {
                db.Users.Add(entityUser);
            } 
            else
            {
                user.Username = entityUser.Username;
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
            }
            db.SaveChanges();
            return entityUser.Username;
        }



       public User Find(string Username)
        {
            
            return db.Users.Find(Username);
        }

        public List<User> ListAll()
        {
            return db.Users.ToList();
        }


        public IEnumerable<User> ListWhereAll(string keysearch , int page, int pagesize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Username.Contains(keysearch));
            }
            return model.OrderBy(x=>x.Username).ToPagedList(page,pagesize);
        }
        public bool Delete(string Username)
        {
            try
            {
                var user = db.Users.Find(Username);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
       
    }
}
