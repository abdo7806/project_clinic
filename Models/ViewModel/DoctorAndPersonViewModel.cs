namespace project_clinic.Models.ViewModel
{
    public class DoctorAndPersonViewModel
    {
     
        public int Id { get; set; }
        public string? Specialization { get; set; }

        public int PersonId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }


       // public int PersonId { get; set; }

        public virtual IList<Person> Persons { get; set; }
        // public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        // public virtual IList<Appointment> Appointments { get; set; }
        //  public virtual Person Person { get; set; } = null!;

    }
}
