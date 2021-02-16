using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaycheckAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    document = table.Column<string>(type: "text", nullable: false),
                    grossWage = table.Column<decimal>(type: "numeric", nullable: false),
                    admissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    hasHealthPlan = table.Column<bool>(type: "boolean", nullable: false),
                    hasDentalPlan = table.Column<bool>(type: "boolean", nullable: false),
                    hasTransportationVouchersDiscount = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
