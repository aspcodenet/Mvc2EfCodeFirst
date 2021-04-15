using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc2EfCodeFirst.Migrations
{
    public partial class AddedcolortoBil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Bil",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Bil");
        }
    }
}
