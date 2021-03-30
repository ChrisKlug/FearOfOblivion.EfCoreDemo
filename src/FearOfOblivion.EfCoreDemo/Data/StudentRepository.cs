using FearOfOblivion.EfCoreDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FearOfOblivion.EfCoreDemo.Data
{
    public class StudentRepository
    {
        private readonly SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        public Task<Student> WithId(int id)
        {
            return context.Students
                            .Include(x => x.Classes)
                            .ThenInclude(x => x.Class)
                            .ThenInclude(x => x.Teacher)
                            .Where(x => x.Id == id)
                            .SingleOrDefaultAsync();
        }

        public Task<Student> WithStudentId(string studentId)
        {
            return context.Students
                            .Include(x => x.Classes)
                            .ThenInclude(x => x.Class)
                            .ThenInclude(x => x.Teacher)
                            .Where(x => x.StudentId == studentId)
                            .SingleOrDefaultAsync();
        }

        public Task<Student[]> InClass(string className)
        {
            return context.Students
                            .Include(x => x.Classes)
                            .ThenInclude(x => x.Class)
                            .ThenInclude(x => x.Teacher)
                            .Where(x => x.Classes.Any(x => x.Class.Name == className))
                            .ToArrayAsync();
        }
    }
}
