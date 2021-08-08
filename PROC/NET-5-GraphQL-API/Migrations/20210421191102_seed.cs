using Microsoft.EntityFrameworkCore.Migrations;

namespace CommanderGQL.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "LicenseKey", "Name" },
                values: new object[,]
                {
                    { 1, "1111111", ".NET 5" },
                    { 2, "2222222", "Docker" },
                    { 3, "3333333", "Windows" },
                    { 4, "4444444", "Ubuntu" },
                    { 5, "5555555", "Kubernetes" },
                    { 6, "666666", "RedHat" }
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandLine", "HowTo", "PlatformId" },
                values: new object[,]
                {
                    { 1, "CommandLine1", "HowTo .NET 5", 1 },
                    { 10, "CommandLine10", "HowTo .NET 5-1", 1 },
                    { 11, "CommandLine11", "HowTo .NET 5-2", 1 },
                    { 2, "CommandLine2", "HowTo Docker", 2 },
                    { 3, "CommandLine3", "HowTo Windows", 3 },
                    { 4, "CommandLine4", "HowTo Ubuntu", 4 },
                    { 5, "CommandLine5", "HowTo Kubernetes", 5 },
                    { 6, "CommandLine6", "HowTo RedHat1", 6 },
                    { 7, "CommandLine7", "HowTo RedHat2", 6 },
                    { 8, "CommandLine8", "HowTo RedHat3", 6 },
                    { 9, "CommandLine9", "HowTo RedHat4", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_PlatformId",
                table: "Commands",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
