using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.CoreSystem.Manager.Repository.Migrations
{
    public partial class FederalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "Manager",
                table: "Person",
                type: "VARCHAR(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(8)");

            migrationBuilder.AddColumn<string>(
                name: "FederalId",
                schema: "Manager",
                table: "Person",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FederalId",
                schema: "Manager",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "Manager",
                table: "Person",
                type: "VARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)");
        }
    }
}
