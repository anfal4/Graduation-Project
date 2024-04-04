using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class hi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_Address_AddressId",
                table: "admins");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_admins_AddressId",
                table: "admins");

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("475d9368-650a-4e61-868d-bfb7cd3f6c42"));

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "admins");

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("e6632577-5444-4fd5-91e0-3bccd97ee4b9"), "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("e6632577-5444-4fd5-91e0-3bccd97ee4b9"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "admins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("475d9368-650a-4e61-868d-bfb7cd3f6c42"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });

            migrationBuilder.CreateIndex(
                name: "IX_admins_AddressId",
                table: "admins",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ResearchId",
                table: "Comments",
                column: "ResearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_admins_Address_AddressId",
                table: "admins",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
