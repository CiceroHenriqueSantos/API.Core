using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.CoreSystem.Manager.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Manager");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Nationality = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    State = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person",
                schema: "Manager");
        }
    }
}
