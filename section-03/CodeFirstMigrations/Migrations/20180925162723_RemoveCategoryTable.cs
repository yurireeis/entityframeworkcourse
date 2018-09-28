using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelWithCodeFirstWorkflow.Migrations
{
    public partial class RemoveCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                table.PrimaryKey("PK_Categories", x => x.CategoryID);
            });
          
            migrationBuilder.Sql(@"
                INSERT INTO _Categories (Name) 
                SELECT Name FROM Categories
            ");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryID",
                table: "Courses"
            );

            migrationBuilder.DropTable(name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryID",
                table: "Courses"
            );

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Courses"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublished",
                table: "Courses",
                nullable: true,
                defaultValue: new DateTime(2018, 9, 25, 13, 27, 23, 12, DateTimeKind.Local),
                oldClrType: typeof(DateTime)
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublished",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2018, 9, 25, 13, 27, 23, 12, DateTimeKind.Local));

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Courses",
                nullable: true
            );

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryID",
                table: "Courses",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryID",
                table: "Courses",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.Sql(@"
                INSERT INTO Categories (Name) 
                SELECT Name FROM _Categories
            ");

            migrationBuilder.DropTable(name: "dbo._Categories");
        }
    }
}
