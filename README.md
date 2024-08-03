
# Attendance Control Web App

This web application is designed to manage attendance in a school setting. Built with ASP.NET Core, Entity Framework, MVC, Bootstrap, and SQL Server, the app allows users to register classrooms, add students to these classrooms, and perform modifications such as editing or deleting both classrooms and students. Additionally, users can take attendance, view summaries of attendance, and download these summaries as CSV files.




## Features
#### Classroom Management:
- Register new classrooms.
- Edit existing classrooms.
- Delete classrooms.
#### Student Management:
- Add students to classrooms.
- Edit student details.
- Remove students from classrooms.
#### Attendance Taking
- Mark student's attendance within a classroom.
- View detailed attendance summaries for each classroom.
#### Attendance Summary:

- Generate attendance summaries for classrooms.
- Download attendance summaries as CSV files for easy sharing and analysis.



## Minimum Functional Objective

The app aims to achieve a basic functional goal by enabling the registration of classrooms and students, solely requiring the name of the classroom and the name of the student for efficient attendance control.
## Tech Stack

**Client:** MVC, Bootstrap

**Server:** ASP.NET Core, Entity Framework, SQL Server


## Installation

    1. Clone the Repository:

```bash
  git clone https://github.com/dalvinsegura/SchoolAttendacesApp.git
```

    2. Database Configuration: 
        - Ensure SQL Server is installed and running.
        - Update the connection string in appsettings.json to match your SQL Server configuration.

    3. Run Migrations:
        - Use the Entity Framework CLI or Package Manager Console to apply migrations and create the database schema.
        - dotnet ef database update 
    4. Build and Run the Application:
        - dotnet build
        - dotnet run
## Usage/Examples

- Register Classrooms:

    - Navigate to the 'Classrooms' section to add new classrooms.

- Add Students:
    - Within a classroom, go to the 'Students' section to add students.

- Take Attendance:

    - Select a classroom and mark the attendance for each student.
- View and Download Summaries:

    - Go to the 'Attendance Summary' section, select the classroom, and view or download the summary as a CSV file.
## Screenshots
![image](https://github.com/user-attachments/assets/87b8b048-e5cc-4964-8f43-540bb0e0789f)
![image](https://github.com/user-attachments/assets/4c7418bb-9176-4ece-8a46-b003d9474678)
  ![image](https://github.com/user-attachments/assets/a79bccc8-27dc-4cb3-b9b7-cf47dc299c01)





## License

This project is licensed under the [MIT License.](LICENSE.txt)

