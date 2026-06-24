# Architecture — University Management System 2026

## Overview
UMS2026 follows a classic **3-Layer Windows Forms** architecture: UI (Forms) → Business/Data Access (Entity Framework) → Database (MS-SQL Server).

```
┌─────────────────────────────────────────────┐
│               Presentation Layer             │
│  LoginForm  AdminForm  StudentForm           │
│  InstructorForm  DepartmentForm  CourseForm  │
│  EnrollmentForm  SchedulingForm  Report      │
└──────────────────┬──────────────────────────┘
                   │
┌──────────────────▼──────────────────────────┐
│           Data Access Layer                  │
│  Entity Framework 5.0 (Code-First/EDMX)     │
│  UniversityEntities (DbContext)              │
│  UniversityDataSet (Typed DataSet)           │
└──────────────────┬──────────────────────────┘
                   │
┌──────────────────▼──────────────────────────┐
│              Database Layer                  │
│  MS-SQL Server Express                       │
│  Database: University                        │
└─────────────────────────────────────────────┘
```

---

## Project Structure

```
yukiayen/
├── UMS2026.sln
├── packages/
│   └── EntityFramework.5.0.0/          # NuGet dependency
└── UMS2026/
    ├── Program.cs                       # Entry point → LoginForm
    ├── App.config                       # DB connection string
    ├── UniversityModel.edmx             # EF EDMX model diagram
    ├── UniversityModel.Context.cs       # DbContext (UniversityEntities)
    ├── UniversityDataSet.xsd            # Typed DataSet schema
    │
    ├── — Entity Models (EF auto-generated) —
    ├── student.cs
    ├── instructor.cs
    ├── department.cs
    ├── course.cs
    ├── section.cs
    ├── take.cs
    ├── advisor.cs
    ├── classroom.cs
    ├── time_slot.cs
    ├── user.cs
    │
    └── — Forms (UI) —
        ├── Form1.cs / LoginForm         # Login & role routing
        ├── AdminForm.cs                 # Admin dashboard
        ├── StudentForm.cs               # Student CRUD
        ├── InstructorForm.cs            # Instructor management
        ├── DepartmentForm.cs            # Department management
        ├── CourseForm.cs                # Course management
        ├── EnrollmentForm.cs            # Enrollment (takes table)
        ├── SchedulingForm.cs            # Time slot scheduling
        └── Report & Analysis.cs         # Reports & analytics
```

---

## Database Schema

### Tables & Relationships

```
user            (ID, Username, Password, role)
department      (dept_name PK, building, budget)
instructor      (ID PK, name, dept_name FK→department, salary)
student         (ID PK, name, dept_name FK→department, tot_cred)
advisor         (s_ID FK→student, i_ID FK→instructor)
course          (course_id PK, title, dept_name FK→department, credits)
classroom       (building PK, room_number PK, capacity)
time_slot       (time_slot_id, day, start_hr, start_min, end_hr, end_min)
section         (course_id FK→course, sec_id, semester, year,
                 building/room FK→classroom, time_slot_id)
takes           (ID FK→student, course_id, sec_id, semester, year, grade)
```

### Entity Relationship Summary

```
department  ◄──  student    ◄──  takes  ──►  section  ◄──  instructor
     │                │                           │
     └──►  course ────┘               classroom ──┘
               │
           section ──► time_slot
```

---

## Authentication & Role Routing

`LoginForm` queries the `users` table and routes to a role-specific form:

| Role | Form Opened |
|---|---|
| `administrator` | AdminForm |
| `instructor` | InstructorForm |
| `student` | StudentForm |

---

## Key Technologies

| Component | Technology |
|---|---|
| Language | C# (.NET Framework 4.7.2) |
| UI Framework | Windows Forms |
| ORM | Entity Framework 5.0 |
| Database | MS-SQL Server Express |
| Data Binding | Typed DataSet + BindingSource |
| Project Format | Visual Studio 2022 `.csproj` |
