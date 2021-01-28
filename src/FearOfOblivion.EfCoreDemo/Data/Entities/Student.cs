using System.Collections.Generic;

namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Student
    {
        public Student(string studentId, string firstName, string lastName)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; private set; }
        public string StudentId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IList<StudentClass> Classes { get; private set; } = new List<StudentClass>();
    }
}
