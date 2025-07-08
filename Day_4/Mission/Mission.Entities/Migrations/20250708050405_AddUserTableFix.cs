using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "User",
                newName: "modifieddate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "User",
                newName: "createddate");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email_address", "first_name", "last_name", "password" },
                values: new object[] { "raj@gmail.com", "Rajkumar", "Prajapati", "Raj@123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modifieddate",
                table: "User",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "User",
                newName: "CreatedDate");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email_address", "first_name", "last_name", "password" },
                values: new object[] { "admin@tatvasoft.com", "Tatva", "Admin", "Tatva@123" });
        }
    }
}
