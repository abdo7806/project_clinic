using Microsoft.EntityFrameworkCore;
using project_clinic.Controllers;
using project_clinic.Models;
using project_clinic.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ÅÚÏÇÏ ÓáÓáÉ ÇáÇÊÕÇá
builder.Services.AddDbContext<ClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ÅÖÇİÉ ÎÏãÇÊ MVC æ Razor Pages
//builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddMvc(op => op.EnableEndpointRouting = false);

// ÅÖÇİÉ ÎÏãÇÊ ÃÎÑì
builder.Services.AddScoped<IRepositories<Person>, PersonRepository>(); // ÇÓÊÎÏã Scoped åäÇ
builder.Services.AddScoped<IRepositories<Doctor>, DoctorRepository>(); // ÇÓÊÎÏã Scoped åäÇ
builder.Services.AddScoped<IRepositories<Patient>, PatientRepository>(); // ÇÓÊÎÏã Scoped åäÇ
builder.Services.AddScoped<IRepositories<MedicalRecord>, MedicalRecordRepository>(); // ÇÓÊÎÏã Scoped åäÇ
builder.Services.AddScoped<IRepositories<Prescription>, PrescriptionRepository>(); // ÇÓÊÎÏã Scoped åäÇ
builder.Services.AddScoped<IRepositories<Payment>, PaymentRepository>(); // ÇÓÊÎÏã Scoped åäÇ
builder.Services.AddScoped<IRepositories<Appointment>, AppointmentRepository>(); // ÇÓÊÎÏã Scoped åäÇ



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseMvcWithDefaultRoute();// MVS áÇ ÊİÚíá Çæ ÊåíÆÉ 

app.UseStaticFiles();// js, css áÇÓÊÎÏÇä ÇáãáİÇÊ ÇáËÇÈÊå ãËá ÇáÕæÑ æ 
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ÅÚÏÇÏ äŞÇØ ÇáäåÇíÉ
app.MapControllers(); // áÊæÌíå ØáÈÇÊ API
app.MapRazorPages();  // áÊæÌíå ØáÈÇÊ Razor Pages

app.Run();