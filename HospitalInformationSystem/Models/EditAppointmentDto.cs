using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Models
{
    public class EditAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
