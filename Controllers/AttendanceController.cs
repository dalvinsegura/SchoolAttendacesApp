using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAttendacesApp.Data;
using SchoolAttendacesApp.Models;
using SchoolAttendacesApp.ViewModels;
using System.Text;

namespace SchoolAttendacesApp.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        private List<AttendanceRecord> GetAttendanceData()
        {
            return _context.Attendances
                .Include(a => a.Student)
                .Select(a => new AttendanceRecord
                {
                    StudentName = a.Student.Name,
                    Date = a.Date,
                    IsPresent = a.IsPresent
                })
                .ToList();
        }

        public IActionResult ExportToCsv()
        {
            var attendanceData = GetAttendanceData();

            var builder = new StringBuilder();
            builder.AppendLine("StudentName,Date,IsPresent");

            foreach (var record in attendanceData)
            {
                builder.AppendLine($"{record.StudentName},{record.Date},{record.IsPresent}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "AttendanceResume.csv");
        }

        public async Task<IActionResult> TakeAttendance(int classroomId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == classroomId);

            if (classroom == null)
            {
                return NotFound();
            }

            var viewModel = new AttendanceViewModel
            {
                ClassroomId = classroom.Id,
                ClassroomName = classroom.Name,
                Date = DateTime.Today,
                Students = classroom.Students.Select(s => new StudentAttendanceViewModel
                {
                    StudentId = s.Id,
                    StudentName = s.Name,
                    IsPresent = false
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAttendance(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var studentAttendance in model.Students)
                {
                    var attendance = new Attendance
                    {
                        StudentId = studentAttendance.StudentId,
                        Date = model.Date,
                        IsPresent = studentAttendance.IsPresent
                    };
                    _context.Attendances.Add(attendance);
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Asistencia guardada exitosamente.";
                return RedirectToAction("Details", "Classrooms", new { id = model.ClassroomId });
            }

            return View("TakeAttendance", model);
        }

        public async Task<IActionResult> ClassroomSummary(int classroomId)
        {
            var classroom = await _context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == classroomId);

            if (classroom == null)
            {
                return NotFound();
            }

            var attendances = await _context.Attendances
                .Where(a => a.Student.ClassroomId == classroomId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            var viewModel = new ClassroomSummaryViewModel
            {
                ClassroomId = classroom.Id,
                ClassroomName = classroom.Name,
                Students = classroom.Students,
                Attendances = attendances
            };

            return View(viewModel);
        }
    }
}