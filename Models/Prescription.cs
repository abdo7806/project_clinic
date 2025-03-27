using System;
using System.Collections.Generic;

namespace project_clinic.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int MedicalRecordId { get; set; }

    public string MedicationName { get; set; } = null!;

    public string Dosage { get; set; } = null!;
    // الجرعة
    public string Frequency { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? SpecialInstructions { get; set; }

    public virtual MedicalRecord MedicalRecord { get; set; } = null!;

}
