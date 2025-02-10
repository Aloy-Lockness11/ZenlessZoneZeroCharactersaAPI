using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZenlessZoneZeroCharacterAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Element = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddedDamage = table.Column<int>(type: "int", nullable: false),
                    AddedHealth = table.Column<int>(type: "int", nullable: false),
                    BonusType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BonusValue = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Damage", "Element", "Health", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 250, "Physical", 1500, "Billy Kid", "Attack" },
                    { 2, 180, "Ether", 1200, "Nicole Demara", "Support" },
                    { 3, 150, "Fire", 2000, "Soldier Eleven", "Defence" },
                    { 4, 300, "Ice", 1300, "Miyabi", "Attack" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AddedDamage", "AddedHealth", "BonusType", "BonusValue", "CharacterId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 50, 0, "Damage", 10, 1, "Blaster Pistol", "Weapon" },
                    { 2, 0, 100, "Health", 20, 2, "Energy Shield", "Accessory" },
                    { 3, 70, 0, "Damage", 15, 3, "Flame Thrower", "Weapon" },
                    { 4, 60, 0, "Damage", 20, 4, "Ice Blade", "Weapon" },
                    { 5, 0, 50, "Health", 10, 1, "Energy Booster", "Accessory" },
                    { 6, 0, 150, "Health", 30, 3, "Shield Generator", "Accessory" },
                    { 7, 80, 0, "Damage", 12, 2, "Rapid Fire Rifle", "Weapon" },
                    { 8, 90, 0, "Damage", 25, 4, "Wind Sword", "Weapon" },
                    { 9, 0, 200, "Health", 50, 2, "Healing Crystal", "Accessory" },
                    { 10, 0, 300, "Health", 70, 3, "Dragon Armor", "Accessory" },
                    { 11, 120, 0, "Damage", 18, 1, "Energy Pulse Cannon", "Weapon" },
                    { 12, 0, 120, "Health", 40, 4, "Ice Shield", "Accessory" },
                    { 13, 75, 0, "Damage", 17, 3, "Phoenix Blade", "Weapon" },
                    { 14, 65, 0, "Damage", 12, 2, "Electric Gauntlets", "Weapon" },
                    { 15, 0, 150, "Health", 35, 1, "Health Regenerator", "Accessory" },
                    { 16, 100, 0, "Damage", 22, 3, "Dragon's Claw", "Weapon" },
                    { 17, 110, 0, "Damage", 20, 4, "Thunderstorm Hammer", "Weapon" },
                    { 18, 0, 250, "Health", 60, 3, "Reflective Shield", "Accessory" },
                    { 19, 0, 80, "Health", 15, 2, "Energy Absorber", "Accessory" },
                    { 20, 0, 220, "Health", 50, 4, "Frostbite Armor", "Accessory" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
