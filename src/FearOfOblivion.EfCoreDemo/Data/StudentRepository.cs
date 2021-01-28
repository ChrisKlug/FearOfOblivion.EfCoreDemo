using FearOfOblivion.EfCoreDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FearOfOblivion.EfCoreDemo.Data
{
    public class StudentRepository
    {
        public StudentRepository(SchoolContext context)
        {
            Students = context.Set<Student>().Include("classes.Class.Teacher");
        }

        public Task<Student> WithId(int id)
        {
            return Students
                        .Where(x => EF.Property<int>(x, "id") == id)
                        .SingleOrDefaultAsync();
        }

        public Task<Student> WithStudentId(string studentId)
        {
            return Students
                        .Where(x => x.StudentId == studentId)
                        .SingleOrDefaultAsync();
        }

        public Task<Student[]> InClass(string className)
        {
            return Students
                        .Where(x => EF.Property<List<StudentClass>>(x, "classes").Any(x => x.Class.Name == className))
                        .ToArrayAsync();
        }

        private IQueryable<Student> Students { get; }
    }
}
