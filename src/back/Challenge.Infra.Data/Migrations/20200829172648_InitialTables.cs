using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace challenge.infra.data.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IncomePercentual = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    BankAccountType = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<long>(nullable: false),
                    Branch = table.Column<string>(maxLength: 10, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<int>(maxLength: 1, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(14,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountStatement",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    SourceBankAccountId = table.Column<long>(nullable: true),
                    DestinationBankAccountId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(maxLength: 1, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(14,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountStatement_BankAccount_DestinationBankAccountId",
                        column: x => x.DestinationBankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccountStatement_BankAccount_SourceBankAccountId",
                        column: x => x.SourceBankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_CustomerId",
                table: "BankAccount",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountStatement_DestinationBankAccountId",
                table: "BankAccountStatement",
                column: "DestinationBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountStatement_SourceBankAccountId",
                table: "BankAccountStatement",
                column: "SourceBankAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountStatement");

            migrationBuilder.DropTable(
                name: "InvestmentRules");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
