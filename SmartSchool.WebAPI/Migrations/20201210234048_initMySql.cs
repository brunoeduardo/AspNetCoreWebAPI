using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class initMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false),
                    DateInit = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateInit = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    DateInit = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Workload = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diciplines_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diciplines_Diciplines_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Diciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diciplines_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsDiscipline",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    DisciplineId = table.Column<int>(nullable: false),
                    DateInit = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    Grade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDiscipline", x => new { x.StudentId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_StudentsDiscipline_Diciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Diciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsDiscipline_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technologies for Business" },
                    { 2, "Information systems" },
                    { 3, "Computer science" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "Birth", "DateEnd", "DateInit", "Name", "Phone", "Registration", "Surname" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(1440), "Kevin", "33225555", 1, "Hart" },
                    { 2, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(4370), "Will", "3354288", 2, "Smith" },
                    { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(4450), "Ice", "55668899", 3, "Cube" },
                    { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(4460), "Jack", "6565659", 4, "Black" },
                    { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(4470), "Karen", "565685415", 5, "Gilian" },
                    { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(4480), "Katy", "456454545", 6, "Perry" },
                    { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(4490), "Stefani", "9874512", 7, "Joanne" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "DateEnd", "DateInit", "Name", "Phone", "Registration", "Surname" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2020, 12, 10, 20, 40, 47, 732, DateTimeKind.Local).AddTicks(9260), "Michael", null, 1, "Doll" },
                    { 2, true, null, new DateTime(2020, 12, 10, 20, 40, 47, 753, DateTimeKind.Local).AddTicks(2250), "Jacob", null, 2, "Smith" },
                    { 3, true, null, new DateTime(2020, 12, 10, 20, 40, 47, 753, DateTimeKind.Local).AddTicks(2310), "Tina", null, 3, "Kent" },
                    { 4, true, null, new DateTime(2020, 12, 10, 20, 40, 47, 753, DateTimeKind.Local).AddTicks(2320), "Karen", null, 4, "Harper" },
                    { 5, true, null, new DateTime(2020, 12, 10, 20, 40, 47, 753, DateTimeKind.Local).AddTicks(2320), "Susan", null, 5, "Lee" }
                });

            migrationBuilder.InsertData(
                table: "Diciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { 1, 1, "Math", null, 1, 0 },
                    { 2, 3, "Math", null, 1, 0 },
                    { 3, 3, "Physics", null, 2, 0 },
                    { 4, 1, "Portuguese", null, 3, 0 },
                    { 5, 1, "English", null, 4, 0 },
                    { 6, 2, "English", null, 4, 0 },
                    { 7, 3, "English", null, 4, 0 },
                    { 8, 1, "Programming", null, 5, 0 },
                    { 9, 2, "Programming", null, 5, 0 },
                    { 10, 3, "Programming", null, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateInit", "Grade" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7490), null },
                    { 4, 5, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7540), null },
                    { 2, 5, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7510), null },
                    { 1, 5, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7490), null },
                    { 7, 4, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7590), null },
                    { 6, 4, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7570), null },
                    { 5, 4, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7550), null },
                    { 4, 4, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7540), null },
                    { 1, 4, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7430), null },
                    { 7, 3, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7590), null },
                    { 5, 5, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7550), null },
                    { 6, 3, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7570), null },
                    { 7, 2, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7580), null },
                    { 6, 2, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7560), null },
                    { 3, 2, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7520), null },
                    { 2, 2, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7500), null },
                    { 1, 2, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(6390), null },
                    { 7, 1, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7580), null },
                    { 6, 1, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7560), null },
                    { 4, 1, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7530), null },
                    { 3, 1, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7510), null },
                    { 3, 3, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7530), null },
                    { 7, 5, null, new DateTime(2020, 12, 10, 20, 40, 47, 756, DateTimeKind.Local).AddTicks(7590), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diciplines_CourseId",
                table: "Diciplines",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Diciplines_PrerequisiteId",
                table: "Diciplines",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Diciplines_TeacherId",
                table: "Diciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDiscipline_DisciplineId",
                table: "StudentsDiscipline",
                column: "DisciplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentsDiscipline");

            migrationBuilder.DropTable(
                name: "Diciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
