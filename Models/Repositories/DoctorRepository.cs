
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;

namespace project_clinic.Models.Repositories
{
    
    public class DoctorRepository : IRepositories<Doctor>
    {
        

        private ClinicContext db;
        private Doctor _table;
        DoctorRepository()
        {
            db = new ClinicContext();

        }
        public DoctorRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(Doctor item)
        {
            if (db.Database.CanConnect())
            {
                db.Doctors.Add(item);
                db.SaveChanges();
                return item.DoctorId;

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
                db.Doctors.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, Doctor item)
        {
            // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.Doctors.Update(item);
                db.SaveChanges();

            }
        }

        public Doctor Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Doctors.Where(x => x.DoctorId == Id).First();
            }
            return null;
        }

        public List<Doctor> GetAll()
        {

            // return GetAllnews();
            return db.Doctors.Include(d => d.Person).ToList();
        }



        public List<Doctor> Search(string SerachItem)
        {
            /*if (db.Database.CanConnect())
            {
                return db.Doctors.Where(x => x.Name.Contains(SerachItem)
                || x.DoctorId.ToString().Contains(SerachItem)
                || x.DateOfBirth.ToString().Contains(SerachItem)
                || x.Gender.ToString().Contains(SerachItem)
                || x.PhoneNumber.Contains(SerachItem)
                || x.Email.Contains(SerachItem)
                || x.Address.Contains(SerachItem)
                ).ToList();
            }*/
            return null;
        }



    }
}
