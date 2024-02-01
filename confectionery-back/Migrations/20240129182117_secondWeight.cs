using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace confectionery_back.Migrations
{
    /// <inheritdoc />
    public partial class secondWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondWeight",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondWeight",
                table: "Orders");
        }
    }
}
