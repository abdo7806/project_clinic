using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_clinic.Models.Repositories;
using project_clinic.Models;

namespace project_clinic.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IRepositories<MedicalRecord> _MedicalRecordRepositories;

       public MedicalRecordController(IRepositories<MedicalRecord> MedicalRecordRepositories)
        {
            _MedicalRecordRepositories = MedicalRecordRepositories;
        }
        // GET: MedicalRecordController
        public ActionResult Index()
        {
            return View(_MedicalRecordRepositories.GetAll());
        }

        // GET: MedicalRecordController/Details/5
        public ActionResult Details(int id)
        {
            return View(_MedicalRecordRepositories.Find(id));
        }

        // GET: MedicalRecordController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicalRecord collection)
        {
            try
            {


                _MedicalRecordRepositories.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalRecordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_MedicalRecordRepositories.Find(id));
        }

        // POST: MedicalRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicalRecord collection)
        {
            try
            {
                _MedicalRecordRepositories.Edit(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicalRecordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_MedicalRecordRepositories.Find(id));
        }

        // POST: MedicalRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MedicalRecord collection)
        {
            try
            {
                _MedicalRecordRepositories.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
