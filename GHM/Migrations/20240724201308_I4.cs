using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHM.Migrations
{
    /// <inheritdoc />
    public partial class I4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Modules_Module1Id",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Modules_Module2Id",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Modules_Module3Id",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Module1Id",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Module2Id",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Module3Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Module1Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Module2Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Module3Id",
                table: "Feedbacks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Module1Id",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Module2Id",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Module3Id",
                table: "Feedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Modules_Module1Id",
                table: "Feedbacks",
                column: "Module1Id",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Modules_Module2Id",
                table: "Feedbacks",
                column: "Module2Id",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Modules_Module3Id",
                table: "Feedbacks",
                column: "Module3Id",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
