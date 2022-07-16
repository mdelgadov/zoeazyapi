using Microsoft.EntityFrameworkCore.Migrations;

namespace ZoEazy.Api.Data.Migrations.ZoEazy
{
    public partial class Name_As_ComplexType_HumanName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchAddresses_States_State_Id",
                table: "BranchAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_States_State_Id",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_FranchiseAddresses_States_State_Id",
                table: "FranchiseAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriberAddresses_States_State_Id",
                table: "SubscriberAddresses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "AspNetUsers",
                newName: "Name_MiddleInitial");

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "SubscriberAddresses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "FranchiseAddresses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_First",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Last",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Middle",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_MiddleInitial",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "CustomerAddresses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "BranchAddresses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_First",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Last",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Middle",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchAddresses_States_State_Id",
                table: "BranchAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_States_State_Id",
                table: "CustomerAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FranchiseAddresses_States_State_Id",
                table: "FranchiseAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriberAddresses_States_State_Id",
                table: "SubscriberAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchAddresses_States_State_Id",
                table: "BranchAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_States_State_Id",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_FranchiseAddresses_States_State_Id",
                table: "FranchiseAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriberAddresses_States_State_Id",
                table: "SubscriberAddresses");

            migrationBuilder.DropColumn(
                name: "Name_First",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_Last",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_Middle",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_MiddleInitial",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name_First",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name_Last",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name_Middle",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Name_MiddleInitial",
                table: "AspNetUsers",
                newName: "MiddleName");

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "SubscriberAddresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "FranchiseAddresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "CustomerAddresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "State_Id",
                table: "BranchAddresses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchAddresses_States_State_Id",
                table: "BranchAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_States_State_Id",
                table: "CustomerAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FranchiseAddresses_States_State_Id",
                table: "FranchiseAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriberAddresses_States_State_Id",
                table: "SubscriberAddresses",
                column: "State_Id",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
