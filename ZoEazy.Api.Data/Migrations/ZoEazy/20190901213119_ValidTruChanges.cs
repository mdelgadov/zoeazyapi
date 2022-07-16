using Microsoft.EntityFrameworkCore.Migrations;

namespace ZoEazy.Api.Data.Migrations.ZoEazy
{
    public partial class ValidTruChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidThruMonth",
                table: "SubscriberCreditCards");

            migrationBuilder.DropColumn(
                name: "ValidThruYear",
                table: "SubscriberCreditCards");

            migrationBuilder.DropColumn(
                name: "ValidThruMonth",
                table: "CustomerCreditCards");

            migrationBuilder.DropColumn(
                name: "ValidThruYear",
                table: "CustomerCreditCards");

            migrationBuilder.AddColumn<int>(
                name: "ValidThru_Month",
                table: "SubscriberCreditCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "ValidThru_Year",
                table: "SubscriberCreditCards",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "ValidThru_Month",
                table: "CustomerCreditCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "ValidThru_Year",
                table: "CustomerCreditCards",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidThru_Month",
                table: "SubscriberCreditCards");

            migrationBuilder.DropColumn(
                name: "ValidThru_Year",
                table: "SubscriberCreditCards");

            migrationBuilder.DropColumn(
                name: "ValidThru_Month",
                table: "CustomerCreditCards");

            migrationBuilder.DropColumn(
                name: "ValidThru_Year",
                table: "CustomerCreditCards");

            migrationBuilder.AddColumn<int>(
                name: "ValidThruMonth",
                table: "SubscriberCreditCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValidThruYear",
                table: "SubscriberCreditCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValidThruMonth",
                table: "CustomerCreditCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValidThruYear",
                table: "CustomerCreditCards",
                nullable: false,
                defaultValue: 0);
        }
    }
}
