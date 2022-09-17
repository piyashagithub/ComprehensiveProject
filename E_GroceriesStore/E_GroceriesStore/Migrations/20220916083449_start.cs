using Microsoft.EntityFrameworkCore.Migrations;

namespace E_GroceriesStore.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryModel",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryModel", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "LoginModel",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModel", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "ResponseModel",
                columns: table => new
                {
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseModel", x => x.Message);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Phone = table.Column<double>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BuyModel",
                columns: table => new
                {
                    BuyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GroceryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyModel", x => x.BuyId);
                    table.ForeignKey(
                        name: "FK_BuyModel_GroceryModel_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "GroceryModel",
                        principalColumn: "GroceryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuyModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartModel",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GroceryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartModel", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_CartModel_GroceryModel_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "GroceryModel",
                        principalColumn: "GroceryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    GroceryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderModel_GroceryModel_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "GroceryModel",
                        principalColumn: "GroceryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RatingModel",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: false),
                    GroceryId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingModel", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_RatingModel_GroceryModel_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "GroceryModel",
                        principalColumn: "GroceryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RatingModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyModel_GroceryId",
                table: "BuyModel",
                column: "GroceryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyModel_UserId",
                table: "BuyModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartModel_GroceryId",
                table: "CartModel",
                column: "GroceryId");

            migrationBuilder.CreateIndex(
                name: "IX_CartModel_UserId",
                table: "CartModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_GroceryId",
                table: "OrderModel",
                column: "GroceryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_UserId",
                table: "OrderModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingModel_GroceryId",
                table: "RatingModel",
                column: "GroceryId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingModel_UserId",
                table: "RatingModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyModel");

            migrationBuilder.DropTable(
                name: "CartModel");

            migrationBuilder.DropTable(
                name: "LoginModel");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "RatingModel");

            migrationBuilder.DropTable(
                name: "ResponseModel");

            migrationBuilder.DropTable(
                name: "GroceryModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
