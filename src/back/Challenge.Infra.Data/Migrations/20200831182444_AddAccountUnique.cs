using Microsoft.EntityFrameworkCore.Migrations;

namespace challenge.infra.data.Migrations
{
    public partial class AddAccountUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountNumber",
                table: "BankAccount",
                column: "AccountNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BankAccount_AccountNumber",
                table: "BankAccount");
        }
    }
}
