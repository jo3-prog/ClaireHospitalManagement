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
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        //Get Patients...
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            IEnumerable<Patient> patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        //Add Patients...
        [HttpPost]
        public IActionResult AddPatient(AddPatientDto addPatient)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient()
                {
                    Name = addPatient.Name,
                    Phone = addPatient.Phone,
                    Email = addPatient.Email,
                    Gender = addPatient.Gender,
                    DateOfBirth = addPatient.DateOfBirth,
                    Address = addPatient.Address,
                };

                _patientRepository.Add(patient);
                return Ok(patient);
            }
            else
            {
                ModelState.AddModelError("", "Failed to add Patient");
            }
            return BadRequest(ModelState);
        }

        //Retrieving Patient Details...
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> PatientDetails(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        //Editing Patient Details...
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditPatient(int id, EditPatientDto editPatient)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                patient.Name = editPatient.Name;
                patient.Phone = editPatient.Phone;
                patient.Email = editPatient.Email;
                patient.Gender = editPatient.Gender;
                patient.Address = editPatient.Address;
                patient.DateOfBirth = editPatient.DateOfBirth;

                _patientRepository.Update(patient);
                return Ok(patient);
            }
            else
            {
                ModelState.AddModelError("", "Failed to edit patient");
            }
            return BadRequest(ModelState);
        }

        //Deleting patient...
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                _patientRepository.Delete(patient);
            }
            return Ok();
        }
    }
}
