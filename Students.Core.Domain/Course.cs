namespace Students.Core.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool IsDelete { get; set; }
        public Discount Discount { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
        public List<CourseTecher> CourseTeachers { get; set; }

    }

}