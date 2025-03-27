using Microsoft.EntityFrameworkCore;

namespace project_clinic.Models.Repositories
{
    public class PrescriptionRepository : IRepositories<Prescription>
    {
        private ClinicContext db;
        private Prescription _table;
        PrescriptionRepository()
        {
            db = new ClinicContext();

        }
        public PrescriptionRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(Prescription item)
        {
            if (db.Database.CanConnect())
            {
                db.Prescriptions.Add(item);
                db.SaveChanges();
                return item.PrescriptionId;

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
                db.Prescriptions.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, Prescription item)
        {
            // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.Prescriptions.Update(item);
                db.SaveChanges();

            }
        }

        public Prescription Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Prescriptions.Where(x => x.PrescriptionId == Id).First();
            }
            return null;
        }

        public List<Prescription> GetAll()
        {

            // return GetAllnews();
            return db.Prescriptions.ToList();
        }



        public List<Prescription> Search(string SerachItem)
        {
            /*if (db.Database.CanConnect())
            {
                return db.Prescriptions.Where(x => x.Name.Contains(SerachItem)
                || x.PrescriptionId.ToString().Contains(SerachItem)
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
