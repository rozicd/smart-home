using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
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
                    { new Guid("06dd92c2-c44d-4814-ab63-ce960ed8290f"), "Germany" },
                    { new Guid("0cfd1841-b5d4-445a-8cb0-ccdb87d6fbdd"), "UK" },
                    { new Guid("1478584d-069b-47de-92fd-6ef208cade1f"), "USA" },
                    { new Guid("1548304c-a478-493a-84f4-f44585959e50"), "South Africa" },
                    { new Guid("197c0d6a-b9c9-4f45-87c1-b82805de3bb2"), "New Zealand" },
                    { new Guid("2b21ddfc-f5e1-4727-b925-fbf8e151a18f"), "Austria" },
                    { new Guid("32997d44-8920-458f-a605-98012b218834"), "Portugal" },
                    { new Guid("37097464-d661-4f1b-8ac2-4da8f9868e4a"), "Russia" },
                    { new Guid("3cc80109-9496-4382-a1c0-d93f9e601bf6"), "Belgium" },
                    { new Guid("43b5bc96-7ea1-463e-b2db-27ce64254211"), "France" },
                    { new Guid("4ad9c6ba-e389-4fed-baca-c56641b8013d"), "Nigeria" },
                    { new Guid("532f32c0-f543-42a6-8f8e-6cbb4f42b081"), "Thailand" },
                    { new Guid("539b5c83-9940-400d-a009-18cd514a4978"), "Spain" },
                    { new Guid("5ba10523-3f8d-4219-8fbf-e7f93f931ae0"), "Czech Republic" },
                    { new Guid("6716c423-51cd-4fb7-bfbd-849673ca9593"), "India" },
                    { new Guid("6a5e6e43-da91-4005-99cc-c90dcba2b3f8"), "Egypt" },
                    { new Guid("7a6d4c15-7755-4dd8-8f3e-edb02d21c6d4"), "Denmark" },
                    { new Guid("7b2bedd5-e276-467c-85cd-3678d83a3681"), "Finland" },
                    { new Guid("8699358d-9be8-47e0-bb42-54709d29ccdb"), "Argentina" },
                    { new Guid("8bf343c2-09df-46df-940d-7883d01fe6bc"), "Vietnam" },
                    { new Guid("8f423c05-729a-4ef7-adf9-b0fe65ce4612"), "UAE" },
                    { new Guid("94caf35f-0eb8-4589-af3e-ad35a0b26df9"), "Switzerland" },
                    { new Guid("995e8ece-c156-4166-b2d0-dfc8285a2832"), "Mexico" },
                    { new Guid("9b042fdd-a952-4075-8327-c75c9b8c5411"), "Australia" },
                    { new Guid("9cb31c3f-9042-47f0-90d0-f4aa56a41405"), "Netherlands" },
                    { new Guid("ac212ca6-aa37-4909-b4b8-b92b89d78bb7"), "Norway" },
                    { new Guid("b40a59d7-4ab5-4c99-ae05-3e37efc66579"), "China" },
                    { new Guid("ba65f17e-e05f-4263-9cf1-d779ad33fef0"), "Brazil" },
                    { new Guid("c1acf1ae-166b-4f71-9b59-9477812433b0"), "Turkey" },
                    { new Guid("cc814ecb-1c19-46ee-a036-2eca2d8114b3"), "Japan" },
                    { new Guid("cf91ef8d-9f6a-4d41-9a25-33bc798b379a"), "Singapore" },
                    { new Guid("d0febddd-378b-4876-bdf9-f719be9f4c67"), "South Korea" },
                    { new Guid("d5ba2bee-be50-4d29-9d6b-085b2497e92b"), "Greece" },
                    { new Guid("e1c14968-85d9-43d0-bc82-6ab36686a9d2"), "Ireland" },
                    { new Guid("e98ad58c-cf1c-47fb-a8f0-f8e498bc2ab6"), "Italy" },
                    { new Guid("ea269c6a-b06c-4f02-b109-db69ecc0fc23"), "Poland" },
                    { new Guid("eaf5efeb-9a03-403b-b6bf-0ee79e12d0f9"), "Kenya" },
                    { new Guid("ec14a3fc-eb5f-4647-8e10-dd32a7f3574a"), "Sweden" },
                    { new Guid("ee64e289-25f6-42b5-bc49-567b5a131683"), "Canada" },
                    { new Guid("ff9d59af-942e-4003-9572-c4a799ac16f5"), "Hungary" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0af181c9-d8e2-427e-9e87-44d9a2682c17"), new Guid("7a6d4c15-7755-4dd8-8f3e-edb02d21c6d4"), "Copenhagen" },
                    { new Guid("0ca4b9e9-90e9-4758-94a5-b028a3bc7ed0"), new Guid("b40a59d7-4ab5-4c99-ae05-3e37efc66579"), "Hong Kong" },
                    { new Guid("1508de43-39d9-4441-b9bd-624f71ebecda"), new Guid("2b21ddfc-f5e1-4727-b925-fbf8e151a18f"), "Vienna" },
                    { new Guid("1e082086-8cbd-4d41-97e0-ef39b1348bc7"), new Guid("06dd92c2-c44d-4814-ab63-ce960ed8290f"), "Berlin" },
                    { new Guid("20ddceb4-7067-4856-85d9-0875f1dfc4ea"), new Guid("1478584d-069b-47de-92fd-6ef208cade1f"), "New York" },
                    { new Guid("27be2e82-3241-497b-90d7-5d3e6203ea9b"), new Guid("8699358d-9be8-47e0-bb42-54709d29ccdb"), "Buenos Aires" },
                    { new Guid("2ea1b97f-8ea0-408c-bacb-3321ca1e3387"), new Guid("197c0d6a-b9c9-4f45-87c1-b82805de3bb2"), "Auckland" },
                    { new Guid("303fa09f-a6c5-45de-bdf1-1ee561347c32"), new Guid("8bf343c2-09df-46df-940d-7883d01fe6bc"), "Hanoi" },
                    { new Guid("359e1961-1533-424c-8d74-e767f8ce6324"), new Guid("cc814ecb-1c19-46ee-a036-2eca2d8114b3"), "Tokyo" },
                    { new Guid("35ec4e8f-d9b3-40f1-bc8a-27cf789acf41"), new Guid("32997d44-8920-458f-a605-98012b218834"), "Lisbon" },
                    { new Guid("37d097d8-4ad0-4bad-8bc4-f85f6dbe7ca9"), new Guid("e1c14968-85d9-43d0-bc82-6ab36686a9d2"), "Dublin" },
                    { new Guid("41981db6-75dd-40be-97c4-bc567a885f5a"), new Guid("4ad9c6ba-e389-4fed-baca-c56641b8013d"), "Lagos" },
                    { new Guid("4b993f25-baa6-4cca-b45c-ecc32bee7da6"), new Guid("ba65f17e-e05f-4263-9cf1-d779ad33fef0"), "Rio de Janeiro" },
                    { new Guid("4facaf26-18d2-4dda-961e-cc4053ccfb1a"), new Guid("94caf35f-0eb8-4589-af3e-ad35a0b26df9"), "Zurich" },
                    { new Guid("5ac51440-e7fa-42a8-8138-c82ef34221b0"), new Guid("539b5c83-9940-400d-a009-18cd514a4978"), "Barcelona" },
                    { new Guid("5bf81f79-3c65-4dbf-9066-05c191ac5ee9"), new Guid("d0febddd-378b-4876-bdf9-f719be9f4c67"), "Seoul" },
                    { new Guid("5d4f0bad-7440-439e-b894-97bcb4c3dd25"), new Guid("c1acf1ae-166b-4f71-9b59-9477812433b0"), "Istanbul" },
                    { new Guid("6151a5fa-f20c-4345-bc1a-88af8641c52b"), new Guid("7b2bedd5-e276-467c-85cd-3678d83a3681"), "Helsinki" },
                    { new Guid("6536976a-39b6-44f9-af31-be3e22c477af"), new Guid("8f423c05-729a-4ef7-adf9-b0fe65ce4612"), "Dubai" },
                    { new Guid("665722e8-eb10-4b78-9d63-b4b54f17fe1a"), new Guid("ac212ca6-aa37-4909-b4b8-b92b89d78bb7"), "Oslo" },
                    { new Guid("7edfe7e0-4892-4c37-96d5-ea6af6fc464b"), new Guid("43b5bc96-7ea1-463e-b2db-27ce64254211"), "Paris" },
                    { new Guid("820e9017-4398-462b-b67f-61f267726a2b"), new Guid("b40a59d7-4ab5-4c99-ae05-3e37efc66579"), "Beijing" },
                    { new Guid("828ed3ef-dd91-4b86-bc3e-85e8b413a199"), new Guid("ea269c6a-b06c-4f02-b109-db69ecc0fc23"), "Warsaw" },
                    { new Guid("84aa591e-7039-49de-8863-424fe651ea7a"), new Guid("cf91ef8d-9f6a-4d41-9a25-33bc798b379a"), "Singapore" },
                    { new Guid("89714f2f-5a09-4763-80b6-0586a0b502da"), new Guid("37097464-d661-4f1b-8ac2-4da8f9868e4a"), "Moscow" },
                    { new Guid("8bb45d03-a74f-477a-911c-5abc3d8c48e6"), new Guid("ff9d59af-942e-4003-9572-c4a799ac16f5"), "Budapest" },
                    { new Guid("93386d55-6200-4330-875c-06a7402566a8"), new Guid("532f32c0-f543-42a6-8f8e-6cbb4f42b081"), "Bangkok" },
                    { new Guid("992060c4-af0d-48ee-9561-feab1652e83b"), new Guid("6a5e6e43-da91-4005-99cc-c90dcba2b3f8"), "Cairo" },
                    { new Guid("9ba96868-e7b0-46c3-8708-490162036896"), new Guid("1548304c-a478-493a-84f4-f44585959e50"), "Cape Town" },
                    { new Guid("a646b120-0742-4e1d-8481-0911b3589a83"), new Guid("1478584d-069b-47de-92fd-6ef208cade1f"), "Chicago" },
                    { new Guid("b17b277b-d92b-4dad-87a0-84abfab5219a"), new Guid("9b042fdd-a952-4075-8327-c75c9b8c5411"), "Sydney" },
                    { new Guid("bc416699-ff2e-4821-8351-84d89f872f60"), new Guid("9cb31c3f-9042-47f0-90d0-f4aa56a41405"), "Amsterdam" },
                    { new Guid("bd75d3f3-c0db-4ba2-87c1-bb313ab3f1b1"), new Guid("ee64e289-25f6-42b5-bc49-567b5a131683"), "Toronto" },
                    { new Guid("bd8cb84e-2959-4876-8b27-40c866f23d25"), new Guid("eaf5efeb-9a03-403b-b6bf-0ee79e12d0f9"), "Nairobi" },
                    { new Guid("c60d5a9b-a00d-4c8e-ae8c-48735a1360d6"), new Guid("d5ba2bee-be50-4d29-9d6b-085b2497e92b"), "Athens" },
                    { new Guid("c7773161-ebf8-4828-bef6-76c0d536efbb"), new Guid("e98ad58c-cf1c-47fb-a8f0-f8e498bc2ab6"), "Rome" },
                    { new Guid("cfeee876-a8ed-4658-82ea-dd538a362fc4"), new Guid("995e8ece-c156-4166-b2d0-dfc8285a2832"), "Mexico City" },
                    { new Guid("d076508b-f7c7-4770-af0c-0dc694602447"), new Guid("6716c423-51cd-4fb7-bfbd-849673ca9593"), "Mumbai" },
                    { new Guid("d41d3184-98aa-4c3e-8215-0e6944e6735e"), new Guid("ec14a3fc-eb5f-4647-8e10-dd32a7f3574a"), "Stockholm" },
                    { new Guid("d49cc4b7-1747-4f15-886f-f1e709ab55a2"), new Guid("0cfd1841-b5d4-445a-8cb0-ccdb87d6fbdd"), "London" },
                    { new Guid("df83a8c4-4c65-4f04-bfd7-98b26082cc97"), new Guid("1478584d-069b-47de-92fd-6ef208cade1f"), "Los Angeles" },
                    { new Guid("f63f771d-c5a6-4977-aea0-81fd56d88a90"), new Guid("3cc80109-9496-4382-a1c0-d93f9e601bf6"), "Brussels" },
                    { new Guid("ff541c87-43db-47fb-bbb0-3a9296cf1a5f"), new Guid("5ba10523-3f8d-4219-8fbf-e7f93f931ae0"), "Prague" }
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
