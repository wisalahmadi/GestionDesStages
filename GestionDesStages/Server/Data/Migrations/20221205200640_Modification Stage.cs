using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesStages.Server.Data.Migrations
{
    public partial class ModificationStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stage_Id",
                table: "Stage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Entreprise_Id",
                table: "Stage",
                column: "Id",
                principalTable: "Entreprise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Entreprise_Id",
                table: "Stage");

            migrationBuilder.DropIndex(
                name: "IX_Stage_Id",
                table: "Stage");
        }
    }
}
