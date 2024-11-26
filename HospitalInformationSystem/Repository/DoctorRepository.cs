using HospitalInformationSystem.Data;
using HospitalInformationSystem.Interfaces;
using HospitalInformationSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Doctor doctor)
        {
            _context.Add(doctor);
            return Save();
        }

        public bool Delete(Doctor doctor)
        {
            _context.Remove(doctor);
            return Save();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.Include(d => d.Department).ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(i => i.DoctorId == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctor(string search)
        {
            return await _context.Doctors.Where(d => d.Name.Contains(search)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Doctor doctor)
        {
            _context.Update(doctor);
            return Save();
        }
    }
}
