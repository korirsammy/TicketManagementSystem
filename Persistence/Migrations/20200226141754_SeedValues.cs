using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Ticket 1" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Ticket 2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Ticket 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
