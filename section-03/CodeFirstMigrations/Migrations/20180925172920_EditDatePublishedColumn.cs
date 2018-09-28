using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelWithCodeFirstWorkflow.Migrations
{
    public partial class EditDatePublishedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublished",
                table: "Courses",
                nullable: true,
                defaultValue: new DateTime(2018, 9, 25, 14, 29, 20, 437, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 9, 25, 13, 27, 23, 12, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublished",
                table: "Courses",
                nullable: true,
                defaultValue: new DateTime(2018, 9, 25, 13, 27, 23, 12, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 9, 25, 14, 29, 20, 437, DateTimeKind.Local));
        }
    }
}
