using Microsoft.EntityFrameworkCore.Migrations;

namespace ZoEazy.Api.Data.Migrations.ZoEazy
{
    public partial class Name_As_ComplexType_HumanName_II : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_MiddleInitial",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_MiddleInitial",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_MiddleInitial",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_MiddleInitial",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
