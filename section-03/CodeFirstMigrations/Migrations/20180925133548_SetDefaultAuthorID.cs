using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelWithCodeFirstWorkflow.Migrations
{
    public partial class SetDefaultAuthorID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (PlutoContext context = new PlutoContext())
            {
                var authorId = new SqlParameter("@AuthorId", 1);
                context.Database.ExecuteSqlCommand(@"
                    UPDATE Courses
                    SET AuthorId = @AuthorId
                    WHERE AuthorId IS NULL;
                ", authorId);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (PlutoContext context = new PlutoContext())
            {
                var authorId = new SqlParameter("@AuthorId", 1);
                context.Database.ExecuteSqlCommand(@"
                    UPDATE Courses
                    SET AuthorId = NULL
                    WHERE AuthorId = @AuthorId;
                ", authorId);
            }
        }
    }
}
