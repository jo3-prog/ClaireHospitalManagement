using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<IEnumerable<Appointment>> GetAppointment(string search);
        Task<Appointment> GetByIdAsync(int id);
        bool Add(Appointment appointment);
        bool Update(Appointment appoinment);
        bool Delete(Appointment appointment);
        bool Save();
    }
}
