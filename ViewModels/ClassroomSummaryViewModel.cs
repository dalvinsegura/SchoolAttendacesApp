using SchoolAttendacesApp.Models;

namespace SchoolAttendacesApp.ViewModels
{
    public class ClassroomSummaryViewModel
    {
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public List<Student> Students { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}