namespace SchoolAttendacesApp.ViewModels
{
    public class AttendanceViewModel
    {
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public DateTime Date { get; set; }
        public List<StudentAttendanceViewModel> Students { get; set; }
    }

    public class StudentAttendanceViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool IsPresent { get; set; }
    }
}
