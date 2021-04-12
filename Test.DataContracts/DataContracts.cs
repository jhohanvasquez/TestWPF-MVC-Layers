using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Test.DataContracts
{
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "StoreDataContracts.ContractType".
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "StoreService.ContractType".
    [DataContract]
    public class User
    {
        #region Fields

        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public string NameUser { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public int IdGenderUser { get; set; }
        [DataMember]
        public string GenderDescription { get; set; }
        [DataMember]
        public string Sex { get; set; }

        #endregion // Fields


        #region Overrides
        //[OperationContract]
        public override string ToString()
        {
            return String.Format(
                "IdUser: " + this.IdUser + "\n" +
                "NameUser: " + this.NameUser + "\n" +
                "BirthDate: " + this.BirthDate + "\n" +
                "IdGenderUser: " + this.IdGenderUser + "\n" +
                "Sex: " + this.Sex + "\n");
        }

        #endregion // Overrides
    }

    [DataContract]
    public class UserGenders
    {
        #region Fields

        [DataMember]
        public int IdGenderUser { get; set; }
        [DataMember]
        public string GenderDescription { get; set; }

        #endregion // Fields
    }
}
