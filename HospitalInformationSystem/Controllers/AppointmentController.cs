using HospitalInformationSystem.Interfaces;
using HospitalInformationSystem.Models;
using HospitalInformationSystem.Models.Entities;
using HospitalInformationSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalInformationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentrepository;
        public AppointmentController(IAppointmentRepository appointmentrepository) 
        {
            _appointmentrepository = appointmentrepository;
        }

        //Get Appointments
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            IEnumerable<Appointment> appointments = await _appointmentrepository.GetAllAppointments();
            return Ok(appointments);
        }

        //Add Appointment
        [HttpPost]
        public IActionResult AddAppointment(AddAppointmentDto addAppointment)
        {
            if (ModelState.IsValid)
            {
                var Appointment = new Appointment()
                {
                   AppointmentDate = addAppointment.AppointmentDate,
                   Doctor = addAppointment.Doctor,
                   Patient = addAppointment.Patient,
                };

                _appointmentrepository.Add(Appointment);
                return Ok(Appointment);
            }
            else
            {
                ModelState.AddModelError("", "Failed to add Appointment");
            }
            return BadRequest(ModelState);
        }

        //Retrieving Appointment Details...
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> AppointmentDetails(int id)
        {
            var appointment = await _appointmentrepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        //Editing Appointment Details...
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditPatient(int id, EditAppointmentDto editAppointment)
        {
            var appointment = await _appointmentrepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid)
            {
                appointment.AppointmentDate = editAppointment.AppointmentDate;
                appointment.Patient = editAppointment.Patient;
                appointment.Doctor = editAppointment.Doctor;

                _appointmentrepository.Update(appointment);
                return Ok(appointment);
            }
            else
            {
                ModelState.AddModelError("", "Failed to edit appointment");
            }
            return BadRequest(ModelState);
        }


        //Deleting appointment...
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentrepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            else
            {
                _appointmentrepository.Delete(appointment);
            }
            return Ok();
        }
    }
}
