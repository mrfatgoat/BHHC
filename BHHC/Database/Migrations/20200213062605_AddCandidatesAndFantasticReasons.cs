using Microsoft.EntityFrameworkCore.Migrations;

namespace BHHC.Database.Migrations
{
    public partial class AddCandidatesAndFantasticReasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FantasticReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayOrder = table.Column<int>(nullable: false, defaultValue: 1),
                    Reason = table.Column<string>(maxLength: 255, nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasticReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasticReasons_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasticReasons_CandidateId_DisplayOrder",
                table: "FantasticReasons",
                columns: new[] { "CandidateId", "DisplayOrder" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasticReasons");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
