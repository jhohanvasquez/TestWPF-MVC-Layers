using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


using Test.DataContracts;
using Test.FaultContracts;

namespace Test.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUserService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(UserFault))]
        List<UserGenders> GetUserGenders(int id);

        [OperationContract]
        [FaultContract(typeof(UserFault))]
        List<User> GetUserorDetails(int id);

        [OperationContract]
        [FaultContract(typeof(UserFault))]
        User RegisterOrSaveUserUsers(User User, ref string message);

        [OperationContract]
        string PrintUser(User User);

        [OperationContract]
        [FaultContract(typeof(UserFault))]
        void DeleteUser(int id, ref string message);
    }

}
