using Microsoft.EntityFrameworkCore.Migrations;

namespace BHHC.Database.Migrations
{
    public partial class UpdateReasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "Description", "DisplayOrder", "Reason" },
                values: new object[] { 4, 1, "I've spent most of my career as a full-stack dev using AngularJS and C#. Most recently I have held a primarily back-end role and since then I have had a strong desire to learn more modern front-end web technologies. While my expertise today is in AngularJS, I have exposure to both React and Angular 7+ and a strong desire to work with a team to deepen my knowledge.", 3, "Desire to return to a full-stack development position" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "Description", "DisplayOrder", "Reason" },
                values: new object[] { 5, 1, "I have used .NET Core since before version 1.0 and each iteration has been a joy to code with. I am excited to bring my experience to the table and offer ideas on how best to leverage .NET Core as BHHC moves toward a microservice architecture.", 2, "Eager to continue working with .NET Core" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "Description", "DisplayOrder", "Reason" },
                values: new object[] { 6, 1, "In my experience, the best and most productive teams are filled with people who are always ready to learn and improve. There's no room for ego when it comes to finding the best solution to a problem, and I look forward to working with people who are ready to learn, teach, and grow together. From the interactions I've had with BHHC so far, I feel that's exactly the culture I'd find and would enjoy being part of.", 1, "Excited to be a part of a collaborative, cohesive, and open-minded team" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "Description", "DisplayOrder", "Reason" },
                values: new object[] { 1, 1, "I've spent most of my career as a full-stack dev using AngularJS and C#. Most recently I have held a primarily back-end role and since then I have had a strong desire to learn more modern front-end web technologies. While my expertise today is in AngularJS, I have exposure to both React and Angular 7+ and a strong desire to work with a team to deepen my knowledge.", 3, "Desire to return to a full-stack development position" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "Description", "DisplayOrder", "Reason" },
                values: new object[] { 2, 1, "I have used .NET Core since before version 1.0 and each iteration has been a joy to code with. I am excited to bring my experience to the table and offer ideas on how best to leverage .NET Core as BHHC moves toward a microservice architecture.", 2, "Eager to continue working with .NET Core" });

            migrationBuilder.InsertData(
                table: "FantasticReasons",
                columns: new[] { "Id", "CandidateId", "Description", "DisplayOrder", "Reason" },
                values: new object[] { 3, 1, "In my experience, the best and most productive teams are filled with people who are always ready to learn and improve. There's no room for ego when it comes to finding the best solution to a problem, and I look forward to working with people who are ready to learn, teach, and grow together. From the interactions I've had with BHHC so far, I feel that's exactly the culture I'd find and would enjoy being part of.", 1, "Excited to be a part of a collaborative, cohesive, and open-minded team" });
        }
    }
}
