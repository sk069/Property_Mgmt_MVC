﻿using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Property_Mgmt_MVC.Migrations
{
    public partial class Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealer_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dealer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dealer_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Facilities = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property_Detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property_oction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bid_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Property_DetailId = table.Column<int>(type: "int", nullable: false),
                    Customer_DetailId = table.Column<int>(type: "int", nullable: false),
                    Dealer_DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property_oction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_oction_Customer_Detail_Customer_DetailId",
                        column: x => x.Customer_DetailId,
                        principalTable: "Customer_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_oction_Dealer_Detail_Dealer_DetailId",
                        column: x => x.Dealer_DetailId,
                        principalTable: "Dealer_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_oction_Property_Detail_Property_DetailId",
                        column: x => x.Property_DetailId,
                        principalTable: "Property_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_oction_Customer_DetailId",
                table: "Property_oction",
                column: "Customer_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_oction_Dealer_DetailId",
                table: "Property_oction",
                column: "Dealer_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_oction_Property_DetailId",
                table: "Property_oction",
                column: "Property_DetailId");

            var sqlFile = Path.Combine(".\\DBscript", @"Database.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property_oction");

            migrationBuilder.DropTable(
                name: "Customer_Detail");

            migrationBuilder.DropTable(
                name: "Dealer_Detail");

            migrationBuilder.DropTable(
                name: "Property_Detail");
        }
    }
}
