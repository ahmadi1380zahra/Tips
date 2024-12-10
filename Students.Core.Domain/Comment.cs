namespace Students.Core.Domain
{
    public class Comment
{

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
    }

}