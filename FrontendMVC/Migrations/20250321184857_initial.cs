using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FrontendMVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartnerDirector",
                columns: table => new
                {
                    IdPartnerDirector = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Patronymic = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdPartnerDirector);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartnerType",
                columns: table => new
                {
                    IdPartnerType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdPartnerType);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    IdProductType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdProductType);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    IdPartner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPartnerType = table.Column<int>(type: "int", nullable: false),
                    IdPartnerDirector = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    INN = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Address = table.Column<string>(type: "varchar(125)", maxLength: 125, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdPartner);
                    table.ForeignKey(
                        name: "fk_partner_partner_director1",
                        column: x => x.IdPartnerDirector,
                        principalTable: "PartnerDirector",
                        principalColumn: "IdPartnerDirector");
                    table.ForeignKey(
                        name: "fk_partner_partner_type",
                        column: x => x.IdPartnerType,
                        principalTable: "PartnerType",
                        principalColumn: "IdPartnerType");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdProductType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Article = table.Column<int>(type: "int", nullable: false),
                    MinimalPrice = table.Column<decimal>(type: "decimal(7,2)", precision: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdProduct);
                    table.ForeignKey(
                        name: "fk_Product_ProductType1",
                        column: x => x.IdProductType,
                        principalTable: "ProductType",
                        principalColumn: "IdProductType");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartnerProduct",
                columns: table => new
                {
                    IdPartnerProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdPartner = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdPartnerProduct);
                    table.ForeignKey(
                        name: "fk_PartnerProduct_Partner1",
                        column: x => x.IdPartner,
                        principalTable: "Partner",
                        principalColumn: "IdPartner");
                    table.ForeignKey(
                        name: "fk_PartnerProduct_Product1",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "IdProduct");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_partner_partner_director1_idx",
                table: "Partner",
                column: "IdPartnerDirector");

            migrationBuilder.CreateIndex(
                name: "fk_partner_partner_type_idx",
                table: "Partner",
                column: "IdPartnerType");

            migrationBuilder.CreateIndex(
                name: "fk_PartnerProduct_Partner1_idx",
                table: "PartnerProduct",
                column: "IdPartner");

            migrationBuilder.CreateIndex(
                name: "fk_PartnerProduct_Product1_idx",
                table: "PartnerProduct",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "fk_Product_ProductType1_idx",
                table: "Product",
                column: "IdProductType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerProduct");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PartnerDirector");

            migrationBuilder.DropTable(
                name: "PartnerType");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
