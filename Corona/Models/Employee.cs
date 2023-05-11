using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Employee
    {
        [Key]
        public string Id { get; set; } = default!;

        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        public string City { get; set; } = default!;

        [Required]
        public string Street { get; set; } = default!;

        public int BuildingNumber { get; set; }

        [Required]
        public DateTime? BirthDay { get; set; }

        [Required]
        public string TelephoneNumber { get; set; } = default!;

        [Required]
        public string MobileNumber { get; set; } = default!;

        [ForeignKey("CoronaDetails")]
        public int? CoronaDetailsId { get; set; }

        public CoronaDetails? CoronaDetails { get; set; }

        public ICollection<VaccineInfo>? VaccineInfos { get; set; }
    }
}
