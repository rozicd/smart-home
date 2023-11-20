using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class restoringDeletedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivationTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalConditionsSensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Connection = table.Column<string>(type: "text", nullable: false),
                    PowerSupply = table.Column<int>(type: "integer", nullable: false),
                    EnergySpending = table.Column<float>(type: "real", nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DeviceStatus = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalConditionsSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentalConditionsSensors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaSquareMeters = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfFloors = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("015cbc63-6ea1-4217-8234-831e23fe0322"), "Sweden" },
                    { new Guid("056f06bd-029b-4f8e-90e5-2528f86c1e22"), "New Zealand" },
                    { new Guid("05f3f7cc-0997-4fbd-abc5-87ab010ac8f2"), "Hungary" },
                    { new Guid("10b916c0-47bb-4569-ac25-9a5d701da007"), "France" },
                    { new Guid("1594284e-863c-41e7-b1db-9f3101b96936"), "Russia" },
                    { new Guid("15d0e6cb-b865-47e9-87c2-2953158812fa"), "Finland" },
                    { new Guid("1d47a669-2e6f-410a-8883-812b8b658b8e"), "Japan" },
                    { new Guid("1ee7b386-0ea0-4ce9-8c7e-bf2d5d83ea22"), "India" },
                    { new Guid("1f810588-fefa-461e-9d32-a35e1f7ba6b4"), "Argentina" },
                    { new Guid("26b99ed2-6dbf-48ee-9652-4ef0b9cf8fce"), "Switzerland" },
                    { new Guid("31cadbad-04af-45ce-b819-c66f18b5dce2"), "Australia" },
                    { new Guid("3a1867a0-ba63-4e85-b133-3d1901944071"), "Thailand" },
                    { new Guid("3e559040-5049-4db0-bb68-a629849864bb"), "Ireland" },
                    { new Guid("64e2577a-2fbd-48c2-8c24-e01885bb5b62"), "Canada" },
                    { new Guid("77a9349b-c6cf-4111-99b7-3a23e91735a6"), "Egypt" },
                    { new Guid("7c184f96-4f48-4ef6-ba41-d215735bb410"), "Austria" },
                    { new Guid("7fbdf75f-4197-4b23-a092-45cde1781af5"), "Belgium" },
                    { new Guid("8557ea04-40b1-49da-b728-fa5e078729da"), "Vietnam" },
                    { new Guid("863fbc7d-7a96-4ef2-9921-18cf0c9f06ca"), "Germany" },
                    { new Guid("87774cd0-84ab-40c2-9ac6-e462d94dc906"), "South Korea" },
                    { new Guid("8fa1ad7f-237b-45cf-b127-e674521813c0"), "USA" },
                    { new Guid("9fb89163-a652-4a7f-957f-ff2dd1ed33f1"), "Czech Republic" },
                    { new Guid("a5593b3d-8a4a-4ae3-bb06-5bbbeb13270b"), "Poland" },
                    { new Guid("a9e850d7-4fd5-4eff-bf23-7c1b549686c9"), "Italy" },
                    { new Guid("acafaa13-4d70-4fed-89ef-116dcf570ea6"), "Kenya" },
                    { new Guid("bc315f9e-5d45-4c8f-ad74-e866e1873c38"), "Turkey" },
                    { new Guid("c50c25ba-a5bb-46bb-85ab-e13dda5da9d4"), "Mexico" },
                    { new Guid("cfab1176-d51c-4c95-8e60-9e2dceb6b9aa"), "Norway" },
                    { new Guid("d50f17c7-1f1e-4b3f-9859-4ccae11ffd3c"), "Spain" },
                    { new Guid("d6a4f7ef-79fe-457e-b97a-5a90a38e2803"), "South Africa" },
                    { new Guid("dfe4fff3-e9ab-4008-97bd-bc2006e8a8de"), "Portugal" },
                    { new Guid("e586d2a1-eff6-4911-a627-251467328dff"), "Singapore" },
                    { new Guid("e6778174-8607-4e67-8205-811b0da7be8b"), "UAE" },
                    { new Guid("e775ca30-1f8e-4393-b853-1524e704a1b9"), "Netherlands" },
                    { new Guid("f0f38290-a7f7-44ab-89c7-cfa714b4f83f"), "Nigeria" },
                    { new Guid("f14f3d20-8a2a-4c7f-af5e-364c0563091e"), "Brazil" },
                    { new Guid("f4478d08-809e-415e-b0a6-4dbc8fec270f"), "UK" },
                    { new Guid("f6848c99-428f-4ebe-a051-95b856117395"), "China" },
                    { new Guid("fe003fd7-510b-4967-b7ea-bcf53048c54e"), "Greece" },
                    { new Guid("ff0af716-735c-444c-a313-3e9d9ecf8189"), "Denmark" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("132c26df-bec8-4575-b1d3-5940aaa061d1"), new Guid("015cbc63-6ea1-4217-8234-831e23fe0322"), "Stockholm" },
                    { new Guid("194d4745-a4e5-414b-a1a8-e267e110d9a2"), new Guid("64e2577a-2fbd-48c2-8c24-e01885bb5b62"), "Toronto" },
                    { new Guid("2a91a6e9-6af3-4020-8fc1-d7d10c7f5033"), new Guid("bc315f9e-5d45-4c8f-ad74-e866e1873c38"), "Istanbul" },
                    { new Guid("33f4d714-411b-44d4-a6c9-01adac7b28e9"), new Guid("e6778174-8607-4e67-8205-811b0da7be8b"), "Dubai" },
                    { new Guid("3a5568d6-8121-4ee2-be26-06dcb7fc8de7"), new Guid("1f810588-fefa-461e-9d32-a35e1f7ba6b4"), "Buenos Aires" },
                    { new Guid("3a894cac-d058-4f51-a30c-653786f32e09"), new Guid("1594284e-863c-41e7-b1db-9f3101b96936"), "Moscow" },
                    { new Guid("3d4d0ad4-715c-486f-90d4-14f16ca03d09"), new Guid("26b99ed2-6dbf-48ee-9652-4ef0b9cf8fce"), "Zurich" },
                    { new Guid("41009ec9-fbff-4942-8401-6b6ddb87828d"), new Guid("05f3f7cc-0997-4fbd-abc5-87ab010ac8f2"), "Budapest" },
                    { new Guid("427bb942-9a5d-407b-b94d-f45cd3aa7833"), new Guid("f6848c99-428f-4ebe-a051-95b856117395"), "Hong Kong" },
                    { new Guid("441fc69c-213f-4628-aa5e-6f1edb82a3e7"), new Guid("f0f38290-a7f7-44ab-89c7-cfa714b4f83f"), "Lagos" },
                    { new Guid("452a752f-49f6-49d9-b201-c6c04a64953e"), new Guid("d6a4f7ef-79fe-457e-b97a-5a90a38e2803"), "Cape Town" },
                    { new Guid("48deb371-8ac1-4db3-9191-91e12e763d3f"), new Guid("e775ca30-1f8e-4393-b853-1524e704a1b9"), "Amsterdam" },
                    { new Guid("5ef486fa-3a8b-4fd5-8ffc-4c07d159508b"), new Guid("056f06bd-029b-4f8e-90e5-2528f86c1e22"), "Auckland" },
                    { new Guid("6cf601d4-c71e-42cf-8a51-599cb0a1c8c9"), new Guid("7fbdf75f-4197-4b23-a092-45cde1781af5"), "Brussels" },
                    { new Guid("6fa95edb-fb13-45a0-88a3-85c7bea7bb82"), new Guid("a9e850d7-4fd5-4eff-bf23-7c1b549686c9"), "Rome" },
                    { new Guid("77a37166-abc9-48af-af4a-90ba060d2ced"), new Guid("c50c25ba-a5bb-46bb-85ab-e13dda5da9d4"), "Mexico City" },
                    { new Guid("77a7ab6b-499e-4c8b-845a-17d6561e0e09"), new Guid("31cadbad-04af-45ce-b819-c66f18b5dce2"), "Sydney" },
                    { new Guid("85a2d9a0-6140-412f-9ca5-ff3e84065641"), new Guid("f14f3d20-8a2a-4c7f-af5e-364c0563091e"), "Rio de Janeiro" },
                    { new Guid("9269cf2d-3dfd-4b00-8ba3-cde84aad68e5"), new Guid("a5593b3d-8a4a-4ae3-bb06-5bbbeb13270b"), "Warsaw" },
                    { new Guid("94ad428a-336b-4737-818d-f13fa8b0f1ad"), new Guid("8557ea04-40b1-49da-b728-fa5e078729da"), "Hanoi" },
                    { new Guid("965cac56-1f5c-49d6-a22a-a0946659d06f"), new Guid("d50f17c7-1f1e-4b3f-9859-4ccae11ffd3c"), "Barcelona" },
                    { new Guid("982541bf-8f1b-4c79-9549-72d6112da116"), new Guid("7c184f96-4f48-4ef6-ba41-d215735bb410"), "Vienna" },
                    { new Guid("9857a938-b41f-4db5-b812-ceec0da4c26f"), new Guid("dfe4fff3-e9ab-4008-97bd-bc2006e8a8de"), "Lisbon" },
                    { new Guid("a9ab51c3-2412-44c2-9d45-4186bf56fc9a"), new Guid("8fa1ad7f-237b-45cf-b127-e674521813c0"), "Los Angeles" },
                    { new Guid("aa9e36c5-4fe5-42c1-97be-032df2156e8f"), new Guid("3e559040-5049-4db0-bb68-a629849864bb"), "Dublin" },
                    { new Guid("ab011edc-82e1-43d7-adb3-6f1236381753"), new Guid("ff0af716-735c-444c-a313-3e9d9ecf8189"), "Copenhagen" },
                    { new Guid("af4c6761-375f-4b5b-a2e0-bfcfdeab15b4"), new Guid("1d47a669-2e6f-410a-8883-812b8b658b8e"), "Tokyo" },
                    { new Guid("af63ead2-fd2a-4d2e-8339-69a7fdbdc0cf"), new Guid("77a9349b-c6cf-4111-99b7-3a23e91735a6"), "Cairo" },
                    { new Guid("b25f78ac-f544-4133-b8d5-9e8a3622776d"), new Guid("863fbc7d-7a96-4ef2-9921-18cf0c9f06ca"), "Berlin" },
                    { new Guid("b48a3075-ee49-4990-b2a3-d43d46d2e5a4"), new Guid("9fb89163-a652-4a7f-957f-ff2dd1ed33f1"), "Prague" },
                    { new Guid("c3d8232d-7069-4b44-b043-585f88c8f9a3"), new Guid("f6848c99-428f-4ebe-a051-95b856117395"), "Beijing" },
                    { new Guid("c45c76f0-e269-49ad-bf45-477260771b1b"), new Guid("cfab1176-d51c-4c95-8e60-9e2dceb6b9aa"), "Oslo" },
                    { new Guid("c5c678bf-f501-4198-9eda-66ce83062756"), new Guid("15d0e6cb-b865-47e9-87c2-2953158812fa"), "Helsinki" },
                    { new Guid("d0d84fe1-7e52-4e2a-8faa-35754963d6cb"), new Guid("1ee7b386-0ea0-4ce9-8c7e-bf2d5d83ea22"), "Mumbai" },
                    { new Guid("d1ca288a-5c18-43e1-bcd7-9567cd0a009b"), new Guid("10b916c0-47bb-4569-ac25-9a5d701da007"), "Paris" },
                    { new Guid("dcdf33c1-e390-45e3-af81-83a67e3d4e16"), new Guid("f4478d08-809e-415e-b0a6-4dbc8fec270f"), "London" },
                    { new Guid("e5009dcc-a740-4728-a397-c767d1c76f80"), new Guid("8fa1ad7f-237b-45cf-b127-e674521813c0"), "New York" },
                    { new Guid("e9be79df-865c-4bde-812a-dd4b0be7ab74"), new Guid("e586d2a1-eff6-4911-a627-251467328dff"), "Singapore" },
                    { new Guid("ecdc84af-92ac-4c3c-9023-c07ab0ee5e99"), new Guid("8fa1ad7f-237b-45cf-b127-e674521813c0"), "Chicago" },
                    { new Guid("efdf0f56-5f60-4139-9bac-713655c13403"), new Guid("acafaa13-4d70-4fed-89ef-116dcf570ea6"), "Nairobi" },
                    { new Guid("f5190376-9dda-4748-a2a3-c179d05d03af"), new Guid("87774cd0-84ab-40c2-9ac6-e462d94dc906"), "Seoul" },
                    { new Guid("fa9e1883-ea71-44f4-8c65-c82ebb136fcf"), new Guid("fe003fd7-510b-4967-b7ea-bcf53048c54e"), "Athens" },
                    { new Guid("ffb59e6f-38ef-48bc-bdfb-25dcb6297ea2"), new Guid("3a1867a0-ba63-4e85-b133-3d1901944071"), "Bangkok" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalConditionsSensors_UserId",
                table: "EnvironmentalConditionsSensors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationTokens");

            migrationBuilder.DropTable(
                name: "EnvironmentalConditionsSensors");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
