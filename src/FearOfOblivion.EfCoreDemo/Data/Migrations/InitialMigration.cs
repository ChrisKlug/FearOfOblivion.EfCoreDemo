using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FearOfOblivion.EfCoreDemo.Data.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("InitialMigration")]
    public class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>().Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<string>(),
                    FirstName = table.Column<string>(),
                    LastName = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>().Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(),
                    LastName = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>().Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(),
                    TeacherId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey("FK_Classes_Id_Teachers", x => x.TeacherId, "Teachers", "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                schema: "dbo",
                columns: table => new
                {
                    StudentId = table.Column<int>(),
                    ClassId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey("FK_StudentClasses_Id_Students", x => x.StudentId, "Students", "Id");
                    table.ForeignKey("FK_StudentClasses_Id_Classes", x => x.ClassId, "Classes", "Id");
                });
        }
    }
}
