using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProject.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addMappingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "Mapping");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "Mapping",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
