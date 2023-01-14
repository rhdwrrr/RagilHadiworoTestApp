using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RagilHadiworoApp.Migrations
{
    public partial class Slate001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IDCustomer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IDCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Agunans",
                columns: table => new
                {
                    AgunanID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IDCustomer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agunans", x => x.AgunanID);
                    table.ForeignKey(
                        name: "FK_Agunans_Customers_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customers",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fundings",
                columns: table => new
                {
                    IDFunding = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IDCustomer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundings", x => x.IDFunding);
                    table.ForeignKey(
                        name: "FK_Fundings_Customers_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customers",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lendings",
                columns: table => new
                {
                    IDLending = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IDCustomer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Plafond = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lendings", x => x.IDLending);
                    table.ForeignKey(
                        name: "FK_Lendings_Customers_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customers",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agunans_IDCustomer",
                table: "Agunans",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Fundings_IDCustomer",
                table: "Fundings",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Lendings_IDCustomer",
                table: "Lendings",
                column: "IDCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agunans");

            migrationBuilder.DropTable(
                name: "Fundings");

            migrationBuilder.DropTable(
                name: "Lendings");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
