namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class StudentClass
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
