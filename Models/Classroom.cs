namespace SchoolAttendacesApp.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
