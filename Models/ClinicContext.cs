using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using project_clinic.Models.ViewModel;

namespace project_clinic.Models;

public partial class ClinicContext : DbContext
{
    public ClinicContext()
    {
    }

    public ClinicContext(DbContextOptions<ClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Clinic;User Id=sa;Password=123456;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2896563A4");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments.DoctorID");

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.MedicalRecordId)
                .HasConstraintName("FK_Appointments_MedicalRecords");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments.PatientID");

            entity.HasOne(d => d.Payment).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Payments.PaymentID");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EDF119A2508");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DoctorID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Specialization).HasMaxLength(100);

            entity.HasOne(d => d.Person).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctors_Persons");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("PK__MedicalR__4411BBC251D4E64A");

            entity.Property(e => e.MedicalRecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("MedicalRecordID");
            entity.Property(e => e.AdditionalNotes).HasMaxLength(200);
            entity.Property(e => e.Diagnosis).HasMaxLength(200);
            entity.Property(e => e.VisitDescription).HasMaxLength(200);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346A08EB619");

            entity.Property(e => e.PatientId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PatientID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.Person).WithMany(p => p.Patients)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Persons");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A585488506C");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PaymentID");
            entity.Property(e => e.AdditionalNotes).HasMaxLength(200);
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
        });

    
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonId).HasName("PK__Persons__AA2FFB8587F22B37");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedOnAdd() // اجعلها تولّد تلقائيًا
                    .HasColumnName("PersonID");
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(20);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });
        

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__40130812FF0A60CF");

            entity.Property(e => e.PrescriptionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PrescriptionID");
            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
            entity.Property(e => e.MedicationName).HasMaxLength(100);
            entity.Property(e => e.SpecialInstructions).HasMaxLength(200);

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.MedicalRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescriptions.MedicalRecordID");
        });

        //OnModelCreatingPartial(modelBuilder);
    }






}
