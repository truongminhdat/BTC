using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
    public class SanPhamDao
    {
        private WebDbContext db = null;
        public SanPhamDao()
        {
            db = new WebDbContext();
        }
        public string Insert(SANPHAM entityUser)
        {
            db.SANPHAMs.Add(entityUser);
            db.SaveChanges();
            return entityUser.TENSP;
        }

        public List<SANPHAM> ListAll()
        {
            return db.SANPHAMs.ToList();
        }
        public SANPHAM Find(string TENSP)
        {

            return db.SANPHAMs.Find(TENSP);
        }
        public IEnumerable<SANPHAM> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<SANPHAM> model = db.SANPHAMs;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.TENSP.Contains(keysearch));
            }
            return model.OrderBy(x => x.TENSP).ToPagedList(page, pagesize);
        }
        public bool Delete(string MASP)
        {
            try
            {
                var user = db.SANPHAMs.Find(MASP);
                db.SANPHAMs.Remove(user);
                db.SaveChanges();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
    }
