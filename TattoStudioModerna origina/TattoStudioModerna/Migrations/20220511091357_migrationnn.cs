using Microsoft.EntityFrameworkCore.Migrations;

namespace TattoStudioModerna.Migrations
{
    public partial class migrationnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Tatto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TattoImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TattoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TattoImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TattoImage_Tatto_TattoId",
                        column: x => x.TattoId,
                        principalTable: "Tatto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tatto_OrderId",
                table: "Tatto",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TattoImage_TattoId",
                table: "TattoImage",
                column: "TattoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tatto_Order_OrderId",
                table: "Tatto",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tatto_Order_OrderId",
                table: "Tatto");

            migrationBuilder.DropTable(
                name: "TattoImage");

            migrationBuilder.DropIndex(
                name: "IX_Tatto_OrderId",
                table: "Tatto");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Tatto");
        }
    }
}
