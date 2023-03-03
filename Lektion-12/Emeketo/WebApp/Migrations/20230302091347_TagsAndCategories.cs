using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class TagsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryEntityProductEntity",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsSKU = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntityProductEntity", x => new { x.CategoriesId, x.ProductsSKU });
                    table.ForeignKey(
                        name: "FK_CategoryEntityProductEntity_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEntityProductEntity_Products_ProductsSKU",
                        column: x => x.ProductsSKU,
                        principalTable: "Products",
                        principalColumn: "SKU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntityTagEntity",
                columns: table => new
                {
                    ProductsSKU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntityTagEntity", x => new { x.ProductsSKU, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ProductEntityTagEntity_Products_ProductsSKU",
                        column: x => x.ProductsSKU,
                        principalTable: "Products",
                        principalColumn: "SKU",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductEntityTagEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntityProductEntity_ProductsSKU",
                table: "CategoryEntityProductEntity",
                column: "ProductsSKU");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntityTagEntity_TagsId",
                table: "ProductEntityTagEntity",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEntityProductEntity");

            migrationBuilder.DropTable(
                name: "ProductEntityTagEntity");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
