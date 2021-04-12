using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test.BDO;
using Test.DAL;

namespace Test.Logic
{
    public class UserLogic
    {

        UserDAO _UserDAO = new UserDAO();
        public List<ListorDetailUser_Result> ListUserorDetailLogic(int id)
        {
            return _UserDAO.ListUserorDetailDao(id).ToList();
        }

        public TbUser InsertorUpdateUsertLogic(TbUser oUser, ref string message)
        {
            return _UserDAO.InsertorUpdateUsertDao(oUser, ref message);
        }

        public void DeleteUserLogic(int id, ref string message)
        {
            _UserDAO.DeleteUsertDao(id, ref message);
        }

    }
}