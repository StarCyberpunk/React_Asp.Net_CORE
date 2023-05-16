using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactsite.DAL.Migrations
{
    /// <inheritdoc />
    public partial class editDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_DailyTasks_DailyTasksId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "DailyTasks");

            migrationBuilder.DropColumn(
                name: "NowActivity",
                table: "DailyTasks");

            migrationBuilder.RenameColumn(
                name: "DailyTasksId",
                table: "Activity",
                newName: "DayTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_DailyTasksId",
                table: "Activity",
                newName: "IX_Activity_DayTaskId");

            migrationBuilder.CreateTable(
                name: "DayTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyTasksId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NowActivity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayTasks_DailyTasks_DailyTasksId",
                        column: x => x.DailyTasksId,
                        principalTable: "DailyTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayTasks_DailyTasksId",
                table: "DayTasks",
                column: "DailyTasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_DayTasks_DayTaskId",
                table: "Activity",
                column: "DayTaskId",
                principalTable: "DayTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_DayTasks_DayTaskId",
                table: "Activity");

            migrationBuilder.DropTable(
                name: "DayTasks");

            migrationBuilder.RenameColumn(
                name: "DayTaskId",
                table: "Activity",
                newName: "DailyTasksId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_DayTaskId",
                table: "Activity",
                newName: "IX_Activity_DailyTasksId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "DailyTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NowActivity",
                table: "DailyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Day", "NowActivity" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_DailyTasks_DailyTasksId",
                table: "Activity",
                column: "DailyTasksId",
                principalTable: "DailyTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
