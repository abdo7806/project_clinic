using Microsoft.EntityFrameworkCore;

namespace project_clinic.Models.Repositories
{
    public class PaymentRepository : IRepositories<Payment>
    {


        private ClinicContext db;
        private Payment _table;
        PaymentRepository()
        {
            db = new ClinicContext();

        }
        public PaymentRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(Payment item)
        {
            if (db.Database.CanConnect())
            {
                db.Payments.Add(item);
                db.SaveChanges();
                return item.PaymentId;

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
                db.Payments.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, Payment item)
        {
            // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.Payments.Update(item);
                db.SaveChanges();

            }
        }

        public Payment Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Payments.Where(x => x.PaymentId == Id).First();
            }
            return null;
        }

        public List<Payment> GetAll()
        {

            // return GetAllnews();
            return db.Payments.ToList();
        }



        public List<Payment> Search(string SerachItem)
        {
            /*if (db.Database.CanConnect())
            {
                return db.Payments.Where(x => x.Name.Contains(SerachItem)
                || x.PaymentId.ToString().Contains(SerachItem)
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
