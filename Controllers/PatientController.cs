using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_clinic.Models;
using project_clinic.Models.Repositories;
using project_clinic.Models.ViewModel;

namespace project_clinic.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepositories<Patient> _PatientsRepositories;
        private readonly IRepositories<Person> _PersonRepository;

        public PatientController(IRepositories<Patient> PatientsRepositories,
            IRepositories<Person> personRepository)
        {
            _PatientsRepositories = PatientsRepositories;
            this._PersonRepository = personRepository;
        }

        // GET: PatientController
        public ActionResult Index(int? id)
        {

            var patients = _PatientsRepositories.GetAll();

            var viewModel = patients.Select(p => new PatientAndPersonViewModel
            {
                Id = p.PatientId,
                PersonId = p.Person.PersonId,
                Name = p.Person.Name,
                DateOfBirth = p.Person.DateOfBirth,
                Gender = p.Person.Gender,
                PhoneNumber = p.Person.PhoneNumber,
                Email = p.Person.Email,
                Address = p.Person.Address,
            }).ToList();

            if (id == 0 || id == null)
            {
                var data = viewModel.Take(10); ;
                return View(data);
            }
            else
            {
                var data = viewModel.Where(x => x.PersonId > id).Take(10);
                return View(data);
            }

        }

        // GET: PatientController/Details/5
        public ActionResult Details(int id, int PersonId)
        {
            var Patient = _PatientsRepositories.Find(id);
            Patient.Person = _PersonRepository.Find(PersonId);
            var PatientAndPerson = new PatientAndPersonViewModel
            {
                Id = id,
                PersonId = Patient.Person.PersonId,
                Name = Patient.Person.Name,
                Email = Patient.Person.Email,
                DateOfBirth = Patient.Person.DateOfBirth,
                PhoneNumber = Patient.Person.PhoneNumber,
                Address = Patient.Person.Address,
                Gender = Patient.Person.Gender,

            };


            return View(PatientAndPerson);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorAndPersonViewModel collection)
        {
            try
            {
                var Person = new Person
                {
                    Name = collection.Name,
                    PhoneNumber = collection.PhoneNumber,
                    Address = collection.Address,
                    Email = collection.Email,
                    DateOfBirth = collection.DateOfBirth,
                    Gender = collection.Gender,
                };

                int PersonId = _PersonRepository.Add(Person);

                var Patient = new Patient
                {
                    PersonId = PersonId,
                };
                _PatientsRepositories.Add(Patient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int id, int PersonId)
        {
            var Patient = _PatientsRepositories.Find(id);
            Patient.Person = _PersonRepository.Find(PersonId);
            var PatientAndPerson = new PatientAndPersonViewModel
            {
                Id = id,
                PersonId = Patient.Person.PersonId,
                Name = Patient.Person.Name,
                Email = Patient.Person.Email,
                DateOfBirth = Patient.Person.DateOfBirth,
                PhoneNumber = Patient.Person.PhoneNumber,
                Address = Patient.Person.Address,
                Gender = Patient.Person.Gender,

            };

            return View(PatientAndPerson);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientAndPersonViewModel collection)
        {
            try
            {
                var Person = new Person
                {
                    PersonId = collection.PersonId,
                    Name = collection.Name,
                    PhoneNumber = collection.PhoneNumber,
                    Address = collection.Address,
                    Email = collection.Email,
                    DateOfBirth = collection.DateOfBirth,
                    Gender = collection.Gender,
                };

                _PersonRepository.Edit(collection.PersonId, Person);

                var Patient = new Patient
                {
                    PatientId = id,
                    PersonId = collection.PersonId,
                };

                _PatientsRepositories.Edit(id, Patient);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(int id, int PersonId)
        {
            var Patient = _PatientsRepositories.Find(id);
            Patient.Person = _PersonRepository.Find(PersonId);
            var PatientAndPerson = new PatientAndPersonViewModel
            {
                Id = id,
                PersonId = Patient.Person.PersonId,
                Name = Patient.Person.Name,
                Email = Patient.Person.Email,
                DateOfBirth = Patient.Person.DateOfBirth,
                PhoneNumber = Patient.Person.PhoneNumber,
                Address = Patient.Person.Address,
                Gender = Patient.Person.Gender,

            };


            return View(PatientAndPerson);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PatientAndPersonViewModel collection)
        {
            try
            {
                int PersonId = _PatientsRepositories.Find(collection.Id).PersonId;

                _PatientsRepositories.Delete(id);
                _PersonRepository.Delete(PersonId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
