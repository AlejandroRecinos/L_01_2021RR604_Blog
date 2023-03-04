using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L_01_2021RR604.Modelos
{
    public class Usuarios
    {
        [Key]

        public int usuarioId { get; set; }
        public int rolId { get; set; }
        public string nombreUsuario { get; set;}
        public string clave { get;set; }
        public string nombre{ get; set;}
        public string apellido { get; set; }
    }
}
