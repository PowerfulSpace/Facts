using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerfulSpace.Facts.Web.Data.Migrations
{
    public partial class changedPropertyAddAdressFromToAddressFrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddAdressTo",
                table: "Notifications",
                newName: "AddressTo");

            migrationBuilder.RenameColumn(
                name: "AddAdressFrom",
                table: "Notifications",
                newName: "AddressFrom");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_AddAdressTo",
                table: "Notifications",
                newName: "IX_Notifications_AddressTo");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_AddAdressFrom",
                table: "Notifications",
                newName: "IX_Notifications_AddressFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressTo",
                table: "Notifications",
                newName: "AddAdressTo");

            migrationBuilder.RenameColumn(
                name: "AddressFrom",
                table: "Notifications",
                newName: "AddAdressFrom");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_AddressTo",
                table: "Notifications",
                newName: "IX_Notifications_AddAdressTo");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_AddressFrom",
                table: "Notifications",
                newName: "IX_Notifications_AddAdressFrom");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
