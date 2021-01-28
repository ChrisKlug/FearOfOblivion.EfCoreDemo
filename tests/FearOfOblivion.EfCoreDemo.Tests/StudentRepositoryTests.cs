using FearOfOblivion.EfCoreDemo.Data;
using FearOfOblivion.EfCoreDemo.Data.Entities;
using FearOfOblivion.EfCoreDemo.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace FearOfOblivion.EfCoreDemo.Tests
{
    public class StudentRepositoryTests : IDisposable
    {
        IDbContextTransaction transaction;
        StudentRepository students;
        int id;

        public StudentRepositoryTests()
        {
            var dir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.Parent.Parent;
            var path = Path.Combine(dir.FullName, "Data\\EfCoreDemo.mdf");
            var connstring = "Server=(LocalDB)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + path;

            var config = new DbContextOptionsBuilder<SchoolContext>()
                            .UseSqlServer(connstring)
                            .LogTo(x => Debug.WriteLine(x), LogLevel.Debug)
                            .EnableSensitiveDataLogging(true);

            var context = new SchoolContext(config.Options);
            students = new StudentRepository(context);

            context.Database.Migrate();

            transaction = context.Database.BeginTransaction();

            id = context.AddSeedData();
        }

        [Fact]
        public async Task Can_get_student_by_id()
        {
            var student = await students.WithId(id);

            ValidateStudent(student);
        }

        [Fact]
        public async Task Can_get_student_by_student_id()
        {
            var student = await students.WithStudentId(new StudentId("CK001"));

            ValidateStudent(student);
        }

        [Fact]
        public async Task Can_get_students_in_class()
        {
            var studentsInClass = await students.InClass("English 101");

            var student = Assert.Single(studentsInClass);
            ValidateStudent(student);
        }

        private static void ValidateStudent(Student student) 
        {
            Assert.NotNull(student);
            Assert.NotNull(student.Classes);

            var english = Assert.Single(student.Classes, x => x.Name == "English 101");
            Assert.NotNull(english.Teacher);
            Assert.Equal("Jane", english.Teacher.FirstName);
            Assert.Equal("Smith", english.Teacher.LastName);

            var swedish = Assert.Single(student.Classes, x => x.Name == "Swedish 101");
            Assert.NotNull(swedish.Teacher);
            Assert.Equal("Johan", swedish.Teacher.FirstName);
            Assert.Equal("Olsson", swedish.Teacher.LastName);
        }

        public void Dispose()
        {
            transaction.Dispose();
        }
    }
}
