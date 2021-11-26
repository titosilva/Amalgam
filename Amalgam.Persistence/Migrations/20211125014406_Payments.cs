using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amalgam.Persistence.Migrations
{
    public partial class Payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Gifts",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Gifts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PayerEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PayerMobile = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    TargetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_PaymentId",
                table: "Gifts",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Payment_PaymentId",
                table: "Gifts",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Payment_PaymentId",
                table: "Gifts");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_PaymentId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Gifts",
                newName: "Title");
        }
    }
}
