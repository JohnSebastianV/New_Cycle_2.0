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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Compras
    {
       
        [DisplayName("Numero de factura")]
        public int FacturaID { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [DisplayName("Producto")]
        public int ProductoID { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [DisplayName("Metodo de pago")]
        public int Metodo_de_pagoID { get; set; }
    
        public virtual Metodos_de_pago Metodos_de_pago { get; set; }
        public virtual Productos Productos { get; set; }
    }
}