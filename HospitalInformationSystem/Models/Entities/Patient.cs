namespace HospitalInformationSystem.Models.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
