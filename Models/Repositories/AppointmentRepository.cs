using Microsoft.EntityFrameworkCore;

namespace project_clinic.Models.Repositories
{
    public class AppointmentRepository : IRepositories<Appointment>
    {


        private ClinicContext db;
        private Appointment _table;
        AppointmentRepository()
        {
            db = new ClinicContext();
        }
        public AppointmentRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(Appointment item)
        {
            if (db.Database.CanConnect())
            {
                db.Appointments.Add(item);
                db.SaveChanges();
                return item.AppointmentId;

            }
            else
            {
                return -1;
            }
        }

        public void Delete(int id)
        {
            if (db.Database.CanConnect())
            {
                _table = Find(id);
                db.Appointments.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, Appointment item)
        {
            // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.Appointments.Update(item);
                db.SaveChanges();

            }
        }

        public Appointment Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Appointments.Where(x => x.AppointmentId == Id).First();
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            var Appointment = db.Appointments.Include(x => x.Doctor).ToList();
            Appointment = db.Appointments.Include(x => x.Patient).ToList();
            Appointment = db.Appointments.Include(x => x.Payment).ToList();
            // return GetAllnews();
            return Appointment;
        }



        public List<Appointment> Search(string SerachItem)
        {
            /*if (db.Database.CanConnect())
            {
                return db.Appointments.Where(x => x.Name.Contains(SerachItem)
                || x.AppointmentId.ToString().Contains(SerachItem)
                || x.DateOfBirth.ToString().Contains(SerachItem)
                || x.Gender.ToString().Contains(SerachItem)
                || x.PhoneNumber.Contains(SerachItem)
                || x.Email.Contains(SerachItem)
                || x.Address.Contains(SerachItem)
                ).ToList();
            }*/
            return null;
        }

        // الغاء الموعد
        public void CancelAppointment(Appointment item)
        {
            if (db.Database.CanConnect())
            {
                db.Appointments.Update(_table);
                db.SaveChanges();
            }
        }


    }
}
