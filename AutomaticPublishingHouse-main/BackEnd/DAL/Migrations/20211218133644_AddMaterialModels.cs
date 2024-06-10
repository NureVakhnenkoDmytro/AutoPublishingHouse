using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMaterialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Editions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrintingPressId",
                table: "Editions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Editions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Dyes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Black" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Content", "DyeId", "Format", "Name" },
                values: new object[] { 1, "Some Content", 1, "A4", "First" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Content", "DyeId", "Format", "Name" },
                values: new object[] { 2, "Some Content", 1, "A4", "Second" });

            migrationBuilder.CreateIndex(
                name: "IX_Editions_MaterialId",
                table: "Editions",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Editions_PrintingPressId",
                table: "Editions",
                column: "PrintingPressId");

            migrationBuilder.CreateIndex(
                name: "IX_Editions_UserId",
                table: "Editions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Editions_Materials_MaterialId",
                table: "Editions",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Editions_PrintingPresses_PrintingPressId",
                table: "Editions",
                column: "PrintingPressId",
                principalTable: "PrintingPresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Editions_Users_UserId",
                table: "Editions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editions_Materials_MaterialId",
                table: "Editions");

            migrationBuilder.DropForeignKey(
                name: "FK_Editions_PrintingPresses_PrintingPressId",
                table: "Editions");

            migrationBuilder.DropForeignKey(
                name: "FK_Editions_Users_UserId",
                table: "Editions");

            migrationBuilder.DropIndex(
                name: "IX_Editions_MaterialId",
                table: "Editions");

            migrationBuilder.DropIndex(
                name: "IX_Editions_PrintingPressId",
                table: "Editions");

            migrationBuilder.DropIndex(
                name: "IX_Editions_UserId",
                table: "Editions");

            migrationBuilder.DeleteData(
                table: "Dyes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Editions");

            migrationBuilder.DropColumn(
                name: "PrintingPressId",
                table: "Editions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Editions");
        }
    }
}
