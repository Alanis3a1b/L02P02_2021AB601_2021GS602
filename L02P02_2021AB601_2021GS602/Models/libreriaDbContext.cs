using Microsoft.EntityFrameworkCore;
using L02P02_2021AB601_2021GS602.Models;

namespace L02P02_2021AB601_2021GS602.Models
{
    public class libreriaDbContext:DbContext 
    {
        public libreriaDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Autores> autores { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<PedidoEncabezado> pedidoEncabezado { get; set; }
        public DbSet<PedidoDetalle> pedidoDetalle { get; set; }
        public DbSet<ComentariosLibros> comentariosLibros { get; set; }

    }
}
