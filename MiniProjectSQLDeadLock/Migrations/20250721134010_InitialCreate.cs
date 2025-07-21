using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectSQLDeadLock.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        ProductId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Qty = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.ProductId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vendors",
            //    columns: table => new
            //    {
            //        VendorId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vendors", x => x.VendorId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Requests",
            //    columns: table => new
            //    {
            //        RequestId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        VendorId = table.Column<int>(type: "int", nullable: false),
            //        Qty = table.Column<int>(type: "int", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Requests", x => x.RequestId);
            //        table.ForeignKey(
            //            name: "FK_Requests_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "ProductId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Requests_Vendors_VendorId",
            //            column: x => x.VendorId,
            //            principalTable: "Vendors",
            //            principalColumn: "VendorId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requests_ProductId",
            //    table: "Requests",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requests_VendorId",
            //    table: "Requests",
            //    column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
