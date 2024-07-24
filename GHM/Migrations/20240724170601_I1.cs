using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHM.Migrations
{
    /// <inheritdoc />
    public partial class I1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Q1 = table.Column<string>(type: "TEXT", nullable: false),
                    Q2 = table.Column<string>(type: "TEXT", nullable: false),
                    Q3 = table.Column<string>(type: "TEXT", nullable: false),
                    Q4 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Answer1 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer2 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer3 = table.Column<string>(type: "TEXT", nullable: false),
                    Answer4 = table.Column<string>(type: "TEXT", nullable: false),
                    FeedbackQuestionId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId2 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId3 = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestionId4 = table.Column<int>(type: "INTEGER", nullable: false),
                    Module1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Module2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Module3Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher3Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion3Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedbackQuestion4Id = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Feedbacks_Modules_Module1Id",
                        column: x => x.Module1Id,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Modules_Module2Id",
                        column: x => x.Module2Id,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Modules_Module3Id",
                        column: x => x.Module3Id,
                        principalTable: "Modules",
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
                name: "IX_Feedbacks_Module1Id",
                table: "Feedbacks",
                column: "Module1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Module2Id",
                table: "Feedbacks",
                column: "Module2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Module3Id",
                table: "Feedbacks",
                column: "Module3Id");

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
                name: "IX_Teachers_ModuleId",
                table: "Teachers",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbackQuestions");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
