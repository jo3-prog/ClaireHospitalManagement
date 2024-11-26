using HospitalInformationSystem.Models.Entities;

namespace HospitalInformationSystem.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<IEnumerable<Department>> GetDepartment(string search);
        Task<Department> GetByIdAsync(int id);
        bool Add(Department department);
        bool Update(Department department);
        bool Delete(Department department);
        bool Save();
    }
}
