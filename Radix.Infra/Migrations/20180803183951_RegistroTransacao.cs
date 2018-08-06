using Microsoft.EntityFrameworkCore.Migrations;

namespace Radix.Infra.Migrations
{
    public partial class RegistroTransacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroTransacaoCielo",
                columns: table => new
                {
                    MerchantOrderId = table.Column<string>(nullable: false),
                    ProofOfSale = table.Column<string>(nullable: true),
                    Tid = table.Column<string>(nullable: true),
                    AuthorizationCode = table.Column<string>(nullable: true),
                    PaymentId = table.Column<string>(nullable: true),
                    LojaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroTransacaoCielo", x => x.MerchantOrderId);
                    table.ForeignKey(
                        name: "FK_RegistroTransacaoCielo_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroTransacaoStone",
                columns: table => new
                {
                    OrderReference = table.Column<string>(nullable: false),
                    AuthorizationCode = table.Column<string>(nullable: true),
                    TransactionIdentifier = table.Column<string>(nullable: true),
                    TransactionKey = table.Column<string>(nullable: true),
                    UniqueSequentialNumber = table.Column<string>(nullable: true),
                    LojaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroTransacaoStone", x => x.OrderReference);
                    table.ForeignKey(
                        name: "FK_RegistroTransacaoStone_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacaoCielo_LojaId",
                table: "RegistroTransacaoCielo",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacaoStone_LojaId",
                table: "RegistroTransacaoStone",
                column: "LojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroTransacaoCielo");

            migrationBuilder.DropTable(
                name: "RegistroTransacaoStone");
        }
    }
}
