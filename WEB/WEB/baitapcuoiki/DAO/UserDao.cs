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
        private Dbcontextweb db = null;

        public UserDao()
        {
            db = new Dbcontextweb();
        }


        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName == user);
            if(result == null)
            {
                return 0;

            }
            else
            {
                if (result.Status == "blocked")
                {
                    return -1;
                }
                else
                {
                    if (result.Password == pass)
                        return 1;
                    else
                        return -2;
                }
            }
        }

        public string Insert(UserAccount entityUser)
        {
            var user = Find(entityUser.UserName);
            if(user == null)
            {
                db.UserAccounts.Add(entityUser);
            } 
            else
            {
                user.UserName = entityUser.UserName;
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
                if (!String.IsNullOrEmpty(entityUser.Status))
                {
                    user.Status = entityUser.Status;
                }


            }
            db.SaveChanges();
            return entityUser.UserName;
        }
       public UserAccount Find(string Username)
        {
            
            return db.UserAccounts.Find(Username);
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }
        public IEnumerable<UserAccount> ListWhereAll(string keysearch , int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UserName.Contains(keysearch));
            }
            return model.OrderBy(x=>x.UserName).ToPagedList(page,pagesize);
        }
        public bool Delete(string Username)
        {
            try
            {
                var user = db.UserAccounts.Find(Username);
                db.UserAccounts.Remove(user);
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
