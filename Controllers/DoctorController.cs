using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_clinic.Models;
using project_clinic.Models.Repositories;
using project_clinic.Models.ViewModel;

namespace project_clinic.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IRepositories<Doctor> _DoctorRepositories;
        private readonly IRepositories<Person> _PersonRepository;

        // GET: DoctorController

        public DoctorController(IRepositories<Doctor> DoctorRepositories,
            IRepositories<Person> personRepository)
        {
            this._DoctorRepositories = DoctorRepositories;
            this._PersonRepository = personRepository;
        }
        public ActionResult Index()
        {

          /*  var doctors = _DoctorRepositories.GetAll()
              .Include(d => d.Person) // تأكد من تضمين بيانات Person
              .ToList();*/
            return View(_DoctorRepositories.GetAll());
        }

        // GET: DoctorController/Details/5
        public ActionResult Details(int id, int PersonId)
        {
            var Doctor = _DoctorRepositories.Find(id);
            Doctor.Person = _PersonRepository.Find(PersonId);
            var DoctorAndPerson = new DoctorAndPersonViewModel
            {
                Id = id,
                Specialization = Doctor.Specialization,
                PersonId = Doctor.Person.PersonId,
                Name = Doctor.Person.Name,
                Email = Doctor.Person.Email,
                DateOfBirth = Doctor.Person.DateOfBirth,
                PhoneNumber = Doctor.Person.PhoneNumber,
                Address = Doctor.Person.Address,
                Gender = Doctor.Person.Gender,

            };

            return View(DoctorAndPerson);
        }

        // GET: DoctorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
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

                int DoctorId = _PersonRepository.Add(Person);

                var Doctor = new Doctor
                {
                    PersonId = DoctorId,
                    Specialization = collection.Specialization,
                };
                _DoctorRepositories.Add(Doctor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Edit/5
        public ActionResult Edit(int id, int PersonId)
        {
            var Doctor = _DoctorRepositories.Find(id);
            Doctor.Person = _PersonRepository.Find(PersonId);
            var DoctorAndPerson = new DoctorAndPersonViewModel
            {
                Id = id,
                Specialization = Doctor.Specialization,
                PersonId = Doctor.Person.PersonId,
                Name = Doctor.Person.Name,
                Email = Doctor.Person.Email,
                DateOfBirth = Doctor.Person.DateOfBirth,
                PhoneNumber = Doctor.Person.PhoneNumber,
                Address = Doctor.Person.Address,
                Gender = Doctor.Person.Gender,

            };

            return View(DoctorAndPerson);
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DoctorAndPersonViewModel collection)
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

                var Doctor = new Doctor
                {
                    DoctorId = id,
                    PersonId = collection.PersonId,
                    Specialization = collection.Specialization,
                };

                _DoctorRepositories.Edit(id, Doctor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Delete/5
        public ActionResult Delete(int id, int PersonId)
        {
            var Doctor = _DoctorRepositories.Find(id);
            Doctor.Person = _PersonRepository.Find(PersonId);
            var DoctorAndPerson = new DoctorAndPersonViewModel
            {
                Id = id,
                Specialization = Doctor.Specialization,
                PersonId = Doctor.Person.PersonId,
                Name = Doctor.Person.Name,
                Email = Doctor.Person.Email,
                DateOfBirth = Doctor.Person.DateOfBirth,
                PhoneNumber = Doctor.Person.PhoneNumber,
                Address = Doctor.Person.Address,
                Gender = Doctor.Person.Gender,

            };

            return View(DoctorAndPerson);
        }

        // POST: DoctorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DoctorAndPersonViewModel collection)
        {
            try
            {
                int PersonId = _DoctorRepositories.Find(collection.Id).PersonId;

                _DoctorRepositories.Delete(id);
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
