using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Models
{
    public class AddDoctorDto
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public Department Department { get; set; }
    }
}
