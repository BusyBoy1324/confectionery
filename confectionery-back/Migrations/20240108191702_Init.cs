using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace confectionery_back.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biscuits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biscuits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cookies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fillings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fillings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Filling = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dough = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    IssuedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryMethod = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrepayment = table.Column<bool>(type: "bit", nullable: false),
                    PrepaymentAmout = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCounter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biscuits");

            migrationBuilder.DropTable(
                name: "Cookies");

            migrationBuilder.DropTable(
                name: "Fillings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
