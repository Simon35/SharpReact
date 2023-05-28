using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpReact.Migrations
{
    /// <inheritdoc />
    public partial class initupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Citizens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Citizens",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Citizens");
        }
    }
}
