
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.Data;

namespace project_clinic.Models.Repositories
{
    
    public class PersonRepository : IRepositories<Person>
    {
        private ClinicContext db;
        private Person _table;
        PersonRepository()
         {
             db = new ClinicContext();

         }
        public PersonRepository(ClinicContext context) // تأكد من وجود هذا
        {
            db = context;
        }
        public int Add(Person item)
        {
            if (db.Database.CanConnect())
            {
                db.Persons.Add(item);
                db.SaveChanges();
                return item.PersonId;
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
                db.Persons.Remove(_table);
                db.SaveChanges();
            }
        }

        public void Edit(int id, Person item)
        {
           // db = new DBContext();

            if (db.Database.CanConnect())
            {
                db.Persons.Update(item);
                db.SaveChanges();

            }
        }

        public Person Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Persons.Where(x => x.PersonId == Id).First();
            }
            return null;
        }

        public List<Person> GetAll()
        {

            // return GetAllnews();


            return db.Persons.ToList();
        }



        public List<Person> Search(string SerachItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Persons.Where(x => x.Name.Contains(SerachItem)
                || x.PersonId.ToString().Contains(SerachItem)
                || x.DateOfBirth.ToString().Contains(SerachItem)
                || x.Gender.ToString().Contains(SerachItem)
                || x.PhoneNumber.Contains(SerachItem)
                || x.Email.Contains(SerachItem)
                || x.Address.Contains(SerachItem)
                ).ToList();
            }
            return null;
        }


        public static List<Person> GetAllnews()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection("Server=.;Database=Clinic;User Id=sa;Password=123456;Trusted_Connection=true;TrustServerCertificate=True;");

            string query = @"select * from Personss";


            SqlCommand command = new SqlCommand(query, connection);
            List<Person> list = new List<Person>();

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                /* if (reader.HasRows)
                 {
                     dt.Load(reader);
                 }*/


                while (reader.Read())
                {
                    Person person = new Person();

                    person.PersonId = (int)reader["PersonsId"];
                    person.Name = (string)reader["Name"];
                    //person.DateOfBirth = (DateTime)reader["DateOfBirth"];
                  //  var tinyIntValue = reader.GetByte(3);
                   // person.Gender = (int)tinyIntValue;
                    person.PhoneNumber = (string)reader["PhoneNumber"];
                    person.Email = (string)reader["Email"];
                    person.Address = (string)reader["Address"];


                    list.Add(person);
                }

            }
            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return list;
        }
    }
}
