using System;
using System.Collections.Generic;

namespace project_clinic.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateTime PaymentDate { get; set; }// تاريخ الدفع

    public string? PaymentMethod { get; set; }// طريقة الدفع

    public decimal AmountPaid { get; set; }// المبلغ المدفوع

    public string? AdditionalNotes { get; set; }// ملاحظة إضافية

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
