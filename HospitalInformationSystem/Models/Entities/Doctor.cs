using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HospitalInformationSystem.Models.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
