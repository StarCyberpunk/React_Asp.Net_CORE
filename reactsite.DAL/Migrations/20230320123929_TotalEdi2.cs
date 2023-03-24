using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactsite.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TotalEdi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Total",
                table: "Activity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Activity");
        }
    }
}
