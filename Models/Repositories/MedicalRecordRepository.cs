namespace project_clinic.Models.Repositories
{
    public class MedicalRecordRepository : IRepositories<MedicalRecord>
    {
        private ClinicContext db;
        private MedicalRecord _table;
        MedicalRecordRepository()
        {
            db = new ClinicContext();

        }
        public MedicalRecordRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(MedicalRecord item)
        {
            if (db.Database.CanConnect())
            {
                db.MedicalRecords.Add(item);
                db.SaveChanges();
                return item.MedicalRecordId;

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
                db.MedicalRecords.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, MedicalRecord item)
        {
            // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.MedicalRecords.Update(item);
                db.SaveChanges();

            }
        }

        public MedicalRecord Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.MedicalRecords.Where(x => x.MedicalRecordId == Id).First();
            }
            return null;
        }

        public List<MedicalRecord> GetAll()
        {

            // return GetAllnews();
            return db.MedicalRecords.ToList();
        }



        public List<MedicalRecord> Search(string SerachItem)
        {
            /*if (db.Database.CanConnect())
            {
                return db.MedicalRecords.Where(x => x.Name.Contains(SerachItem)
                || x.MedicalRecordId.ToString().Contains(SerachItem)
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
