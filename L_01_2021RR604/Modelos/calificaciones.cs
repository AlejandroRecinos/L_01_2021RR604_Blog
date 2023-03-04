using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L_01_2021RR604.Modelos
{
    public class calificaciones
    {
        [Key]
        public int calificacionId { get; set; }
        public int publicacionId { get; set; }
        public int usuarioId { get; set; }
        public int calificacion { get; set; }

    }
}