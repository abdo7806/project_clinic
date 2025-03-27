using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_clinic.Models;
using project_clinic.Models.Repositories;
using project_clinic.Models.ViewModel;
namespace project_clinic.Controllers
{
    public class DashboardController : Controller
    {
       /* private IRepositories<Appointment> _AppointmentRepositories;
        private IRepositories<Doctor> _DoctorRepositories;
        private IRepositories<Patient> _PatientsRepositories;
        private IRepositories<Person> _PersonRepository;
        private IRepositories<Payment> _PaymentRepositories;
        private IRepositories<MedicalRecord> _MedicalRecordRepositories;

        public DashboardController(IRepositories<Appointment> AppointmentRepositories,
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
       */
        private ClinicContext _context;
        DashboardController()
        {
            _context = new ClinicContext();
        }
        public ActionResult Index()
        {
           /* var DashboardViewModel = new DashboardViewModel
            {
                PatientCount = _PatientsRepositories.GetAll().Count(),
                DoctorCount = _DoctorRepositories.GetAll().Count(),
                AppointmentCount = _AppointmentRepositories.GetAll().Count(),
                MedicalRecordCount = _AppointmentRepositories.GetAll().Count(),
               // AppointmentCount = _AppointmentRepositories.GetAll().Count(),
            };*/

            var model = new DashboardViewModel
            {
                PatientCount = _context.Patients.Count(),
                DoctorCount = _context.Doctors.Count(),
                AppointmentCount = _context.Appointments.Count(),
                MedicalRecordCount = _context.MedicalRecords.Count()

            };
            return View(model);
        }
    }
}
