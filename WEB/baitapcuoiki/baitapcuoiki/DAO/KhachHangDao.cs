using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
   public  class KhachHangDao
    {
        private WebDbContext db = null;
        public KhachHangDao()
        {
            db = new WebDbContext();
        }
        public string Insert(KHACHHANG entityHang)
        {
            var hang = Find(entityHang.MAKH);
           if(hang == null)
            {
                db.KHACHHANGs.Add(entityHang);
            }
           else
            {
                hang.MAKH = entityHang.MAKH;
                if (!String.IsNullOrEmpty(entityHang.TENKH))
                {
                    hang.TENKH = entityHang.TENKH;
                }
            }
            db.SaveChanges();
            return entityHang.MAKH;
        }
       
        public List<KHACHHANG> ListAll()
        {
            return db.KHACHHANGs.ToList();
        }
        public KHACHHANG Find(string TENKH)
        {

            return db.KHACHHANGs.Find(TENKH);
        }
        public IEnumerable<KHACHHANG> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<KHACHHANG> model = db.KHACHHANGs;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.TENKH.Contains(keysearch));
            }
            return model.OrderBy(x => x.TENKH).ToPagedList(page, pagesize);
        }
        public bool Delete(string MAKH)
        {
            try
            {
                var user = db.KHACHHANGs.Find(MAKH);
                db.KHACHHANGs.Remove(user);
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
