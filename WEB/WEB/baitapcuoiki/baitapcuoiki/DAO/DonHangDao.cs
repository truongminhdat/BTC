using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
    public class DonHangDao
    {
        private WebDbContext db = null;
        public DonHangDao()
        {
            db = new WebDbContext();
        }
        public List<HOADON> ListAll()
        {
            return db.HOADONs.ToList();
        }
        public string Insert(HOADON entityHang)
        {
            var hang = Find(entityHang.SOHD);
            if (hang == null)
            {
                db.HOADONs.Add(entityHang);
            }
            else
            {
                hang.SOHD = entityHang.SOHD;
                if (!String.IsNullOrEmpty(entityHang.MAKH))
                {
                    hang.MAKH = entityHang.MAKH;
                }
            }
            db.SaveChanges();
            return entityHang.SOHD;
        }
        public IEnumerable<HOADON> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<HOADON> model = db.HOADONs;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.SOHD.Contains(keysearch));
            }
            return model.OrderBy(x => x.SOHD).ToPagedList(page, pagesize);
        }
        public HOADON Find(string SOHD)
        {

            return db.HOADONs.Find(SOHD);
        }
    }

}
