using System;
using System.Collections.Generic;

namespace project_clinic.Models;

public partial class MedicalRecord
{
    public int MedicalRecordId { get; set; }

    // وصف الزيارة
    public string? VisitDescription { get; set; }

    // التشخيص
    public string? Diagnosis { get; set; }

    //ملاحظات إضافية
    public string? AdditionalNotes { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
