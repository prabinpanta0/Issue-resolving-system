using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHM.Migrations
{
    /// <inheritdoc />
    public partial class I8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleId1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ModuleId2",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ModuleId3",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Q1",
                table: "FeedbackQuestions");

            migrationBuilder.DropColumn(
                name: "Q2",
                table: "FeedbackQuestions");

            migrationBuilder.DropColumn(
                name: "Q3",
                table: "FeedbackQuestions");

            migrationBuilder.RenameColumn(
                name: "Q4",
                table: "FeedbackQuestions",
                newName: "Qn");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "IssueViewModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "IssueViewModel");

            migrationBuilder.RenameColumn(
                name: "Qn",
                table: "FeedbackQuestions",
                newName: "Q4");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId1",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModuleId2",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModuleId3",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Q1",
                table: "FeedbackQuestions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Q2",
                table: "FeedbackQuestions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Q3",
                table: "FeedbackQuestions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
