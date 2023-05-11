using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CoronaDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: true),
                    InfectionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    InfectionRecoveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaDetails", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    Street = table.Column<string>(type: "longtext", nullable: false),
                    BuildingNumber = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    MobileNumber = table.Column<string>(type: "longtext", nullable: false),
                    CoronaDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_CoronaDetails_CoronaDetailsId",
                        column: x => x.CoronaDetailsId,
                        principalTable: "CoronaDetails",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VaccinesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VaccinationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VaccineManufacture = table.Column<string>(type: "longtext", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinesInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinesInfo_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CoronaDetails_EmployeeId",
                table: "CoronaDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CoronaDetailsId",
                table: "Employees",
                column: "CoronaDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinesInfo_EmployeeId",
                table: "VaccinesInfo",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoronaDetails_Employees_EmployeeId",
                table: "CoronaDetails",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoronaDetails_Employees_EmployeeId",
                table: "CoronaDetails");

            migrationBuilder.DropTable(
                name: "VaccinesInfo");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "CoronaDetails");
        }
    }
}
