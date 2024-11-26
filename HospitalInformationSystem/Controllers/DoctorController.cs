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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        //Get Doctors...
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            IEnumerable<Doctor> doctors = await _doctorRepository.GetAllDoctors();
            return Ok(doctors);
        }

        //Add Doctors...
        [HttpPost]
        public IActionResult AddDoctor(AddDoctorDto addDoctor)
        {
            if (ModelState.IsValid)
            {
                var doctor = new Doctor()
                {
                    Name = addDoctor.Name,
                    Phone = addDoctor.Phone,
                    Email = addDoctor.Email,
                    Department = addDoctor.Department,
                };

                _doctorRepository.Add(doctor);
                return Ok(doctor);
            }
            else
            {
                ModelState.AddModelError("", "Failed to add doctor");
            }
            return BadRequest(ModelState);
        }

        //Retrieving Doctor Details... 
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> DoctorDetails(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        //Editing Doctor Details...
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditDoctor(int id, EditDoctorDto editDoctor)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                doctor.Name = editDoctor.Name;
                doctor.Phone = editDoctor.Phone;
                doctor.Email = editDoctor.Email;
                doctor.Department = editDoctor.Department;

                _doctorRepository.Update(doctor);
                return Ok(doctor);
            }
            else
            {
                ModelState.AddModelError("", "Failed to edit Doctor details");
            }
            return BadRequest(ModelState);
        }

        //Deleting Doctor...
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                _doctorRepository.Delete(doctor);
            }
            return Ok();
        }

    }
}
