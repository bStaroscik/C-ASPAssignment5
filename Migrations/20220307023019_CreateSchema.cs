using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment4.Migrations
{
    public partial class CreateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelCalcItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartOdometer = table.Column<int>(nullable: false),
                    EndOdometer = table.Column<int>(nullable: false),
                    AmountOfFuel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostOfFuel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelCalcItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FuelCalcItems",
                columns: new[] { "Id", "AmountOfFuel", "CostOfFuel", "EndOdometer", "StartOdometer" },
                values: new object[] { 1, 50m, 25.5m, 100, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelCalcItems");
        }
    }
}
