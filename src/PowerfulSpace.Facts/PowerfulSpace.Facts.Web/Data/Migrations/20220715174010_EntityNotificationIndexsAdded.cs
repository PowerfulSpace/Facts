using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerfulSpace.Facts.Web.Data.Migrations
{
    public partial class EntityNotificationIndexsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AddAdressFrom",
                table: "Notifications",
                column: "AddAdressFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AddAdressTo",
                table: "Notifications",
                column: "AddAdressTo");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Content",
                table: "Notifications",
                column: "Content");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Subject",
                table: "Notifications",
                column: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notifications_AddAdressFrom",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AddAdressTo",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_Content",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_Subject",
                table: "Notifications");
        }
    }
}
