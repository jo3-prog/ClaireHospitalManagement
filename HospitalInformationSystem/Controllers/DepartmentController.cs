using HospitalInformationSystem.Interfaces;
using HospitalInformationSystem.Models;
using HospitalInformationSystem.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        //Get Departments...
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            IEnumerable<Department> departments = await _departmentRepository.GetAllDepartments();
            return Ok(departments);
        }

        //Add Departments...
        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto addDepartment)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name = addDepartment.Name,
                    Description = addDepartment.Description
                };

                _departmentRepository.Add(department);
                return Ok(department);
            }
            else
            {
                ModelState.AddModelError("", "Failed to add Department");
            }
            return BadRequest(ModelState);
        }

        //Retrieving Doctor Details...
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> DepartmentDetails(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        //Editing Department Details...
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditDepartment(int id, EditDepartmentDto editDepartment)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                department.Name = editDepartment.Name;
                department.Description = editDepartment.Description;

                _departmentRepository.Update(department);
                return Ok(department);
            }
            else
            {
                ModelState.AddModelError("", "Failed to edit Department details");
            }
            return BadRequest(ModelState);
        }

        //Deleting Department...
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            else
            {
                _departmentRepository.Delete(department);
            }
            return Ok();
        }
    }
}
