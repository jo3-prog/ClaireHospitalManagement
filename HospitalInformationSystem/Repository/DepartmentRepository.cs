using HospitalInformationSystem.Data;
using HospitalInformationSystem.Interfaces;
using HospitalInformationSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Department department)
        {
            _context.Add(department);
            return Save();
        }

        public bool Delete(Department department)
        {
            _context.Remove(department);
            return Save();
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(i => i.DepartmentId == id);
        }

        public async Task<IEnumerable<Department>> GetDepartment(string search)
        {
            return await _context.Departments.Where(d => d.Name.Contains(search)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Department department)
        {
            _context.Update(department);
            return Save();
        }
    }
}
