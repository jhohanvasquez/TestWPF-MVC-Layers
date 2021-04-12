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
    public class UserDAO
    {


        private BdTestEntities db = new BdTestEntities();
        public List<ListorDetailUser_Result> ListUserorDetailDao(int id)
        {
            return db.ListorDetailUser(id).ToList();
        }

        public TbUser InsertorUpdateUsertDao(TbUser oUser, ref string message)
        {
            message = "user updated successfully";
            try
            {
                return db.RegisterOrSaveUserUsers(oUser.IdUser, oUser.NameUser, oUser.BirthDate, oUser.IdGenderUser, oUser.Sex).FirstOrDefault();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }
        }

        public void DeleteUsertDao(int id, ref string message)
        {
            try
            {
                db.DeleteUser(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }

        }
    }
}
