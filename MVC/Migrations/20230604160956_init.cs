using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hedgehogs.MVC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hedgehog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SpikeCount = table.Column<int>(type: "int", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hedgehog", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hedgehog",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Radius", "SpikeCount" },
                values: new object[,]
                {
                    { 1, "i float.", "Miguel", "https://i.imgur.com/oZMaKdl.png", 7.6100000000000003, 4200 },
                    { 2, "Wanted for multiple war crimes in Serbia during the 90s", "Lalo", "https://i.imgur.com/AljAtSn.jpeg", 10.0, 9999 },
                    { 3, "henlo fren i smol, i also love commiting tax fraud on my free time", "Juan", "https://i.imgur.com/vmz0s3z.jpeg", 3.1400000000000001, 3142 },
                    { 4, "Should i add you to my menu? Human is my second favourite meal.", "Antonio", "https://i.imgur.com/gC7ruMc.jpeg", 20.0, 5023 },
                    { 5, "Gotta Go Fast", "Sonic", "https://i.imgur.com/yqsMMuh.png", 50.0, 3 },
                    { 6, "I share wisdom with puny mortals. The sky is blue, Miguel Floats, If you are Bosnian avoid Lalo At all costs and you may not want to cross Antonio in General... There were more of us until he arrived.. Not even Pablo could escape him.", "José", "https://i.imgur.com/PKqN5gl.jpeg", 2.0, 2239 },
                    { 7, "heh? José and wisdom? nice one. He has lost his mind after that Pablo incident and thinks he is an immortal being or something.Anyways listen to me carefully bud, there's only one true wisdom:you either a smart fella or a fart smella.", "Franco", "https://i.imgur.com/4HeZJTE.jpeg", 7.7000000000000002, 6053 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hedgehog");
        }
    }
}
