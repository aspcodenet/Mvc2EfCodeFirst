using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc2EfCodeFirst.Migrations
{
    public partial class Color2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Bil");

            migrationBuilder.AddColumn<int>(
                name: "BilColorId",
                table: "Bil",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMetallic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bil_BilColorId",
                table: "Bil",
                column: "BilColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bil_Color_BilColorId",
                table: "Bil",
                column: "BilColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bil_Color_BilColorId",
                table: "Bil");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Bil_BilColorId",
                table: "Bil");

            migrationBuilder.DropColumn(
                name: "BilColorId",
                table: "Bil");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Bil",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
