using Microsoft.EntityFrameworkCore.Migrations;

namespace BHHC.Database.Migrations
{
    public partial class SeedCandidates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "DJ", "Hubka" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "DisplayOrder", "Reason" },
                values: new object[] { 1, 1, 1, "Reason 1" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "DisplayOrder", "Reason" },
                values: new object[] { 2, 1, 2, "Reason 2" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "DisplayOrder", "Reason" },
                values: new object[] { 3, 1, 3, "Reason 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
