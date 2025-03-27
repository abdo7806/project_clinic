namespace project_clinic.Models.ViewModel
{
    public class PatientAndPersonViewModel
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }



        public virtual IList<Person> Persons { get; set; }
    }
}
