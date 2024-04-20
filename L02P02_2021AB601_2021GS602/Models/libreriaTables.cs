using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L02P02_2021AB601_2021GS602.Models
{
    public class libreriaTables
    {
    }

    public class Clientes
    {
        [Key]

        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? direccion { get; set; }
        public DateTime created_at { get; set; }
    }

    public class Autores
    {
        [Key]
        public int id { get; set; }
        public string? autor { get; set; }
    }

    public class Categorias
    {
        [Key]
        public int id { get; set; }
        public string? categoria { get; set; }
    }

    public class Libros
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? url_imagen { get; set; }
        public int id_autor { get; set; }
        public int id_categoria { get; set; }
        public decimal precio { get; set; }
        public char estado { get; set; }

    }

    public class PedidoEncabezado
    {
        [Key]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int cantidad_libros { get; set; }
        public decimal total { get; set; }
        public char estado { get; set; }
    }

    public class PedidoDetalle
    {
        [Key]
        public int id { get; set; }
        public int id_pedio { get; set; }
        public int id_libro { get; set; }
        public DateTime created_at { get; set; }
    }

    public class ComentariosLibros
    {
        [Key]
        public int id { get; set; }
        public int id_libro { get; set; }
        public string? comentarios { get; set; }
        public string? usuario { get; set; }
        public DateTime created_at { get; set; }
    }
         
}
