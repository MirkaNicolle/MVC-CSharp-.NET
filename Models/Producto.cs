namespace MiProyectoWeb.Models
{
    public class Producto
    {
        string nombre;
        string precio;
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
