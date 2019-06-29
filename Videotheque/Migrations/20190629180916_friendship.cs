using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Videotheque.Migrations
{
    public partial class friendship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Seen = table.Column<bool>(nullable: true),
                    Rated = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    DateRelease = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    MinAge = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    LanguageVO = table.Column<int>(nullable: false),
                    LanguageMedia = table.Column<int>(nullable: false),
                    LanguageSubtitles = table.Column<int>(nullable: false),
                    PhysicalSupport = table.Column<bool>(nullable: true),
                    NumericalSupport = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.MediaId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumSeason = table.Column<int>(nullable: false),
                    NumEpisode = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BroadcastDate = table.Column<DateTime>(nullable: false),
                    MediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_Episode_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMedias",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    MediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMedias", x => new { x.MediaId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GenreMedias_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonMedias",
                columns: table => new
                {
                    PersonMediaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Function = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    MediaId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMedias", x => x.PersonMediaId);
                    table.ForeignKey(
                        name: "FK_PersonMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonMedias_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_MediaId",
                table: "Episode",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMedias_GenreId",
                table: "GenreMedias",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMedias_MediaId",
                table: "PersonMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMedias_PersonId",
                table: "PersonMedias",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "GenreMedias");

            migrationBuilder.DropTable(
                name: "PersonMedias");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
