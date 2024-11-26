using HospitalInformationSystem.Data;
using HospitalInformationSystem.Interfaces;
using HospitalInformationSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Patient patient)
        {
            _context.Add(patient);
            return Save();
        }

        public bool Delete(Patient patient)
        {
            _context.Remove(patient);
            return Save();
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(i => i.PatientId == id);
        }

        public async Task<IEnumerable<Patient>> GetPatient(string search)
        {
            return await _context.Patients.Where(p => p.Name.Contains(search)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Patient patient)
        {
            _context.Update(patient);
            return Save();
        }
    }
}
