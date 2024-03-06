using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class Subject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubjectGrades");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectGrades_SubjectId",
                table: "SubjectGrades",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectId",
                table: "SubjectGrades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Subjects_SubjectId",
                table: "SubjectGrades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_SubjectGrades_SubjectId",
                table: "SubjectGrades");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectGrades");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubjectGrades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
