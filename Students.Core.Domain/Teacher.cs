namespace Students.Core.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CourseTecher> CourseTechers { get; set; }
    }

}