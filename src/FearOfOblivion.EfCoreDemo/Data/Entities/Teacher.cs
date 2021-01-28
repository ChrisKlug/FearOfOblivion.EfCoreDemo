namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public class Teacher
    {
        private int id;

        protected Teacher() {}

        public static Teacher Create(string firstName, string lastName)
        {
            return new Teacher
            {
                FirstName = firstName,
                LastName = lastName
            };
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
