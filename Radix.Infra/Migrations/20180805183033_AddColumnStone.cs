using Microsoft.EntityFrameworkCore.Migrations;

namespace Radix.Infra.Migrations
{
    public partial class AddColumnStone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcquirerMessage",
                table: "RegistroTransacaoStone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcquirerMessage",
                table: "RegistroTransacaoStone");
        }
    }
}
