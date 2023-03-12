using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactsite.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NowActivity",
                table: "DailyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoneType",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "NowActivity",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NowActivity",
                table: "DailyTasks");

            migrationBuilder.DropColumn(
                name: "DoneType",
                table: "Activity");
        }
    }
}
