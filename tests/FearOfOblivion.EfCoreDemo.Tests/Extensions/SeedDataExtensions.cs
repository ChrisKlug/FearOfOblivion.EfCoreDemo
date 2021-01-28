using FearOfOblivion.EfCoreDemo.Data;
using FearOfOblivion.EfCoreDemo.Data.Entities;

namespace FearOfOblivion.EfCoreDemo.Tests.Extensions
{
    public static class SeedDataExtensions
    {
        public static int AddSeedData(this SchoolContext context)
        {
            var chris = new Student("CK001", "Chris", "Klug");

            var jane = new Teacher("Jane", "Smith");
            var johan = new Teacher("Johan", "Olsson");

            var english = new Class("English 101", jane);
            var swedish = new Class("Swedish 101", johan);

            chris.Classes.Add(new StudentClass { Student = chris, Class = english });
            chris.Classes.Add(new StudentClass { Student = chris, Class = swedish });

            context.Set<Student>().Add(chris);

            context.SaveChanges();

            return chris.Id;
        }
    }
}
