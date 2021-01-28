namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Class
    {
        private int? id;

        protected Class() { }

        public static Class Create(string name, Teacher teacher)
        {
            return new Class
            {
                Name = name,
                Teacher = teacher
            };
        }

        public void ChangeTeacher(int teacherId)
        {
            TeacherId = teacherId;
            Teacher = null;
        }

        public string Name { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }
    }
}
