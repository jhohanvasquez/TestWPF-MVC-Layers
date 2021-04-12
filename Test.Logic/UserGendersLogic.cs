using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test.BDO;
using Test.DAL;

namespace Test.Logic
{
    public class UserGendersLogic
    {

        UserGenderDAO _UserGendersDAO = new UserGenderDAO();

        public List<ListorDetailUserGenders_Result> ListUserGendersorDetailLogic(int id)
        {
            return _UserGendersDAO.ListUserGendersorDetailDao(id);
        }

    }
}