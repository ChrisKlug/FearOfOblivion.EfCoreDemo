using System.Collections.Generic;

namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Student
    {
        private int? id;
        private List<Class> classes = new ();

        protected Student() { }

        public static Student Create(string studentId, string firstName, string lastName)
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
            classes.Add(@class);
        }

        public string StudentId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyList<Class> Classes => classes.AsReadOnly();
    }
}
