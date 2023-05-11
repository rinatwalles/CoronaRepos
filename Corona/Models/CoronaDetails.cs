using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class CoronaDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public DateTime? InfectionDate { get; set; }

        public DateTime? InfectionRecoveryDate { get; set; }
    }
}
