using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class SubjectGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrade_Students_StudentId",
                table: "SubjectGrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectGrade",
                table: "SubjectGrade");

            migrationBuilder.RenameTable(
                name: "SubjectGrade",
                newName: "SubjectGrades");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGrade_StudentId",
                table: "SubjectGrades",
                newName: "IX_SubjectGrades_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectGrades",
                table: "SubjectGrades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrades_Students_StudentId",
                table: "SubjectGrades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectGrades_Students_StudentId",
                table: "SubjectGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectGrades",
                table: "SubjectGrades");

            migrationBuilder.RenameTable(
                name: "SubjectGrades",
                newName: "SubjectGrade");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectGrades_StudentId",
                table: "SubjectGrade",
                newName: "IX_SubjectGrade_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectGrade",
                table: "SubjectGrade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGrade_Students_StudentId",
                table: "SubjectGrade",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
