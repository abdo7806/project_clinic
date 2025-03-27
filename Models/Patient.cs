using System;
using System.Collections.Generic;

namespace project_clinic.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Person Person { get; set; } = null!;
}
