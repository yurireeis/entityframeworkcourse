using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelWithCodeFirstWorkflow.Migrations
{
    public partial class DatePublishedCourseColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Courses",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.DropColumn(
            name: "DatePublished",
            table: "Courses"
          );
        }
    }
}
