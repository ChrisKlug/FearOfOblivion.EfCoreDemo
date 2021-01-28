using FearOfOblivion.EfCoreDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                x.Property("id").HasColumnName("Id").UseIdentityColumn();

                x.Ignore(x => x.Classes);

                x.HasKey("id");
                x.ToTable("Students");
            });

            modelBuilder.Entity<Class>(x =>
            {
                x.Property("id").HasColumnName("Id").UseIdentityColumn();

                x.HasMany<Student>("students").WithMany(x => x.Classes)
                                            .UsingEntity<Dictionary<string, object>>(
                                                "StudentClasses",
                                                x => x.HasOne<Student>()
                                                        .WithMany()
                                                        .HasForeignKey("StudentId"),
                                                x => x.HasOne<Class>()
                                                        .WithMany()
                                                        .HasForeignKey("ClassId")
                                            );

                x.HasOne(x => x.Teacher).WithMany().HasForeignKey("TeacherId");

                x.HasKey("id");
                x.ToTable("Classes");
            });

            modelBuilder.Entity<Teacher>(x =>
            {
                x.Property("id").HasColumnName("Id").UseIdentityColumn();

                x.HasKey("id");
                x.ToTable("Teachers");
            });
        }
    }
}
