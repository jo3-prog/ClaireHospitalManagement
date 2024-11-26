namespace HospitalInformationSystem.Models.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
