using System.ComponentModel.DataAnnotations;

namespace WebApiEscuela.Models
{
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
