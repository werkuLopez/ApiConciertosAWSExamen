using ApiConciertosAWSExamen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiConciertosAWSExamen.Data
{
    public class ConciertosContext : DbContext
    {
        public ConciertosContext(DbContextOptions<ConciertosContext> options) : base(options) { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
