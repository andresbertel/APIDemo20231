using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace APIDemo.Models
{
    public class Cardb
    {
        [Key]
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public string Placa { get; set; }
    }
}
