using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("dacf3b2d-895d-4163-91a0-1891fc773444"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("ba71a310-3cbb-4728-8933-cbb668569462"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "Id",
                keyValue: new Guid("ba71a310-3cbb-4728-8933-cbb668569462"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "AddressId", "Avatar", "Email", "FullName", "about", "field" },
                values: new object[] { new Guid("dacf3b2d-895d-4163-91a0-1891fc773444"), null, "huda4.jpg", "huda.almamory@uobabylon.edu.iq", "Dr.Huda Naji Nawaf Al-Mamory", "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks", "Social Networks & recommender system" });
        }
    }
}
