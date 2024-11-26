using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<IEnumerable<Patient>> GetPatient(string search);
        Task<Patient> GetByIdAsync(int id);
        bool Add(Patient patient);
        bool Update(Patient patient);
        bool Delete(Patient patient);
        bool Save();
    }
}
