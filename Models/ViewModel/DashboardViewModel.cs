namespace project_clinic.Models.ViewModel
{
    public class DashboardViewModel
    {
        public int Id { get; set; }// عدد المرضى
        public int PatientCount { get; set; }// عدد المرضى
        public int DoctorCount { get; set; }// عدد الاطباء
        public int AppointmentCount { get; set; }// عدد المواعيد
        public int MedicalRecordCount { get; set; }// عدد السجلات الطبية
        public int PrescriptionCount { get; set; }// عدد الوصفات الطبية
    }
}
