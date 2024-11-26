using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Models
{
    public class AddDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Doctor Doctor { get; set; }
    }
}
