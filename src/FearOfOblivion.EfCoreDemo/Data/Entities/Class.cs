using System.Collections.Generic;

namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Class
    {
        protected Class()
        {
            // Required by EF as it cannot pass in a Teacher
        }
        public Class(string name, Teacher teacher)
        {
            Name = name;
            Teacher = teacher;
        }

        public void ChangeTeacher(int teacherId)
        {
            TeacherId = teacherId;
            Teacher = null;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }
        public IList<StudentClass> Students { get; private set; }
    }
}
