using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPonto.Api.Migrations
{
    public partial class Dbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_Email",
                table: "Logins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_TokenLogin",
                table: "Logins",
                column: "TokenLogin",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Logins_Email",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_TokenLogin",
                table: "Logins");
        }
    }
}
