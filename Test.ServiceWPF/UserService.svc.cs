using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoMapper;

using Test.DataContracts;
using Test.Logic;
using Test.BDO;
using Test.FaultContracts;

namespace Test.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UserService" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UserService.svc o UserService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UserService : IUserService
    {
        #region Members

        //UserBDO _User;
        UserLogic _UserLogic = new UserLogic();

        //UserGendersBDO _UserGenders;
        UserGendersLogic _UserGendersLogic = new UserGendersLogic();

        #endregion // Members       

        #region Interface Implementations

        #region TbUserGenders
        public List<UserGenders> GetUserGenders(int id)
        {
            List<ListorDetailUserGenders_Result> UserGenderListBDO = null;
            try
            {
                UserGenderListBDO = _UserGendersLogic.ListUserGendersorDetailLogic(id);
            }

            catch (Exception err)
            {
                var msg = err.Message;
                var reason = "GetUserGenders Exception";
                throw new FaultException<UserFault>(new UserFault(msg), reason);
            }

            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ListorDetailUserGenders_Result, UserGenders>()
                );

            var mapper = new Mapper(config);

            List<UserGenders> oUserGendersList = new List<UserGenders>();

            foreach (var item in UserGenderListBDO)
            {
                oUserGendersList.Add(mapper.Map<UserGenders>(item));
            }

            return oUserGendersList;
        }

        #endregion

        #region TbUser
        public List<User> GetUserorDetails(int id)
        {
            List<ListorDetailUser_Result> UserListBDO = null;
            try
            {
                UserListBDO = _UserLogic.ListUserorDetailLogic(id);
            }

            catch (Exception err)
            {
                var msg = err.Message;
                var reason = "GetUser Exception";
                throw new FaultException<UserFault>(new UserFault(msg), reason);
            }

            if (UserListBDO == null)
            {
                var msg = String.Format("No User found for id {0}", id);
                var reason = "GetUser Empty User";
                if (id == 999)
                {
                    throw new Exception(msg);
                }
                else
                {
                    throw new FaultException<UserFault>(new UserFault(msg), reason);
                }
            }

            List<User> UserList = new List<User>();

            foreach (var itemUser in UserListBDO)
            {
                var User = new User();
                TranslateUserBDOToUserDTO(itemUser, User);
                UserList.Add(User);
            }

            return UserList;
        }

        public User RegisterOrSaveUserUsers(User User, ref string message)
        {
            TbUser result = null;
            User UserContract = null;

            //Initialize the mapper
            var configUserContract = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TbUser, User>()
                );

            if (string.IsNullOrEmpty(User.NameUser))
            {
                message = "User name cannot be empty";
            }
            else if (User.BirthDate == DateTime.MinValue)
            {
                message = "Quantity cannot be empty";
            }
            else
            {
                var UserBDO = new TbUser();
                TranslateUserDTOToUserBDO(User, UserBDO);

                try
                {

                    result = _UserLogic.InsertorUpdateUsertLogic(UserBDO, ref message);
                    var mapper = new Mapper(configUserContract);
                    UserContract = mapper.Map<User>(result);

                }
                catch (Exception err)
                {
                    var msg = err.Message;
                    var reason = "UpdateUser Exception";
                    throw new FaultException<UserFault>(new UserFault(msg), reason);
                }

            }
            return UserContract;
        }

        public string PrintUser(User User)
        {
            return User.ToString();
        }

        public void DeleteUser(int id, ref string message)
        {
            try
            {
                _UserLogic.DeleteUserLogic(id, ref message);
            }
            catch (Exception ex)
            {
                var msg = String.Format("Error deleting User for id {0}", id);
                throw new FaultException<UserFault>(new UserFault(msg), ex.Message);
            }

        }

        #endregion

        #endregion // Interface Implementations

        #region Private Helpers

        void TranslateUserBDOToUserDTO(ListorDetailUser_Result UserBDO, User User)
        {
            User.NameUser = UserBDO.NameUser;
            User.IdUser = UserBDO.IdUser;
            User.BirthDate = UserBDO.BirthDate;
            User.IdGenderUser = UserBDO.IdGenderUser;
            User.GenderDescription = UserBDO.GenderDescription;
            User.Sex = UserBDO.Sex;
        }

        void TranslateUserDTOToUserBDO(User User, TbUser UserBDO)
        {
            UserBDO.NameUser = User.NameUser;
            UserBDO.IdUser = User.IdUser;
            UserBDO.BirthDate = User.BirthDate;
            UserBDO.IdGenderUser = User.IdGenderUser;
            UserBDO.Sex = User.Sex;
        }

        #endregion // Private Helpers
    }
}
