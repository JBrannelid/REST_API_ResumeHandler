using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_ResumeHandler.Migrations
{
    /// <inheritdoc />
    public partial class Updatetypomisstakes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Persons",
                newName: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Persons",
                newName: "EmailAdress");
        }
    }
}
