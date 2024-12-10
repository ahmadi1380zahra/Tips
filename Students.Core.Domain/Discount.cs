namespace Students.Core.Domain
{
    public class Discount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int CourseId { get; set; }
    }

}