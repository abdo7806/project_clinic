using Microsoft.EntityFrameworkCore;

namespace project_clinic.Models.Repositories
{// المرضى 
    
    public class PatientRepository : IRepositories<Patient>
    {

        private ClinicContext db;
        private Patient _table;
        PatientRepository()
        {
            db = new ClinicContext();

        }
        public PatientRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(Patient item)
        {
            if (db.Database.CanConnect())
            {
                db.Patients.Add(item);
                db.SaveChanges();
                return item.PatientId;

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
                db.Patients.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, Patient item)
        {
            // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.Patients.Update(item);
                db.SaveChanges();

            }
        }

        public Patient Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Patients.Where(x => x.PatientId == Id).First();
            }
            return null;
        }

        public List<Patient> GetAll()
        {

            // return GetAllnews();
            return db.Patients.Include(d => d.Person).ToList();
        }



        public List<Patient> Search(string SerachItem)
        {
            /*if (db.Database.CanConnect())
            {
                return db.Patients.Where(x => x.Name.Contains(SerachItem)
                || x.PatientId.ToString().Contains(SerachItem)
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
