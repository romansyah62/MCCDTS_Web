using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class Absensi
    {
        [Key]
        public int Id { get; set; }
        public DateTime Waktu { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Id")]
        public int EmployeeId { get; set; }
    }
}
