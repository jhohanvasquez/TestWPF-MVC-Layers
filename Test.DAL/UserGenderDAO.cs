using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test.BDO;
using System.Data.SqlClient;
using System.Configuration;

namespace Test.DAL
{
    public class UserGenderDAO
    {
        private BdTestEntities db = new BdTestEntities();
        public List<ListorDetailUserGenders_Result> ListUserGendersorDetailDao(int id)
        {
            return db.ListorDetailUserGenders(id).ToList();
        }
    }
}
