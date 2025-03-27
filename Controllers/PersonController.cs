using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using project_clinic.Models;
using project_clinic.Models.Repositories;
using project_clinic.Pages.Appointment;

namespace project_clinic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IRepositories<Person> _personRepository;

        public PersonController(IRepositories<Person> personRepository) // تأكد من وجود هذا
        {
            _personRepository = personRepository;
        }
        // GET: PersonController
        public ActionResult Index(int? id)
        {
            if (id == 0 || id == null)
            {
                var people = _personRepository.GetAll().Take(10) ;
                return View(people);
            }
            else
            {
                var people = _personRepository.GetAll()
                    .Where(x => x.PersonId > id).Take(10);
                return View(people);
            }
         
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View(_personRepository.Find(id));
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person collection)
        {
            try
            {
              //  collection.DateOfBirth = DateTime.Now;
                // إنشاء كائن شخص جديد بدون ربطه بأي طبيب أو مريض

                _personRepository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_personRepository.Find(id));
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person collection)
        {
            try
            {
          
                _personRepository.Edit(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_personRepository.Find(id));
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Person collection)
        {
            try
            {
                _personRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string SearchItem)
        {
            if (SearchItem == null)
            {
                return View("Index", _personRepository.GetAll());
            }
            else
            {
                return View("Index", _personRepository.Search(SearchItem));

            }
        }
    }
}
