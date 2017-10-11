using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBlog.Migrations
{
    public partial class Simple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperiencePerson");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "experiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_experiences_PersonId",
                table: "experiences",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_experiences_People_PersonId",
                table: "experiences",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_experiences_People_PersonId",
                table: "experiences");

            migrationBuilder.DropIndex(
                name: "IX_experiences_PersonId",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "experiences");

            migrationBuilder.CreateTable(
                name: "ExperiencePerson",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencePerson", x => new { x.ExperienceId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_ExperiencePerson_experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperiencePerson_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePerson_PersonId",
                table: "ExperiencePerson",
                column: "PersonId");
        }
    }
}
