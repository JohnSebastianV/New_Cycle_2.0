//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_Cycle_2._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public int ClienteID { get; set; }
        public int UsuarioID { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
