using FearOfOblivion.EfCoreDemo.Data;
using FearOfOblivion.EfCoreDemo.Data.Entities;

namespace FearOfOblivion.EfCoreDemo.Tests.Extensions
{
    public static class SeedDataExtensions
    {
        public static int AddSeedData(this SchoolContext context)
        {

            var jane = Teacher.Create("Jane", "Smith");
            var johan = Teacher.Create("Johan", "Olsson");

            var english = Class.Create("English 101", jane);
            var swedish = Class.Create("Swedish 101", johan);

            context.Set<Class>().AddRange(english, swedish);

            // Have to be saved first to give classes Ids
            // Otherwise adding the classes fails as it can't track
            // multiple StudentClass instances without Ids set for either
            context.SaveChanges();

            var chris = Student.Create(new StudentId("CK001"), "Chris", "Klug");
            chris.AddClass(english);
            chris.AddClass(swedish);

            context.Set<Student>().Add(chris);

            context.SaveChanges();

            return chris.GetPrivateValue<int>("id");
        }
    }
}
