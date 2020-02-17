using Microsoft.EntityFrameworkCore.Migrations;

namespace BHHC.Database.Migrations
{
    public partial class UpdateReasons2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "I have used .NET Core since before version 1.0 and each iteration has been a joy to learn and code. I am excited to bring my experience to the table and offer ideas on how best to leverage .NET Core as BHHC moves toward a microservice architecture.", 2 });

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "In my experience, the best and most productive teams are filled with people who are always ready to learn and improve. There's no room for ego when it comes to finding the best solution to a problem, and I look forward to working with people who are ready to learn, teach, and grow together. From the interactions I've had with BHHC so far, I feel that's exactly the culture I'd find.", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "I have used .NET Core since before version 1.0 and each iteration has been a joy to code with. I am excited to bring my experience to the table and offer ideas on how best to leverage .NET Core as BHHC moves toward a microservice architecture.", 2 });

            migrationBuilder.UpdateData(
                table: "FantasticReasons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "DisplayOrder" },
                values: new object[] { "In my experience, the best and most productive teams are filled with people who are always ready to learn and improve. There's no room for ego when it comes to finding the best solution to a problem, and I look forward to working with people who are ready to learn, teach, and grow together. From the interactions I've had with BHHC so far, I feel that's exactly the culture I'd find and would enjoy being part of.", 1 });
        }
    }
}
