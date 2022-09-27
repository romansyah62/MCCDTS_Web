using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Departemen
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
