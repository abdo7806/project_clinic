using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_clinic.Models;
using project_clinic.Models.Repositories;
using project_clinic.Models.ViewModel;

namespace project_clinic.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IRepositories<Appointment> _AppointmentRepositories;
        private readonly IRepositories<Doctor> _DoctorRepositories;
        private readonly IRepositories<Patient> _PatientsRepositories;
        private readonly IRepositories<Person> _PersonRepository;
        private readonly IRepositories<Payment> _PaymentRepositories;
        private readonly IRepositories<MedicalRecord> _MedicalRecordRepositories;

        public AppointmentController(IRepositories<Appointment> AppointmentRepositories,
            IRepositories<Doctor> doctorRepositories,
            IRepositories<Patient> PatientsRepositories,
            IRepositories<Person> personRepository,
            IRepositories<Payment> PaymentRepositories,
            IRepositories<MedicalRecord> MedicalRecordRepositories)
        {
            _AppointmentRepositories = AppointmentRepositories;
            _DoctorRepositories = doctorRepositories;
            _PatientsRepositories = PatientsRepositories;
            _PersonRepository = personRepository;
            _PaymentRepositories = PaymentRepositories;
            _MedicalRecordRepositories = MedicalRecordRepositories;
        }
        // GET: AppointmentController
        public ActionResult Index(int? id)
        {

            var data = _AppointmentRepositories.GetAll();

            data.ForEach(data => 
            {
                //int PatientPersonId = _PatientsRepositories.Find(data.PatientId).PersonId;
                data.Doctor.Person = _PersonRepository.Find(data.Doctor.PersonId);
                data.Patient.Person = _PersonRepository.Find(data.Patient.PersonId);
               // data.Payment = _PaymentRepositories.Find(data.Doctor.PersonId);
            });

            if (id == 0 || id == null)
            {
                var people = data.Take(10);
                return View(people);
            }
            else
            {
                var people = data.Where(x => x.AppointmentId > id).Take(10);
                return View(people);
            }

        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            var appointment = _AppointmentRepositories.Find(id);
            var payment = _PaymentRepositories.Find(appointment.PaymentId);
            var Patient = _PatientsRepositories.Find(appointment.PatientId);
           
            var Person = _PersonRepository.Find(Patient.PersonId);

            var appointmentViewModel = new AppointmentViewModel
            {
                Id = id,
                DoctorId = appointment.DoctorId,
                Doctor = _DoctorRepositories.Find(appointment.DoctorId),
                PaymentId = payment.PaymentId,
                PatientId = appointment.PatientId,
                AppointmentDateTime = appointment.AppointmentDateTime,
                AppointmentStatus = appointment.AppointmentStatus,
                MedicalRecordId = appointment.MedicalRecordId,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                AmountPaid = payment.AmountPaid,
                AdditionalNotes = payment.AdditionalNotes,

                Name = Person.Name,
                DateOfBirth = Person.DateOfBirth,
                Gender = Person.Gender,
                PhoneNumber = Person.PhoneNumber,
                Email = Person.Email,
                Address = Person.Address,
            };


            return View(appointmentViewModel);
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {

            var AppointmentViewModel = new AppointmentViewModel
            {
                Doctors = _DoctorRepositories.GetAll(),
                DoctorId = _DoctorRepositories.GetAll().Select(x=>x.DoctorId).Last(),
            };

            return View(AppointmentViewModel);
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentViewModel collection)
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



                var payment = new Payment
                {
                    PaymentMethod = collection.PaymentMethod,
                    AdditionalNotes = collection.AdditionalNotes,
                    AmountPaid = collection.AmountPaid,
                    PaymentDate = collection.PaymentDate,
                };

                int PersonId = _PersonRepository.Add(Person);

                var Patient = new Patient
                {
                    PersonId = PersonId,
                };
                int PatientId = _PatientsRepositories.Add(Patient);

                int PaymentId = _PaymentRepositories.Add(payment);

                MedicalRecord medicalRecord = new MedicalRecord();
                int MedicalRecordId =_MedicalRecordRepositories.Add(medicalRecord);

                var AppointmenT = new Appointment
                {
                    // Doctors = _DoctorRepositories.GetAll(),
                    DoctorId = collection.DoctorId,
                    PatientId = PatientId,
                    MedicalRecordId = MedicalRecordId,
                    AppointmentDateTime = collection.AppointmentDateTime,
                    AppointmentStatus = 1,
                    PaymentId = PaymentId,


                };

                int _AppointmentId = _AppointmentRepositories.Add(AppointmenT);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {

            var appointment = _AppointmentRepositories.Find(id);
            var payment = _PaymentRepositories.Find(appointment.PaymentId);
            var Patient = _PatientsRepositories.Find(appointment.PatientId);

            var Person = _PersonRepository.Find(Patient.PersonId);

            var appointmentViewModel = new AppointmentViewModel
            {
                Id = id,
                DoctorId = appointment.DoctorId,
                Doctor = _DoctorRepositories.Find(appointment.DoctorId),
                Doctors = _DoctorRepositories.GetAll(),

                PaymentId = payment.PaymentId,
                PatientId = appointment.PatientId,
                AppointmentDateTime = appointment.AppointmentDateTime,
                AppointmentStatus = appointment.AppointmentStatus,
                MedicalRecordId = appointment.MedicalRecordId,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                AmountPaid = payment.AmountPaid,
                AdditionalNotes = payment.AdditionalNotes,

                Name = Person.Name,
                DateOfBirth = Person.DateOfBirth,
                Gender = Person.Gender,
                PhoneNumber = Person.PhoneNumber,
                Email = Person.Email,
                Address = Person.Address,

            };


            return View(appointmentViewModel);

        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppointmentViewModel collection)
        {
            try
            {
                int PersonId = _PatientsRepositories.Find(collection.PatientId).PersonId;

                var Person = new Person
                {
                    PersonId = PersonId,
                    Name = collection.Name,
                    PhoneNumber = collection.PhoneNumber,
                    Address = collection.Address,
                    Email = collection.Email,
                    DateOfBirth = collection.DateOfBirth,
                    Gender = collection.Gender,
                };



                var payment = new Payment
                {
                    PaymentId = collection.PaymentId,
                    PaymentMethod = collection.PaymentMethod,
                    AdditionalNotes = collection.AdditionalNotes,
                    AmountPaid = collection.AmountPaid,
                    PaymentDate = collection.PaymentDate,
                };
                 _PersonRepository.Edit(PersonId, Person);


                _PaymentRepositories.Edit(collection.PaymentId, payment);



                var AppointmenT = new Appointment
                {
                    // Doctors = _DoctorRepositories.GetAll(),
                    AppointmentId = collection.Id,
                    DoctorId = collection.DoctorId,
                    PatientId = collection.PatientId,
                    MedicalRecordId = collection.MedicalRecordId,
                    AppointmentDateTime = collection.AppointmentDateTime,
                    AppointmentStatus = 1,
                    PaymentId = collection.PaymentId,


                };
 
                _AppointmentRepositories.Edit(id, AppointmenT);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AppointmentViewModel collection)
        {
            try
            {
                /*var AppointmenT = new Appointment
                {
                    // Doctors = _DoctorRepositories.GetAll(),
                    AppointmentId = collection.Id,
                    DoctorId = collection.DoctorId,
                    PatientId = collection.PatientId,
                    MedicalRecordId = collection.MedicalRecordId,
                    AppointmentDateTime = collection.AppointmentDateTime,
                    AppointmentStatus = 1,
                    PaymentId = collection.PaymentId,


                };*/

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CancelAppointment(int id)
        {
            try
            {
                var appointment = _AppointmentRepositories.Find(id);

                if (appointment == null)
                {
                    // إذا لم يتم العثور على الموعد، يمكنك إرجاع خطأ أو رسالة
                    TempData["Error"] = "Appointment not found.";
                    return RedirectToAction(nameof(Index));
                }

                appointment.AppointmentStatus = 2;

                _AppointmentRepositories.Edit(id, appointment);

                TempData["Message"] = "Appointment has been cancelled successfully.";
                // return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ هنا إذا لزم الأمر
                TempData["Error"] = "An error occurred while cancelling the appointment.";
                return View();
            }
        }

    }
}
