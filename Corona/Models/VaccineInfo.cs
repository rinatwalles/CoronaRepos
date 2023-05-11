using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VaccineInfo
    {
        [Key]
        public int Id { get; set; }

        public DateTime VaccinationDate { get; set; }

        public string VaccineManufacture { get; set; } = default!;

        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
