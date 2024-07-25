using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHM.Migrations
{
    /// <inheritdoc />
    public partial class I3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackQuestionId2",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackQuestionId3",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackQuestionId4",
                table: "Feedbacks");

            migrationBuilder.CreateTable(
                name: "FeedbackViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Module1 = table.Column<string>(type: "TEXT", nullable: false),
                    Module2 = table.Column<string>(type: "TEXT", nullable: false),
                    Module3 = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher1 = table.Column<string>(type: "TEXT", nullable: false),
                    Teacher2 = table.Column<string>(type: "TEXT", nullable: false),
                    Teacher3 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestionId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId4 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion1 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion2 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion3 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion4 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer1 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer2 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer3 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer4 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackQuestionViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Q1 = table.Column<string>(type: "TEXT", nullable: false),
                    Q2 = table.Column<string>(type: "TEXT", nullable: false),
                    Q3 = table.Column<string>(type: "TEXT", nullable: false),
                    Q4 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackViewModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackQuestionViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackQuestionViewModel_FeedbackViewModel_FeedbackViewModelId",
                        column: x => x.FeedbackViewModelId,
                        principalTable: "FeedbackViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModuleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackViewModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleViewModel_FeedbackViewModel_FeedbackViewModelId",
                        column: x => x.FeedbackViewModelId,
                        principalTable: "FeedbackViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Module = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackViewModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherViewModel_FeedbackViewModel_FeedbackViewModelId",
                        column: x => x.FeedbackViewModelId,
                        principalTable: "FeedbackViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackQuestionViewModel_FeedbackViewModelId",
                table: "FeedbackQuestionViewModel",
                column: "FeedbackViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleViewModel_FeedbackViewModelId",
                table: "ModuleViewModel",
                column: "FeedbackViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherViewModel_FeedbackViewModelId",
                table: "TeacherViewModel",
                column: "FeedbackViewModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackQuestionViewModel");

            migrationBuilder.DropTable(
                name: "ModuleViewModel");

            migrationBuilder.DropTable(
                name: "TeacherViewModel");

            migrationBuilder.DropTable(
                name: "FeedbackViewModel");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackQuestionId2",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackQuestionId3",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackQuestionId4",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
