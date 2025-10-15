using Microsoft.AspNetCore.Mvc;
using Test_Santiagorestrepoarismendy.Data;
using Test_Santiagorestrepoarismendy.Models;

namespace Test_Santiagorestrepoarismendy.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Doctors
        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        // GET: /Doctors/Details/5
        public IActionResult Details(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // GET: /Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: /Doctors/Edit/id
        public IActionResult Edit(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: /Doctors/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: /Doctors/Delete/id
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: /Doctors/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
