﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDesStages.Server.Data.Migrations
{
    public partial class Etudiants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TelephoneCellulaire = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etudiant");
        }
    }
}
