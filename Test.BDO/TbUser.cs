//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.BDO
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbUser
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int IdGenderUser { get; set; }
        public string Sex { get; set; }
    
        public virtual TbUserGender TbUserGender { get; set; }
    }
}
