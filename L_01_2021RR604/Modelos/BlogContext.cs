using Microsoft.EntityFrameworkCore;

namespace L_01_2021RR604.Modelos
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<calificaciones> Calificaciones { get;set; }
        public DbSet<Comentarios> Comentarios { get; set; } 

    }
}
