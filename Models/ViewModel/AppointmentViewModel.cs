namespace project_clinic.Models.ViewModel
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }// المريض

        public int DoctorId { get; set; }// الطبيب

        public DateTime AppointmentDateTime { get; set; }

        // حالة الموعد 
        // 1 قيد الانتضار
        // 2 ملغي 
        // 3 منتهي
        public byte AppointmentStatus { get; set; }

        public int? MedicalRecordId { get; set; }// رقم السجل الطبي

        public int PaymentId { get; set; }// رقم الدفع


        //************************************
        public DateTime PaymentDate { get; set; }// تاريخ الدفع

        public string? PaymentMethod { get; set; }// طريقة الدفع

        public decimal AmountPaid { get; set; }// المبلغ المدفوع

        public string? AdditionalNotes { get; set; }// ملاحظة إضافية

        //***********************************


        public string Name { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }
        public virtual IList<Doctor> Doctors { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;


    }
}
