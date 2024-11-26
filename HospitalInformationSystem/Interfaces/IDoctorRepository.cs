using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<IEnumerable<Doctor>> GetDoctor(string search);
        Task<Doctor> GetByIdAsync(int Guid);
        bool Add(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Doctor doctor);
        bool Save();
    }
}
