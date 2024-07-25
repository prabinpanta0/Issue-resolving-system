using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHM.Migrations
{
    /// <inheritdoc />
    public partial class I9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackQuestionViewModel");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "IssueViewModel");

            migrationBuilder.DropTable(
                name: "ModuleViewModel");

            migrationBuilder.DropTable(
                name: "ResolvedIssuesViewModel");

            migrationBuilder.DropTable(
                name: "TeacherViewModel");

            migrationBuilder.DropTable(
                name: "FeedbackViewModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FeedbackQuestion1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion3Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion4Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher3Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Answer1 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer2 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer3 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer4 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestionId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId3 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_FeedbackQuestions_FeedbackQuestion1Id",
                        column: x => x.FeedbackQuestion1Id,
                        principalTable: "FeedbackQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_FeedbackQuestions_FeedbackQuestion2Id",
                        column: x => x.FeedbackQuestion2Id,
                        principalTable: "FeedbackQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_FeedbackQuestions_FeedbackQuestion3Id",
                        column: x => x.FeedbackQuestion3Id,
                        principalTable: "FeedbackQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_FeedbackQuestions_FeedbackQuestion4Id",
                        column: x => x.FeedbackQuestion4Id,
                        principalTable: "FeedbackQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Teachers_Teacher1Id",
                        column: x => x.Teacher1Id,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Teachers_Teacher2Id",
                        column: x => x.Teacher2Id,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Teachers_Teacher3Id",
                        column: x => x.Teacher3Id,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Answer1 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer2 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer3 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer4 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion1 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion2 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion3 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestion4 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestionId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId4 = table.Column<int>(type: "INTEGER", nullable: false),
                    Module1 = table.Column<string>(type: "TEXT", nullable: false),
                    Module2 = table.Column<string>(type: "TEXT", nullable: false),
                    Module3 = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher1 = table.Column<string>(type: "TEXT", nullable: false),
                    Teacher2 = table.Column<string>(type: "TEXT", nullable: false),
                    Teacher3 = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId3 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    RecommendedSolution = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResolvedIssuesViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IssueId = table.Column<int>(type: "INTEGER", nullable: false),
                    IssueTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolvedIssuesViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackQuestionViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FeedbackViewModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Q1 = table.Column<string>(type: "TEXT", nullable: false),
                    Q2 = table.Column<string>(type: "TEXT", nullable: false),
                    Q3 = table.Column<string>(type: "TEXT", nullable: false),
                    Q4 = table.Column<string>(type: "TEXT", nullable: false)
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
                    FeedbackViewModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
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
                    FeedbackViewModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Module = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "IX_Feedbacks_FeedbackQuestion1Id",
                table: "Feedbacks",
                column: "FeedbackQuestion1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackQuestion2Id",
                table: "Feedbacks",
                column: "FeedbackQuestion2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackQuestion3Id",
                table: "Feedbacks",
                column: "FeedbackQuestion3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackQuestion4Id",
                table: "Feedbacks",
                column: "FeedbackQuestion4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Teacher1Id",
                table: "Feedbacks",
                column: "Teacher1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Teacher2Id",
                table: "Feedbacks",
                column: "Teacher2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Teacher3Id",
                table: "Feedbacks",
                column: "Teacher3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleViewModel_FeedbackViewModelId",
                table: "ModuleViewModel",
                column: "FeedbackViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherViewModel_FeedbackViewModelId",
                table: "TeacherViewModel",
                column: "FeedbackViewModelId");
        }
    }
}
