using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCCDTS_Web.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string JenisKelamin { get; set; }
        public string NomorTelepon { get; set; }
        public string Agama { get; set; }
        public string Alamat { get; set; }

        public Departemen Departemen { get; set; }
        [ForeignKey("Departemen")]
        public int DepartemenId { get; set; }



    }
}
