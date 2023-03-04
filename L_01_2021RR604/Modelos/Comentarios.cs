using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L_01_2021RR604.Modelos
{
    public class Comentarios
    {
        [Key]
        public int cometarioId { get; set; }
        public int publicacionId { get; set; }
        public string comentario { get; set; }
        public int usuarioId { get; set; }
    }
}