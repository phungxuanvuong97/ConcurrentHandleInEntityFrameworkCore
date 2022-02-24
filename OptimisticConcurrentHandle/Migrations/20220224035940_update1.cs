using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OptimisticConcurrentHandle.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Buyer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Pencil",
                columns: table => new
                {
                    PencilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Buyed = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pencil", x => x.PencilId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData("User", new string[] { "UserId", "Balance" }, new object[] { Guid.NewGuid(), 100 });
            migrationBuilder.InsertData("User", new string[] { "UserId", "Balance" }, new object[] { Guid.NewGuid(), 100 });


            migrationBuilder.InsertData("Pencil", new string[] { "PencilId", "Color" }, new object[] { Guid.NewGuid(), "red" });
            migrationBuilder.InsertData("Pencil", new string[] { "PencilId", "Color" }, new object[] { Guid.NewGuid(), "blue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pencil");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
