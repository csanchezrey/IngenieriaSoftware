//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamo
    {
        public int codigoPrestamo { get; set; }
        public Nullable<int> usuario { get; set; }
        public string libro { get; set; }
        public System.DateTime fechaPrestamo { get; set; }
        public System.DateTime fechaVencimiento { get; set; }
        public Nullable<int> diasVencidos { get; set; }
    
        public virtual Libro Libro1 { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
