using System.ComponentModel.DataAnnotations;

namespace APIDemo.Models
{
    public class Housedb
    {
        [Key]
        public Int64 Id { get; set; }
        public string Direccion { get; set; }
        public string Color { get; set; }
    }
}
