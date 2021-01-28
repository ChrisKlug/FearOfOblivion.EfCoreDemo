using FearOfOblivion.EfCoreDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FearOfOblivion.EfCoreDemo.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentClass>(x =>
            {
                x.HasOne(x => x.Class).WithMany().HasForeignKey("ClassId");
                x.HasOne(x => x.Student).WithMany("classes").HasForeignKey("StudentId");

                x.HasKey("StudentId", "ClassId");
                x.ToTable("StudentClasses");
            });

            modelBuilder.Entity<Student>(x =>
            {
                x.Property("id").HasColumnName("Id").UseIdentityColumn();

                x.Ignore(x => x.Classes);

                x.HasKey("id");
                x.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>(x =>
            {
                x.Property("id").HasColumnName("Id").UseIdentityColumn();

                x.HasKey("id");
                x.ToTable("Teachers");
            });

            modelBuilder.Entity<Class>(x =>
            {
                x.Property("id").HasColumnName("Id").UseIdentityColumn();

                x.HasOne(x => x.Teacher).WithMany().HasForeignKey("TeacherId");

                x.HasKey("id");
                x.ToTable("Classes");
            });
        }
    }
}
