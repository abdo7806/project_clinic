---

# 🏥 Clinic Management System | نظام إدارة العيادة

A lightweight web-based clinic management system built with **ASP.NET Core Razor Pages** and **Entity Framework Core** using a **Database First** approach.  
The system provides basic CRUD functionality for doctors, patients, appointments, payments, and medical records. It's intended for learning and small-scale clinics.

نظام ويب بسيط لإدارة العيادات، تم تطويره باستخدام Razor Pages وEntity Framework Core، بهدف التعلم والتجربة. النظام لا يحتوي على صلاحيات أو تسجيل دخول.

---

## 🔧 Technologies Used | التقنيات المستخدمة

- ASP.NET Core Razor Pages  
- Entity Framework Core (Database First)  
- SQL Server  
- Bootstrap 5  
- C# (.NET 7+)  

---

## 📁 Project Structure | هيكل المشروع
```
project_clinic/
├── Controllers/                # يحتوي على وحدات التحكم (Controllers) لكل كيان
│   ├── DoctorController.cs
│   ├── PatientController.cs
│   └── ...
│
├── Models/                     # يحتوي على نماذج البيانات (Models) المرتبطة بقاعدة البيانات
│   ├── Doctor.cs
│   ├── Patient.cs
│   └── ...
│
├── Views/                      # يحتوي على واجهات المستخدم (Views) باستخدام Razor
│   ├── Doctor/
│   │   ├── Index.cshtml
│   │   └── ...
│   ├── Patient/
│   │   ├── Index.cshtml
│   │   └── ...
│   └── Shared/
│       ├── _Layout.cshtml
│       └── ...
│
├── wwwroot/                    # يحتوي على الملفات الثابتة (CSS, JS, صور)
│   ├── css/
│   ├── js/
│   └── lib/
│
│
├── appsettings.json            # يحتوي على إعدادات التطبيق وسلسلة الاتصال بقاعدة البيانات
├── Program.cs                  # نقطة البداية لتشغيل التطبيق
```
## 🚀 How to Run | كيفية التشغيل

1. Clone the repository and open it in **Visual Studio 2022** or newer.  
2. Restore NuGet packages.  
3. Create a new SQL Server database named `project_clinic`.  
4. Execute the SQL script in `/Database/project_clinic_db.sql` to create tables and seed data.  
5. Update the connection string in `appsettings.json` if necessary:  
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=project_clinic;Trusted_Connection=True;"
}
````

6. Run the project (F5).

---

## 🌟 Features | المميزات

* Full CRUD operations for persons, doctors, patients, medical records, prescriptions, payments, and appointments.
* Responsive UI design with Bootstrap.
* Server-side data validation using Razor Pages.
* Database First approach using EF Core.
* Simple and clean user interface without authentication.
* No login or authentication system (simplified for educational purposes).

---

## 📸 Screenshots | لقطات شاشة

### 🟢 Home Page | الصفحة الرئيسية

![Home Page](https://github.com/abdo7806/project_clinic/blob/master/HomePage.png?raw=true)

### 🟢 Person Management | إدارة الأشخاص

![Person Management](https://github.com/abdo7806/project_clinic/blob/master/PersonManagement.png?raw=true)

### 🟢 Doctor Management | إدارة الأطباء

![Doctor Management](https://github.com/abdo7806/project_clinic/blob/master/DoctorManagement.png?raw=true)

### 🟢 Patient Management | إدارة المرضى

![Patient Management](https://github.com/abdo7806/project_clinic/blob/master/PatientManagement.png?raw=true)

### 🟢 Medical Records | السجلات الطبية

![Medical Records](https://github.com/abdo7806/project_clinic/blob/master/MedicalRecords.png?raw=true)

### 🟢 Prescriptions | الوصفات الطبية

![Prescriptions](https://github.com/abdo7806/project_clinic/blob/master/Prescriptions.png?raw=true)

### 🟢 Payments | المدفوعات

![Payments](https://github.com/abdo7806/project_clinic/blob/master/Payments.png?raw=true)

### 🟢 Appointments | المواعيد

![Appointments](https://github.com/abdo7806/project_clinic/blob/master/Appointments.png?raw=true)

---

## 👨‍💻 Developer | المطور

**\[اسمك]**

I'm a passionate developer with experience in ASP.NET Core, EF Core, and building responsive web applications.

🔗 GitHub: [github.com/abdo7806](https://github.com/abdo7806)
📧 Email: [balzhaby26@gmail.com](mailto:balzhaby26@gmail.com)
🌍 LinkedIn: [linkedin.com/in/abdulsalam-al-dhahabi-218887312](https://linkedin.com/in/abdulsalam-al-dhahabi-218887312)

---

## 🤝 Contributing | المساهمة

Contributions and feedback are welcome!
مرحبًا بالمساهمات والتعليقات!

---

## 📃 License | الترخيص

This project is open-source for learning and personal use only.
هذا المشروع مفتوح المصدر لأغراض التعلم والاستخدام الشخصي فقط.

---

```



