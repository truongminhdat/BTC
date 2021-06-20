using baitapcuoiki.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapcuoiki.DAO
{
    public class CTDHDao
    {
        private WebDbContext db = null;
        public CTDHDao()
        {
            db = new WebDbContext();
        }
        public List<CTHD> ListAll()
        {
            return db.CTHDs.ToList();
        }
      
    }
}
