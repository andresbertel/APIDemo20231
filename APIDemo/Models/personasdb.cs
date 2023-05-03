using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace APIDemo.Models
{
    public class Personasdb
    {

        [Key]
        public Int64 Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
    }
}
