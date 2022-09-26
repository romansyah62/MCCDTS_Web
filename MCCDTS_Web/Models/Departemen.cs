using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCCDTS_Web.Models
{
    public class Departemen
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }

    }
}
