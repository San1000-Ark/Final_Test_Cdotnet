namespace Test_Santiagorestrepoarismendy.Controllers;
using Microsoft.AspNetCore.Mvc;
using Test_Santiagorestrepoarismendy.Data;
using Test_Santiagorestrepoarismendy.Models;
public class PatientsController : Controller
{
    private readonly AppDbContext _context;
    public PatientsController(AppDbContext context)
    {
        _context = context;
    }
    //get the patients
    [HttpGet]
    public IActionResult Index()
    {
        var patient=_context.Patients.ToList();
        return View(patient);
    }
    
    //get patients create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    //post create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Patient patient)
    {
        if (ModelState.IsValid)
        {
            _context.Add(patient);
            _context.SaveChanges();
            TempData["Message:"]="Patient created successfully";
            return RedirectToAction(nameof(Index));
        }
        return View(patient);
    }
    
    //edit customers
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var patient = _context.Patients.Find(id);
        if (patient == null) return NotFound();
        return View(patient);
    }
    
    //post edit patients
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Patient patient)
    {
        if (id != patient.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(patient);
            _context.SaveChanges();
            TempData["Message:"]="Patient updated successfully";
            return RedirectToAction(nameof(Index));
        }
        return View(patient);
    }

    //get delete patients
    public IActionResult Delete(int id)
    {
        var patient = _context.Patients.Find(id);
        if(patient==null) return NotFound();
        return View(patient);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var patient=_context.Patients.Find(id);
        if(patient==null) return NotFound();

        _context.Patients.Remove(patient);
        _context.SaveChanges();
        TempData["Message:"]="Patient deleted successfully";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        var patient = _context.Patients.Find(id);
        if (patient == null) return NotFound();
        return View(patient);
    }
}