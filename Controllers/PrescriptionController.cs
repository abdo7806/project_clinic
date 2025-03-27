using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_clinic.Models;
using project_clinic.Models.Repositories;

namespace project_clinic.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IRepositories<Prescription> _PrescriptionRepositories;
        private readonly IRepositories<MedicalRecord> _MedicalRecordRepositories;

        public PrescriptionController(IRepositories<Prescription> PrescriptionRepositories,
            IRepositories<MedicalRecord> MedicalRecordRepositories)
        {
            _PrescriptionRepositories = PrescriptionRepositories;
            _MedicalRecordRepositories = MedicalRecordRepositories;
        }
        // GET: PrescriptionController
        public ActionResult Index()
        {
            return View(_PrescriptionRepositories.GetAll());
        }

        // GET: PrescriptionController/Details/5
        public ActionResult Details(int id)
        {
            return View(_PrescriptionRepositories.Find(id));
        }

        // GET: PrescriptionController/Create
        public ActionResult Create()
        {
          /*  var prescription = new Prescription
            {
                MedicalRecords = _MedicalRecordRepositories.GetAll(),
            };*/
            return View();
        }

        // POST: PrescriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prescription collection)
        {
            try
            {
                _PrescriptionRepositories.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrescriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_PrescriptionRepositories.Find(id));
        }

        // POST: PrescriptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Prescription collection)
        {
            try
            {
                _PrescriptionRepositories.Edit(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrescriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_PrescriptionRepositories.Find(id));
        }

        // POST: PrescriptionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Prescription collection)
        {
            try
            {
                _PrescriptionRepositories.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
