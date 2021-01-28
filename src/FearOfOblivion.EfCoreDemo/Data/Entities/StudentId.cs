using System;
using System.Text.RegularExpressions;

namespace FearOfOblivion.EfCoreDemo.Data.Entities
{
    public struct StudentId
    {
        private static Regex ValidationRegex = new Regex("[A-Z]{2}[0-9]{0}");
        private string id;

        public StudentId(string id)
        {
            if (!ValidationRegex.IsMatch(id))
            {
                throw new ArgumentException("Invalid StudentId format", nameof(id));
            }

            this.id = id;
        }

        public override string ToString()
        {
            return id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine("StudentId", id);
        }
        public override bool Equals(object obj) => obj switch
            {
                string str when str == this.id => true,
                StudentId id when id.id == this.id => true,
                _ => false
            };
        public static bool operator ==(StudentId a, StudentId b) => a.id == b.id;
        public static bool operator !=(StudentId a, StudentId b) => a.id != b.id;
        public static bool operator ==(StudentId a, string b) => a.id == b;
        public static bool operator !=(StudentId a, string b) => a.id != b;
    }
}
