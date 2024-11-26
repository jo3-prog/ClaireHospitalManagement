using HospitalInformationSystem.Data;
using HospitalInformationSystem.Interfaces;
using HospitalInformationSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return Save();
        }

        public bool Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            return Save();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointment(string search)
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(i => i.AppointmentId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Appointment appoinment)
        {
            _context.Appointments.Update(appoinment);
            return Save();
        }
    }
}
