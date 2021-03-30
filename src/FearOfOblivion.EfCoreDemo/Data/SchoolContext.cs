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
            modelBuilder.Entity<Student>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();

                x.HasKey(x => x.Id);
                x.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();

                x.HasKey(x => x.Id);
                x.ToTable("Teachers");
            });

            modelBuilder.Entity<Class>(x =>
            {
                x.Property(x => x.Id).UseIdentityColumn();

                x.HasOne(x => x.Teacher).WithMany(x => x.Classes);

                x.HasKey(x => x.Id);
                x.ToTable("Classes");
            });

            modelBuilder.Entity<StudentClass>(x =>
            {
                x.HasOne(x => x.Class).WithMany(x => x.Students).HasForeignKey("ClassId");
                x.HasOne(x => x.Student).WithMany(x => x.Classes).HasForeignKey("StudentId");

                x.HasKey("StudentId", "ClassId");
                x.ToTable("StudentClasses");
            });
        }

        public DbSet<Student> Students { get; set; }
    }
}
