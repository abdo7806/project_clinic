using Microsoft.EntityFrameworkCore;
using project_clinic.Controllers;
using project_clinic.Models;
using project_clinic.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ����� ����� �������
builder.Services.AddDbContext<ClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����� ����� MVC � Razor Pages
//builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddMvc(op => op.EnableEndpointRouting = false);

// ����� ����� ����
builder.Services.AddScoped<IRepositories<Person>, PersonRepository>(); // ������ Scoped ���
builder.Services.AddScoped<IRepositories<Doctor>, DoctorRepository>(); // ������ Scoped ���
builder.Services.AddScoped<IRepositories<Patient>, PatientRepository>(); // ������ Scoped ���
builder.Services.AddScoped<IRepositories<MedicalRecord>, MedicalRecordRepository>(); // ������ Scoped ���
builder.Services.AddScoped<IRepositories<Prescription>, PrescriptionRepository>(); // ������ Scoped ���
builder.Services.AddScoped<IRepositories<Payment>, PaymentRepository>(); // ������ Scoped ���
builder.Services.AddScoped<IRepositories<Appointment>, AppointmentRepository>(); // ������ Scoped ���



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseMvcWithDefaultRoute();// MVS �� ����� �� ����� 

app.UseStaticFiles();// js, css �������� ������� ������� ��� ����� � 
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ����� ���� �������
app.MapControllers(); // ������ ����� API
app.MapRazorPages();  // ������ ����� Razor Pages

app.Run();