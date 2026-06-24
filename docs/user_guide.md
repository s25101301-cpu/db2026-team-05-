# User Guide — University Management System 2026

## Getting Started

### Prerequisites
- Windows OS
- Visual Studio 2022
- MS-SQL Server Express installed and running
- .NET Framework 4.7.2

### Installation
1. Clone or extract the project folder.
2. Open `UMS2026.sln` in Visual Studio 2022.
3. Right-click the solution → **Restore NuGet Packages** (installs Entity Framework 5.0).
4. Open `App.config` and verify the connection string points to your SQL Server instance:
   ```xml
   <add name="UniversityEntities"
        connectionString="Data Source=.\sqlexpress;Initial Catalog=University;Integrated Security=True"
        providerName="System.Data.SqlClient" />
   ```
5. Run the database schema script on your SQL Server to create all tables.
6. Press **F5** to build and launch the application.

---

## Logging In

When the application starts, the **Login Form** appears.

1. Enter your **Username** and **Password**.
2. Click the login button.
3. The system will open the appropriate dashboard based on your role:
   - **Administrator** → Admin Dashboard
   - **Instructor** → Instructor Dashboard
   - **Student** → Student Dashboard

If credentials are incorrect, an error message will appear. Re-enter the correct details and try again.

---

## Administrator Guide

The Admin Dashboard provides access to all management modules via buttons.

### Student Management
1. Click **Students** from the Admin Dashboard.
2. The Student Form opens, showing all students in the data grid.

| Action | Steps |
|---|---|
| View all students | Click **View / Refresh** button |
| Add a student | Fill in ID, Name, Department, Total Credits → click **Add** |
| Update a student | Enter the student ID, modify fields → click **Update** |
| Delete a student | Enter the student ID → click **Delete** |

> Note: The department must already exist before adding a student. The system will warn you if the department is not found.

### Instructor Management
1. Click **Instructors** from the Admin Dashboard.
2. View, add, update, or delete instructor records using the navigation toolbar.

### Department Management
1. Click **Departments** from the Admin Dashboard.
2. Manage department names, buildings, and budgets via the data grid.

### Course Management
1. Click **Courses** from the Admin Dashboard.
2. View and manage all courses including their title, department, and credit hours.

### Enrollment Management
1. Click **Enrollment** from the Admin Dashboard.
2. Manage student enrollment records (`takes` table) — link students to course sections with grades.

### Scheduling
1. Click **Scheduling** from the Admin Dashboard.
2. Manage time slots — set time slot IDs, days, start/end hours and minutes for class scheduling.

### Reports & Analysis
1. Click **Report & Analysis** from the Admin Dashboard.
2. View generated reports and analytics on students, courses, and enrollment data.

### Logout
- Click the **Logout** button on the Admin Dashboard to return to the Login Form.

---

## Instructor Guide

After logging in as an Instructor, the **Instructor Form** opens automatically.

- View instructor records loaded from the database.
- Use the navigation toolbar to browse records.
- Save any changes using the **Save** button in the toolbar.

---

## Student Guide

After logging in as a Student, the **Student Form** opens automatically.

- View your student profile and enrollment information.
- Use the navigation toolbar to browse records.

---

## Troubleshooting

| Problem | Solution |
|---|---|
| Cannot connect to database | Check that SQL Server Express is running and the connection string in `App.config` is correct |
| "Department does not exist" on student add | Add the department first via the Department Management form |
| "Student with this ID already exists" | Use a unique student ID |
| NuGet packages missing | Right-click solution → Restore NuGet Packages |
| Build errors after opening project | Ensure .NET Framework 4.7.2 is installed on your machine |
