using System.Collections.Generic;

namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Teacher
    {
        public Teacher(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IList<Class> Classes { get; private set; }
    }
}
