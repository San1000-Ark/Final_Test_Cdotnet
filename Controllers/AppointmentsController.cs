using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Santiagorestrepoarismendy.Data;
using Test_Santiagorestrepoarismendy.Models;
using System.Linq;

namespace Test_Santiagorestrepoarismendy.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _context;

        public AppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        private void LoadDropdowns(int? selectedPatientId = null, int? selectedDoctorId = null)
        {
            ViewBag.Patients = new SelectList(
                _context.Patients
                    .Select(p => new { p.Id, FullName = p.Name + " " + p.Lastname })
                    .ToList(),
                "Id",
                "FullName",
                selectedPatientId
            );

            ViewBag.Doctors = new SelectList(
                _context.Doctors
                    .Select(d => new { d.Id, FullName = d.Name + " " + d.LastName })
                    .ToList(),
                "Id",
                "FullName",
                selectedDoctorId
            );
        }

        public IActionResult Index()
        {
            var appointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToList();

            ViewData["Appointments"] = appointments;
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null) return NotFound();

            return View(appointment);
        }

        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            LoadDropdowns(appointment.PatientId, appointment.DoctorId);
            return View(appointment);
            
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return NotFound();

            LoadDropdowns(appointment.PatientId, appointment.DoctorId);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            LoadDropdowns(appointment.PatientId, appointment.DoctorId);
            return View(appointment);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null) return NotFound();

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        
        //SEE THE LIST OF THE APPOINTMENTS BY PATIENT
        // GET: Appointments/ByPatient/ID
        public IActionResult ByPatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null) return NotFound();

            var appointments = _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == id)
                .ToList();

            ViewData["Patient"] = patient;
            return View(appointments);
        }
        
        //SEE THE LIST OF THE APPOINTMENTS BY DOCTOR
        // GET: Appointments/ByDoctor/id
        public IActionResult ByDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return NotFound();

            var appointments = _context.Appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == id)
                .ToList();

            ViewData["Doctor"] = doctor;
            return View(appointments);
        }
    }
}