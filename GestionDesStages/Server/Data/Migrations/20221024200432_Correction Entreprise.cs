using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesStages.Server.Data.Migrations
{
    public partial class CorrectionEntreprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prenomResponsable",
                table: "Entreprise",
                newName: "PrenomResponsable");

            migrationBuilder.RenameColumn(
                name: "posteTelephonique",
                table: "Entreprise",
                newName: "PosteTelephonique");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Entreprise",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Entreprise");

            migrationBuilder.RenameColumn(
                name: "PrenomResponsable",
                table: "Entreprise",
                newName: "prenomResponsable");

            migrationBuilder.RenameColumn(
                name: "PosteTelephonique",
                table: "Entreprise",
                newName: "posteTelephonique");
        }
    }
}
