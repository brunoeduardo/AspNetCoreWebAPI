using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diciplines", x => x.Id);
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
                    DisciplineId = table.Column<int>(nullable: false)
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
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 1, "Kevin", "33225555", "Hart" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 2, "Will", "3354288", "Smith" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 3, "Ice", "55668899", "Cube" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 4, "Jack", "6565659", "Black" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 5, "Karen", "565685415", "Gilian" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 6, "Katy", "456454545", "Perry" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 7, "Stefani", "9874512", "Joanne" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Michael" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Jacob" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Tina" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Karen" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Susan" });

            migrationBuilder.InsertData(
                table: "Diciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 1, "Math", 1 });

            migrationBuilder.InsertData(
                table: "Diciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 2, "Physics", 2 });

            migrationBuilder.InsertData(
                table: "Diciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 3, "Portuguese", 3 });

            migrationBuilder.InsertData(
                table: "Diciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 4, "English", 4 });

            migrationBuilder.InsertData(
                table: "Diciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 5, "Programming", 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Diciplines_TeacherId",
                table: "Diciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDiscipline_DisciplineId",
                table: "StudentsDiscipline",
                column: "DisciplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsDiscipline");

            migrationBuilder.DropTable(
                name: "Diciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
