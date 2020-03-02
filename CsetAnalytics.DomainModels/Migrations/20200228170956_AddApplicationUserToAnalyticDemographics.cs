using Microsoft.EntityFrameworkCore.Migrations;

namespace CsetAnalytics.DomainModels.Migrations
{
    public partial class AddApplicationUserToAnalyticDemographics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnalyticDemographicFK",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "AnalyticDemographics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AnalyticDemographicFK",
                table: "AspNetUsers",
                column: "AnalyticDemographicFK");

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticDemographics_AspNetUserId",
                table: "AnalyticDemographics",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalyticDemographics_AspNetUsers_AspNetUserId",
                table: "AnalyticDemographics",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AnalyticDemographics_AnalyticDemographicFK",
                table: "AspNetUsers",
                column: "AnalyticDemographicFK",
                principalTable: "AnalyticDemographics",
                principalColumn: "AnalyticDemographicId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalyticDemographics_AspNetUsers_AspNetUserId",
                table: "AnalyticDemographics");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AnalyticDemographics_AnalyticDemographicFK",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AnalyticDemographicFK",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnalyticDemographics_AspNetUserId",
                table: "AnalyticDemographics");

            migrationBuilder.DropColumn(
                name: "AnalyticDemographicFK",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "AnalyticDemographics");
        }
    }
}
