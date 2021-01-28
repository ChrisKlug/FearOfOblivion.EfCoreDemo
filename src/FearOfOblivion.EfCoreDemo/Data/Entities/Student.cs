using System.Collections.Generic;
using System.Linq;

namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Student
    {
        private int? id;
        private List<StudentClass> classes = new ();

        protected Student() { }

        public static Student Create(StudentId studentId, string firstName, string lastName)
        {
            return new Student
            {
                StudentId = studentId,
                FirstName = firstName,
                LastName = lastName,
            };
        }

        public void AddClass(Class @class)
        {
            classes.Add(new StudentClass { Student = this, Class = @class });
        }

        public StudentId StudentId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyList<Class> Classes => classes.Select(x => x.Class).ToList().AsReadOnly();
    }
}
