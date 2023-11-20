using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class testssa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprinklers_SprinkleModeEntity_ModeId",
                table: "Sprinklers");

            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachineModeEntity_WashingMachines_WashingMachineEnti~",
                table: "WashingMachineModeEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachines_WashingMachineModeEntity_CurrentModeId",
                table: "WashingMachines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WashingMachineModeEntity",
                table: "WashingMachineModeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SprinkleModeEntity",
                table: "SprinkleModeEntity");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0ddccc71-4278-48ba-a3cf-85278e71802f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("13a7df59-b65f-467b-9b34-8bc08d8474f2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("252cbef8-536b-47c8-9617-73d40d473446"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("319388a2-8a9a-4cce-896e-581ee42ad6d6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("32c8a152-b4e0-46d9-ac9c-60d5f5a21bdd"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("34d43665-d6b2-44b6-843b-995f401fda47"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("39b64ae7-c4f6-4493-8414-7926717488fe"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("477fc751-77b0-44f8-b872-0a420a3d6290"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4d391827-c78a-4117-8038-ef786502f7a3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4d949bf9-69a7-4fc4-87eb-0f5aaebea027"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4e203e4c-3e91-4be3-ae15-8f069f7df54e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4e74b279-134e-429e-9f12-07618b04cc0b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("567004d3-c3ce-4303-8b69-288324e53e4f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5812a5f2-dd84-4499-8c1e-9926724a4e9b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5d6023c8-b399-453d-bf87-5207ed42e22c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("70a3cd86-735e-46b5-b7c8-04a28679c306"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7ad68124-8c52-4875-8524-0c685b213e95"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7b16c0c7-607d-4f52-81ab-8a8f02cc64ce"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7e7b9f4c-a61c-4e46-8c0e-fff51e2221a3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("87579910-4811-4e7e-8528-547120593464"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("886b7ee4-56d7-4dc3-a5ff-6af07ab9b17a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("99970f6d-eff6-4998-bf38-c457c236c704"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9db3a3c3-7cb6-40ab-a61b-653d3c1893d3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a5026003-17d9-4731-846b-09ff6cb39eb1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a72d356e-1480-4411-b4c2-ba5bd48668e5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ab7913b3-51b3-4428-a02e-a1e5b88d0194"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("acda80c2-867b-4fba-aef1-f6e677f7eb30"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b0121ff8-0f52-4769-afc0-618b2e417165"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b302da91-4e2a-430e-8ae6-d13d04d08256"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c01403d7-50e7-4ef4-a51d-f60b27142176"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c8a6ae11-fddc-4da7-aafd-26583a509d0f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c8b0a223-1c55-47df-9b4a-28f183098f08"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cb47050e-e56e-4f1d-ab15-14330d2734e5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d044ea28-fd62-4a62-b1dd-38a65a78a4fd"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d309f76c-df6a-4211-8056-3a5ffe8a1b01"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dad305e8-6533-4f91-b03e-d538d174c3d7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dc503588-4863-4691-bfd5-0a1e53350969"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e2a84088-4f7b-4a46-ba97-f9f4063e3e61"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ec4a5fa4-9b6f-488f-b950-797334c17702"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ed850d2e-98c4-4741-8b2b-4f1b5eb2fd0e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ef7c2cbc-01cc-4f4d-a1ed-1085e60e4ea9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f5819ea5-a149-47be-9225-22327bb647ea"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f725c43c-cf8e-4247-bb82-d413b3f580a3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("045f42d5-c3d9-43ca-92a5-127e9a22047a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0803dc59-89ce-4cfc-b0b2-5b6c54ce64a7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b43694d-a33a-4ccb-8ec6-ed6880925fb1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("106d71a9-7b79-4164-a468-fdeba9cea694"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("17e9fd33-e93d-4023-a78c-42a45746a5be"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ea15fa3-b1bd-48ee-9dca-d21a7d6949c6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2208ac14-88cc-4cc0-a57c-d6fb3875a321"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("26aeb71d-cda4-4ad8-a261-fd8c40e402e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ec86250-c4f1-466a-8531-0f73685e9983"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("409cf3ad-5332-406a-b4c9-a6b7ea870f84"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("478a9b87-98a7-479d-84af-2e34b7e08734"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("52b85311-a54b-4a54-a483-244b54f71ffb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59a3b6f2-0a52-4ece-91ad-d1e82c8e76af"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("59d05aa7-03ed-4e59-9e43-1520923766c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c3db35f-1aeb-45c4-9b5c-1fbb3b3090fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60307129-48f4-43df-a576-ec74c18043b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63de4049-fab7-402a-abc8-57ab548fdc1a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6cf733d1-cd66-4d47-8771-0af9c69b1353"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7ceffbfe-2856-499b-8934-6ed7a9795e70"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("80568834-32d8-4b15-a780-e75d651a9f5b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("91841369-6f81-40c7-b51d-69bd7f48fb95"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9371d39a-7348-4b38-8ce6-ba6c8a7ee117"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c9b3260-07e6-4d84-9644-bd0e8ad77559"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9d7e46f0-d2bf-4d7b-b8e6-a93598749f63"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f4d4a88-e2b8-47cf-ae47-9ea74a6a5945"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a1ddb73e-8de9-433e-b03e-6615deccc12d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b0f58408-ae11-4534-b11e-3200c0435cf0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0b5867d-dd77-4be9-b67c-94a1d3407c09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c3170370-a4d7-4e13-8213-6158ff33f1e0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c5086443-129b-47dd-b4ed-aa65d0cc64f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d028b656-5e46-482f-b033-38fa0599d4fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d22fa459-6392-4087-8032-c91629911001"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e1447b0f-0fe5-4958-a127-3d890325d00b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e2f0262c-0ffa-4567-a056-149223bb5e2b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4cc77ea-e360-457e-9b3a-e82d5560974f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0c3c785-2593-436e-809f-a8ee3e9456eb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f1eca1e3-ef5d-4ad2-8b24-61c944b1aa1a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f306d120-66ec-4d0f-9151-e6095095e75f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("facadbc8-ff7d-4621-a2ae-66bf6a6021ee"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ffb6e493-e33b-4813-a905-4fc8d7b03e50"));

            migrationBuilder.RenameTable(
                name: "WashingMachineModeEntity",
                newName: "WashingMachineModes");

            migrationBuilder.RenameTable(
                name: "SprinkleModeEntity",
                newName: "SprinkleModes");

            migrationBuilder.RenameIndex(
                name: "IX_WashingMachineModeEntity_WashingMachineEntityId",
                table: "WashingMachineModes",
                newName: "IX_WashingMachineModes_WashingMachineEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WashingMachineModes",
                table: "WashingMachineModes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SprinkleModes",
                table: "SprinkleModes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SolarPanels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    Efficiency = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarPanels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("064a3237-2b05-40b5-b696-9b497dfe4acc"), "China" },
                    { new Guid("07e012e7-2ce5-4e67-9918-eb2c260b0574"), "Portugal" },
                    { new Guid("0b54ab3a-4f5d-419e-8efa-b4ef6361eccd"), "Egypt" },
                    { new Guid("0b86cfb4-d2e5-45a5-81c9-63d417bb92a2"), "Czech Republic" },
                    { new Guid("10003451-8e11-49e3-b143-bb8ee599d295"), "South Africa" },
                    { new Guid("17b629b5-22ab-4bb5-9b8f-844629262a59"), "Finland" },
                    { new Guid("450ddb2e-566a-412c-b988-0fc5f0eb01aa"), "Germany" },
                    { new Guid("46de43bc-09ad-4a9a-b00e-20cb6d817f44"), "Greece" },
                    { new Guid("4abbfd58-05b7-4af0-8438-46ca410c6211"), "Russia" },
                    { new Guid("4b6f21f0-ed9d-4901-9d6f-a4d580c7ad1f"), "New Zealand" },
                    { new Guid("4ee5eb35-15d3-4a69-85fd-c2db6ecce2be"), "Japan" },
                    { new Guid("552827b6-ff0c-4d5b-b24f-00bb5e9cf9d4"), "Nigeria" },
                    { new Guid("55abab68-87d3-4cc6-b77a-22855d3d865f"), "Turkey" },
                    { new Guid("57d9895b-e086-4a94-896c-d040c4f682ee"), "Brazil" },
                    { new Guid("60a10db0-e176-4543-92da-6d19e07254f1"), "Denmark" },
                    { new Guid("63564ade-33f0-4faf-9963-32d15df2e8fd"), "Canada" },
                    { new Guid("63e19cb3-1d79-4f9d-be4a-9cb0ed6f60d6"), "Vietnam" },
                    { new Guid("6c298608-1e4a-4b5f-bc8e-3dd5d19c82f1"), "Australia" },
                    { new Guid("7791361d-c0bd-4dab-9d3f-962d278acdc7"), "USA" },
                    { new Guid("80698727-0601-4dfe-b700-6d5bcbef390d"), "Thailand" },
                    { new Guid("8be17a3c-3d25-418e-8857-653f0c19c5a6"), "UAE" },
                    { new Guid("95be32bd-4f09-4c00-877a-8b44d01fb375"), "Poland" },
                    { new Guid("a17812b0-099b-48fc-b290-2660219c0c07"), "Mexico" },
                    { new Guid("a42795f8-bcf4-476d-9a8d-eda11a8d9602"), "India" },
                    { new Guid("a4a42d67-f006-4b3e-ae67-51f26bfc5ace"), "Singapore" },
                    { new Guid("a6797f1a-a39b-4633-a217-c62fe290f678"), "South Korea" },
                    { new Guid("aa98b8a2-824f-4012-a4cb-65e9d90c68ed"), "Italy" },
                    { new Guid("acecc64e-677a-4e09-aabe-1e1bce826a39"), "Kenya" },
                    { new Guid("b760b265-a68a-4ba9-8bbd-63ab733919a2"), "Netherlands" },
                    { new Guid("bbb33b79-cf55-4498-a210-12383d69bd8c"), "Hungary" },
                    { new Guid("bd0e7831-5a6c-4216-84ca-c84d92fe03cf"), "Norway" },
                    { new Guid("be255399-b7b3-4345-bccd-1faf0cefabeb"), "Sweden" },
                    { new Guid("c403351c-e19e-4b91-bec3-e19ee9a89a19"), "Austria" },
                    { new Guid("c545f39c-5bfa-448b-8c9d-c4d89fd949d2"), "Argentina" },
                    { new Guid("cb92e781-6287-4830-8b84-157ef3bb4f57"), "Ireland" },
                    { new Guid("cf3a9b4d-19b0-483b-a83b-c800fa0d5358"), "France" },
                    { new Guid("df525916-d626-4e7a-a468-29ab8ba824c1"), "Belgium" },
                    { new Guid("e1ff9a15-50d0-4a72-8acb-29278253c28a"), "Switzerland" },
                    { new Guid("ec3cc6b7-deee-4b02-8f78-3381b95d29db"), "Spain" },
                    { new Guid("fd2a665b-c430-4ada-b1d1-84557a5834e8"), "UK" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0f705abe-9893-438a-8579-6295582383a1"), new Guid("07e012e7-2ce5-4e67-9918-eb2c260b0574"), "Lisbon" },
                    { new Guid("11d9d278-978e-4552-b7eb-afbb6c7ced30"), new Guid("a6797f1a-a39b-4633-a217-c62fe290f678"), "Seoul" },
                    { new Guid("11ffdeec-ef09-4b99-a2f3-99e0769b8904"), new Guid("b760b265-a68a-4ba9-8bbd-63ab733919a2"), "Amsterdam" },
                    { new Guid("12bd4cad-5597-47db-8669-56e2721e0598"), new Guid("fd2a665b-c430-4ada-b1d1-84557a5834e8"), "London" },
                    { new Guid("14edcf05-2273-4067-b387-1f9d3dd1a287"), new Guid("4ee5eb35-15d3-4a69-85fd-c2db6ecce2be"), "Tokyo" },
                    { new Guid("1a46e2a3-a19b-439b-9b8e-8fb86283db55"), new Guid("bd0e7831-5a6c-4216-84ca-c84d92fe03cf"), "Oslo" },
                    { new Guid("1c1f5882-aa04-4a06-9af3-2f6af2b326d8"), new Guid("a42795f8-bcf4-476d-9a8d-eda11a8d9602"), "Mumbai" },
                    { new Guid("26ba45fd-d319-4a2e-86c9-5c15d11c5fc4"), new Guid("df525916-d626-4e7a-a468-29ab8ba824c1"), "Brussels" },
                    { new Guid("29cf46d4-0b37-402b-91fb-b4d92dec2dbc"), new Guid("ec3cc6b7-deee-4b02-8f78-3381b95d29db"), "Barcelona" },
                    { new Guid("2f94b2b5-93fe-44bc-93c7-e2b1c85a6910"), new Guid("4b6f21f0-ed9d-4901-9d6f-a4d580c7ad1f"), "Auckland" },
                    { new Guid("3276c3f0-1e32-4236-8505-1e87c6646aba"), new Guid("e1ff9a15-50d0-4a72-8acb-29278253c28a"), "Zurich" },
                    { new Guid("34b513f8-737f-4308-89fd-baf6f664d1a5"), new Guid("a4a42d67-f006-4b3e-ae67-51f26bfc5ace"), "Singapore" },
                    { new Guid("3604c6cc-1e51-44d7-8630-33e231706bdd"), new Guid("c403351c-e19e-4b91-bec3-e19ee9a89a19"), "Vienna" },
                    { new Guid("38f8ea2f-45bc-45df-82f9-9cfc151f4e28"), new Guid("a17812b0-099b-48fc-b290-2660219c0c07"), "Mexico City" },
                    { new Guid("3ed6bdb0-5b99-407c-a4be-e3ff08ad3224"), new Guid("aa98b8a2-824f-4012-a4cb-65e9d90c68ed"), "Rome" },
                    { new Guid("424a1865-aef1-4dea-83da-b42ee87154af"), new Guid("80698727-0601-4dfe-b700-6d5bcbef390d"), "Bangkok" },
                    { new Guid("426ec1fd-0bb1-46cf-a44d-a07f5bee8d59"), new Guid("55abab68-87d3-4cc6-b77a-22855d3d865f"), "Istanbul" },
                    { new Guid("5048dbec-a979-4d4d-8a06-3a0a955111a2"), new Guid("0b86cfb4-d2e5-45a5-81c9-63d417bb92a2"), "Prague" },
                    { new Guid("534f124b-dc77-4101-b273-13d07bd7e223"), new Guid("7791361d-c0bd-4dab-9d3f-962d278acdc7"), "New York" },
                    { new Guid("5f71a7d9-1b5b-4eb1-a07e-3bd7c9f8dcd4"), new Guid("4abbfd58-05b7-4af0-8438-46ca410c6211"), "Moscow" },
                    { new Guid("709addc1-3ea7-4a71-b2bd-0d0f70fdd5a8"), new Guid("60a10db0-e176-4543-92da-6d19e07254f1"), "Copenhagen" },
                    { new Guid("71831b3a-6fd5-465f-b985-2eaf88fca6de"), new Guid("cb92e781-6287-4830-8b84-157ef3bb4f57"), "Dublin" },
                    { new Guid("7cce40da-beac-4bfd-9cb2-1a4c35eb9126"), new Guid("be255399-b7b3-4345-bccd-1faf0cefabeb"), "Stockholm" },
                    { new Guid("8ec789cb-1962-41c7-912a-d5808723d1b9"), new Guid("450ddb2e-566a-412c-b988-0fc5f0eb01aa"), "Berlin" },
                    { new Guid("8ee3096a-ee2b-4852-ac73-25a16ba8b388"), new Guid("63564ade-33f0-4faf-9963-32d15df2e8fd"), "Toronto" },
                    { new Guid("8ef4cc37-4c92-4f72-a787-1c1eb862e744"), new Guid("10003451-8e11-49e3-b143-bb8ee599d295"), "Cape Town" },
                    { new Guid("97387e92-dd29-4a90-a09c-664658b490af"), new Guid("552827b6-ff0c-4d5b-b24f-00bb5e9cf9d4"), "Lagos" },
                    { new Guid("991d3ebf-bf2b-4f17-99d4-5b8b48012d6a"), new Guid("46de43bc-09ad-4a9a-b00e-20cb6d817f44"), "Athens" },
                    { new Guid("a0e2193d-1362-44aa-814b-989f76278fb7"), new Guid("57d9895b-e086-4a94-896c-d040c4f682ee"), "Rio de Janeiro" },
                    { new Guid("a2def989-a428-4599-8279-7133d9e5af8d"), new Guid("c545f39c-5bfa-448b-8c9d-c4d89fd949d2"), "Buenos Aires" },
                    { new Guid("ae327a0b-3d04-410b-82cf-06ba2f065a79"), new Guid("7791361d-c0bd-4dab-9d3f-962d278acdc7"), "Los Angeles" },
                    { new Guid("bd9283f1-4b98-4e31-8c0a-c0b24431cdb9"), new Guid("cf3a9b4d-19b0-483b-a83b-c800fa0d5358"), "Paris" },
                    { new Guid("c2bdaf6b-a068-46c7-99ad-d69e4b972698"), new Guid("17b629b5-22ab-4bb5-9b8f-844629262a59"), "Helsinki" },
                    { new Guid("c5c47ef4-a469-42d5-97ef-83d42aa4c5ba"), new Guid("95be32bd-4f09-4c00-877a-8b44d01fb375"), "Warsaw" },
                    { new Guid("caaff8b5-a706-4f5a-a830-d483b20d6d74"), new Guid("6c298608-1e4a-4b5f-bc8e-3dd5d19c82f1"), "Sydney" },
                    { new Guid("ce6905f1-364f-4db9-9fff-4670942d66af"), new Guid("63e19cb3-1d79-4f9d-be4a-9cb0ed6f60d6"), "Hanoi" },
                    { new Guid("cf42bea0-f7fb-42f0-a39d-21dc50ebcc56"), new Guid("0b54ab3a-4f5d-419e-8efa-b4ef6361eccd"), "Cairo" },
                    { new Guid("cffb2f6f-45b3-42ec-a8a8-5d245a1c52c6"), new Guid("8be17a3c-3d25-418e-8857-653f0c19c5a6"), "Dubai" },
                    { new Guid("e2567479-6505-46a1-85d8-e2cdf9bdaf8e"), new Guid("bbb33b79-cf55-4498-a210-12383d69bd8c"), "Budapest" },
                    { new Guid("e9548adb-f4be-47ff-b5e1-6a555a6127d7"), new Guid("acecc64e-677a-4e09-aabe-1e1bce826a39"), "Nairobi" },
                    { new Guid("f2d90bbf-c367-431a-a80a-cbb6a363b136"), new Guid("064a3237-2b05-40b5-b696-9b497dfe4acc"), "Hong Kong" },
                    { new Guid("fb1b4382-bfd4-4637-a09f-9e869525e03c"), new Guid("7791361d-c0bd-4dab-9d3f-962d278acdc7"), "Chicago" },
                    { new Guid("fc2d2b95-b957-43f5-99a6-e9c116eaef08"), new Guid("064a3237-2b05-40b5-b696-9b497dfe4acc"), "Beijing" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sprinklers_SprinkleModes_ModeId",
                table: "Sprinklers",
                column: "ModeId",
                principalTable: "SprinkleModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachineModes_WashingMachines_WashingMachineEntityId",
                table: "WashingMachineModes",
                column: "WashingMachineEntityId",
                principalTable: "WashingMachines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachines_WashingMachineModes_CurrentModeId",
                table: "WashingMachines",
                column: "CurrentModeId",
                principalTable: "WashingMachineModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprinklers_SprinkleModes_ModeId",
                table: "Sprinklers");

            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachineModes_WashingMachines_WashingMachineEntityId",
                table: "WashingMachineModes");

            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachines_WashingMachineModes_CurrentModeId",
                table: "WashingMachines");

            migrationBuilder.DropTable(
                name: "SolarPanels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WashingMachineModes",
                table: "WashingMachineModes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SprinkleModes",
                table: "SprinkleModes");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0f705abe-9893-438a-8579-6295582383a1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("11d9d278-978e-4552-b7eb-afbb6c7ced30"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("11ffdeec-ef09-4b99-a2f3-99e0769b8904"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12bd4cad-5597-47db-8669-56e2721e0598"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("14edcf05-2273-4067-b387-1f9d3dd1a287"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1a46e2a3-a19b-439b-9b8e-8fb86283db55"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1c1f5882-aa04-4a06-9af3-2f6af2b326d8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("26ba45fd-d319-4a2e-86c9-5c15d11c5fc4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("29cf46d4-0b37-402b-91fb-b4d92dec2dbc"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2f94b2b5-93fe-44bc-93c7-e2b1c85a6910"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3276c3f0-1e32-4236-8505-1e87c6646aba"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("34b513f8-737f-4308-89fd-baf6f664d1a5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3604c6cc-1e51-44d7-8630-33e231706bdd"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38f8ea2f-45bc-45df-82f9-9cfc151f4e28"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3ed6bdb0-5b99-407c-a4be-e3ff08ad3224"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("424a1865-aef1-4dea-83da-b42ee87154af"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("426ec1fd-0bb1-46cf-a44d-a07f5bee8d59"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5048dbec-a979-4d4d-8a06-3a0a955111a2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("534f124b-dc77-4101-b273-13d07bd7e223"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5f71a7d9-1b5b-4eb1-a07e-3bd7c9f8dcd4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("709addc1-3ea7-4a71-b2bd-0d0f70fdd5a8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("71831b3a-6fd5-465f-b985-2eaf88fca6de"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7cce40da-beac-4bfd-9cb2-1a4c35eb9126"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8ec789cb-1962-41c7-912a-d5808723d1b9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8ee3096a-ee2b-4852-ac73-25a16ba8b388"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8ef4cc37-4c92-4f72-a787-1c1eb862e744"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("97387e92-dd29-4a90-a09c-664658b490af"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("991d3ebf-bf2b-4f17-99d4-5b8b48012d6a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0e2193d-1362-44aa-814b-989f76278fb7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a2def989-a428-4599-8279-7133d9e5af8d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ae327a0b-3d04-410b-82cf-06ba2f065a79"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bd9283f1-4b98-4e31-8c0a-c0b24431cdb9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c2bdaf6b-a068-46c7-99ad-d69e4b972698"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c5c47ef4-a469-42d5-97ef-83d42aa4c5ba"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("caaff8b5-a706-4f5a-a830-d483b20d6d74"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ce6905f1-364f-4db9-9fff-4670942d66af"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cf42bea0-f7fb-42f0-a39d-21dc50ebcc56"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cffb2f6f-45b3-42ec-a8a8-5d245a1c52c6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e2567479-6505-46a1-85d8-e2cdf9bdaf8e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e9548adb-f4be-47ff-b5e1-6a555a6127d7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f2d90bbf-c367-431a-a80a-cbb6a363b136"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fb1b4382-bfd4-4637-a09f-9e869525e03c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fc2d2b95-b957-43f5-99a6-e9c116eaef08"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("064a3237-2b05-40b5-b696-9b497dfe4acc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("07e012e7-2ce5-4e67-9918-eb2c260b0574"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b54ab3a-4f5d-419e-8efa-b4ef6361eccd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b86cfb4-d2e5-45a5-81c9-63d417bb92a2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10003451-8e11-49e3-b143-bb8ee599d295"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("17b629b5-22ab-4bb5-9b8f-844629262a59"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("450ddb2e-566a-412c-b988-0fc5f0eb01aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("46de43bc-09ad-4a9a-b00e-20cb6d817f44"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4abbfd58-05b7-4af0-8438-46ca410c6211"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4b6f21f0-ed9d-4901-9d6f-a4d580c7ad1f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4ee5eb35-15d3-4a69-85fd-c2db6ecce2be"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("552827b6-ff0c-4d5b-b24f-00bb5e9cf9d4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55abab68-87d3-4cc6-b77a-22855d3d865f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("57d9895b-e086-4a94-896c-d040c4f682ee"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60a10db0-e176-4543-92da-6d19e07254f1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63564ade-33f0-4faf-9963-32d15df2e8fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("63e19cb3-1d79-4f9d-be4a-9cb0ed6f60d6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c298608-1e4a-4b5f-bc8e-3dd5d19c82f1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7791361d-c0bd-4dab-9d3f-962d278acdc7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("80698727-0601-4dfe-b700-6d5bcbef390d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8be17a3c-3d25-418e-8857-653f0c19c5a6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("95be32bd-4f09-4c00-877a-8b44d01fb375"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a17812b0-099b-48fc-b290-2660219c0c07"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a42795f8-bcf4-476d-9a8d-eda11a8d9602"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a4a42d67-f006-4b3e-ae67-51f26bfc5ace"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a6797f1a-a39b-4633-a217-c62fe290f678"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aa98b8a2-824f-4012-a4cb-65e9d90c68ed"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acecc64e-677a-4e09-aabe-1e1bce826a39"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b760b265-a68a-4ba9-8bbd-63ab733919a2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bbb33b79-cf55-4498-a210-12383d69bd8c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bd0e7831-5a6c-4216-84ca-c84d92fe03cf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("be255399-b7b3-4345-bccd-1faf0cefabeb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c403351c-e19e-4b91-bec3-e19ee9a89a19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c545f39c-5bfa-448b-8c9d-c4d89fd949d2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb92e781-6287-4830-8b84-157ef3bb4f57"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cf3a9b4d-19b0-483b-a83b-c800fa0d5358"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("df525916-d626-4e7a-a468-29ab8ba824c1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e1ff9a15-50d0-4a72-8acb-29278253c28a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec3cc6b7-deee-4b02-8f78-3381b95d29db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fd2a665b-c430-4ada-b1d1-84557a5834e8"));

            migrationBuilder.RenameTable(
                name: "WashingMachineModes",
                newName: "WashingMachineModeEntity");

            migrationBuilder.RenameTable(
                name: "SprinkleModes",
                newName: "SprinkleModeEntity");

            migrationBuilder.RenameIndex(
                name: "IX_WashingMachineModes_WashingMachineEntityId",
                table: "WashingMachineModeEntity",
                newName: "IX_WashingMachineModeEntity_WashingMachineEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WashingMachineModeEntity",
                table: "WashingMachineModeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SprinkleModeEntity",
                table: "SprinkleModeEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("045f42d5-c3d9-43ca-92a5-127e9a22047a"), "China" },
                    { new Guid("0803dc59-89ce-4cfc-b0b2-5b6c54ce64a7"), "Norway" },
                    { new Guid("0b43694d-a33a-4ccb-8ec6-ed6880925fb1"), "Singapore" },
                    { new Guid("106d71a9-7b79-4164-a468-fdeba9cea694"), "Hungary" },
                    { new Guid("17e9fd33-e93d-4023-a78c-42a45746a5be"), "Argentina" },
                    { new Guid("1ea15fa3-b1bd-48ee-9dca-d21a7d6949c6"), "Finland" },
                    { new Guid("2208ac14-88cc-4cc0-a57c-d6fb3875a321"), "Switzerland" },
                    { new Guid("26aeb71d-cda4-4ad8-a261-fd8c40e402e2"), "Nigeria" },
                    { new Guid("3ec86250-c4f1-466a-8531-0f73685e9983"), "India" },
                    { new Guid("409cf3ad-5332-406a-b4c9-a6b7ea870f84"), "Spain" },
                    { new Guid("478a9b87-98a7-479d-84af-2e34b7e08734"), "Australia" },
                    { new Guid("52b85311-a54b-4a54-a483-244b54f71ffb"), "USA" },
                    { new Guid("59a3b6f2-0a52-4ece-91ad-d1e82c8e76af"), "Turkey" },
                    { new Guid("59d05aa7-03ed-4e59-9e43-1520923766c5"), "Mexico" },
                    { new Guid("5c3db35f-1aeb-45c4-9b5c-1fbb3b3090fd"), "Brazil" },
                    { new Guid("60307129-48f4-43df-a576-ec74c18043b9"), "Egypt" },
                    { new Guid("63de4049-fab7-402a-abc8-57ab548fdc1a"), "Netherlands" },
                    { new Guid("6cf733d1-cd66-4d47-8771-0af9c69b1353"), "Thailand" },
                    { new Guid("7ceffbfe-2856-499b-8934-6ed7a9795e70"), "South Africa" },
                    { new Guid("80568834-32d8-4b15-a780-e75d651a9f5b"), "Denmark" },
                    { new Guid("91841369-6f81-40c7-b51d-69bd7f48fb95"), "Russia" },
                    { new Guid("9371d39a-7348-4b38-8ce6-ba6c8a7ee117"), "Vietnam" },
                    { new Guid("9c9b3260-07e6-4d84-9644-bd0e8ad77559"), "UK" },
                    { new Guid("9d7e46f0-d2bf-4d7b-b8e6-a93598749f63"), "Sweden" },
                    { new Guid("9f4d4a88-e2b8-47cf-ae47-9ea74a6a5945"), "France" },
                    { new Guid("a1ddb73e-8de9-433e-b03e-6615deccc12d"), "New Zealand" },
                    { new Guid("b0f58408-ae11-4534-b11e-3200c0435cf0"), "Ireland" },
                    { new Guid("c0b5867d-dd77-4be9-b67c-94a1d3407c09"), "Germany" },
                    { new Guid("c3170370-a4d7-4e13-8213-6158ff33f1e0"), "Italy" },
                    { new Guid("c5086443-129b-47dd-b4ed-aa65d0cc64f5"), "UAE" },
                    { new Guid("d028b656-5e46-482f-b033-38fa0599d4fd"), "South Korea" },
                    { new Guid("d22fa459-6392-4087-8032-c91629911001"), "Canada" },
                    { new Guid("e1447b0f-0fe5-4958-a127-3d890325d00b"), "Greece" },
                    { new Guid("e2f0262c-0ffa-4567-a056-149223bb5e2b"), "Japan" },
                    { new Guid("e4cc77ea-e360-457e-9b3a-e82d5560974f"), "Kenya" },
                    { new Guid("f0c3c785-2593-436e-809f-a8ee3e9456eb"), "Austria" },
                    { new Guid("f1eca1e3-ef5d-4ad2-8b24-61c944b1aa1a"), "Czech Republic" },
                    { new Guid("f306d120-66ec-4d0f-9151-e6095095e75f"), "Poland" },
                    { new Guid("facadbc8-ff7d-4621-a2ae-66bf6a6021ee"), "Belgium" },
                    { new Guid("ffb6e493-e33b-4813-a905-4fc8d7b03e50"), "Portugal" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0ddccc71-4278-48ba-a3cf-85278e71802f"), new Guid("52b85311-a54b-4a54-a483-244b54f71ffb"), "Chicago" },
                    { new Guid("13a7df59-b65f-467b-9b34-8bc08d8474f2"), new Guid("d028b656-5e46-482f-b033-38fa0599d4fd"), "Seoul" },
                    { new Guid("252cbef8-536b-47c8-9617-73d40d473446"), new Guid("52b85311-a54b-4a54-a483-244b54f71ffb"), "New York" },
                    { new Guid("319388a2-8a9a-4cce-896e-581ee42ad6d6"), new Guid("6cf733d1-cd66-4d47-8771-0af9c69b1353"), "Bangkok" },
                    { new Guid("32c8a152-b4e0-46d9-ac9c-60d5f5a21bdd"), new Guid("26aeb71d-cda4-4ad8-a261-fd8c40e402e2"), "Lagos" },
                    { new Guid("34d43665-d6b2-44b6-843b-995f401fda47"), new Guid("60307129-48f4-43df-a576-ec74c18043b9"), "Cairo" },
                    { new Guid("39b64ae7-c4f6-4493-8414-7926717488fe"), new Guid("b0f58408-ae11-4534-b11e-3200c0435cf0"), "Dublin" },
                    { new Guid("477fc751-77b0-44f8-b872-0a420a3d6290"), new Guid("f306d120-66ec-4d0f-9151-e6095095e75f"), "Warsaw" },
                    { new Guid("4d391827-c78a-4117-8038-ef786502f7a3"), new Guid("f0c3c785-2593-436e-809f-a8ee3e9456eb"), "Vienna" },
                    { new Guid("4d949bf9-69a7-4fc4-87eb-0f5aaebea027"), new Guid("59d05aa7-03ed-4e59-9e43-1520923766c5"), "Mexico City" },
                    { new Guid("4e203e4c-3e91-4be3-ae15-8f069f7df54e"), new Guid("e2f0262c-0ffa-4567-a056-149223bb5e2b"), "Tokyo" },
                    { new Guid("4e74b279-134e-429e-9f12-07618b04cc0b"), new Guid("478a9b87-98a7-479d-84af-2e34b7e08734"), "Sydney" },
                    { new Guid("567004d3-c3ce-4303-8b69-288324e53e4f"), new Guid("91841369-6f81-40c7-b51d-69bd7f48fb95"), "Moscow" },
                    { new Guid("5812a5f2-dd84-4499-8c1e-9926724a4e9b"), new Guid("2208ac14-88cc-4cc0-a57c-d6fb3875a321"), "Zurich" },
                    { new Guid("5d6023c8-b399-453d-bf87-5207ed42e22c"), new Guid("1ea15fa3-b1bd-48ee-9dca-d21a7d6949c6"), "Helsinki" },
                    { new Guid("70a3cd86-735e-46b5-b7c8-04a28679c306"), new Guid("59a3b6f2-0a52-4ece-91ad-d1e82c8e76af"), "Istanbul" },
                    { new Guid("7ad68124-8c52-4875-8524-0c685b213e95"), new Guid("d22fa459-6392-4087-8032-c91629911001"), "Toronto" },
                    { new Guid("7b16c0c7-607d-4f52-81ab-8a8f02cc64ce"), new Guid("409cf3ad-5332-406a-b4c9-a6b7ea870f84"), "Barcelona" },
                    { new Guid("7e7b9f4c-a61c-4e46-8c0e-fff51e2221a3"), new Guid("80568834-32d8-4b15-a780-e75d651a9f5b"), "Copenhagen" },
                    { new Guid("87579910-4811-4e7e-8528-547120593464"), new Guid("9c9b3260-07e6-4d84-9644-bd0e8ad77559"), "London" },
                    { new Guid("886b7ee4-56d7-4dc3-a5ff-6af07ab9b17a"), new Guid("c5086443-129b-47dd-b4ed-aa65d0cc64f5"), "Dubai" },
                    { new Guid("99970f6d-eff6-4998-bf38-c457c236c704"), new Guid("7ceffbfe-2856-499b-8934-6ed7a9795e70"), "Cape Town" },
                    { new Guid("9db3a3c3-7cb6-40ab-a61b-653d3c1893d3"), new Guid("9f4d4a88-e2b8-47cf-ae47-9ea74a6a5945"), "Paris" },
                    { new Guid("a5026003-17d9-4731-846b-09ff6cb39eb1"), new Guid("facadbc8-ff7d-4621-a2ae-66bf6a6021ee"), "Brussels" },
                    { new Guid("a72d356e-1480-4411-b4c2-ba5bd48668e5"), new Guid("17e9fd33-e93d-4023-a78c-42a45746a5be"), "Buenos Aires" },
                    { new Guid("ab7913b3-51b3-4428-a02e-a1e5b88d0194"), new Guid("c3170370-a4d7-4e13-8213-6158ff33f1e0"), "Rome" },
                    { new Guid("acda80c2-867b-4fba-aef1-f6e677f7eb30"), new Guid("0803dc59-89ce-4cfc-b0b2-5b6c54ce64a7"), "Oslo" },
                    { new Guid("b0121ff8-0f52-4769-afc0-618b2e417165"), new Guid("52b85311-a54b-4a54-a483-244b54f71ffb"), "Los Angeles" },
                    { new Guid("b302da91-4e2a-430e-8ae6-d13d04d08256"), new Guid("63de4049-fab7-402a-abc8-57ab548fdc1a"), "Amsterdam" },
                    { new Guid("c01403d7-50e7-4ef4-a51d-f60b27142176"), new Guid("ffb6e493-e33b-4813-a905-4fc8d7b03e50"), "Lisbon" },
                    { new Guid("c8a6ae11-fddc-4da7-aafd-26583a509d0f"), new Guid("9371d39a-7348-4b38-8ce6-ba6c8a7ee117"), "Hanoi" },
                    { new Guid("c8b0a223-1c55-47df-9b4a-28f183098f08"), new Guid("106d71a9-7b79-4164-a468-fdeba9cea694"), "Budapest" },
                    { new Guid("cb47050e-e56e-4f1d-ab15-14330d2734e5"), new Guid("5c3db35f-1aeb-45c4-9b5c-1fbb3b3090fd"), "Rio de Janeiro" },
                    { new Guid("d044ea28-fd62-4a62-b1dd-38a65a78a4fd"), new Guid("0b43694d-a33a-4ccb-8ec6-ed6880925fb1"), "Singapore" },
                    { new Guid("d309f76c-df6a-4211-8056-3a5ffe8a1b01"), new Guid("a1ddb73e-8de9-433e-b03e-6615deccc12d"), "Auckland" },
                    { new Guid("dad305e8-6533-4f91-b03e-d538d174c3d7"), new Guid("e4cc77ea-e360-457e-9b3a-e82d5560974f"), "Nairobi" },
                    { new Guid("dc503588-4863-4691-bfd5-0a1e53350969"), new Guid("f1eca1e3-ef5d-4ad2-8b24-61c944b1aa1a"), "Prague" },
                    { new Guid("e2a84088-4f7b-4a46-ba97-f9f4063e3e61"), new Guid("e1447b0f-0fe5-4958-a127-3d890325d00b"), "Athens" },
                    { new Guid("ec4a5fa4-9b6f-488f-b950-797334c17702"), new Guid("3ec86250-c4f1-466a-8531-0f73685e9983"), "Mumbai" },
                    { new Guid("ed850d2e-98c4-4741-8b2b-4f1b5eb2fd0e"), new Guid("c0b5867d-dd77-4be9-b67c-94a1d3407c09"), "Berlin" },
                    { new Guid("ef7c2cbc-01cc-4f4d-a1ed-1085e60e4ea9"), new Guid("045f42d5-c3d9-43ca-92a5-127e9a22047a"), "Beijing" },
                    { new Guid("f5819ea5-a149-47be-9225-22327bb647ea"), new Guid("9d7e46f0-d2bf-4d7b-b8e6-a93598749f63"), "Stockholm" },
                    { new Guid("f725c43c-cf8e-4247-bb82-d413b3f580a3"), new Guid("045f42d5-c3d9-43ca-92a5-127e9a22047a"), "Hong Kong" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sprinklers_SprinkleModeEntity_ModeId",
                table: "Sprinklers",
                column: "ModeId",
                principalTable: "SprinkleModeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachineModeEntity_WashingMachines_WashingMachineEnti~",
                table: "WashingMachineModeEntity",
                column: "WashingMachineEntityId",
                principalTable: "WashingMachines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachines_WashingMachineModeEntity_CurrentModeId",
                table: "WashingMachines",
                column: "CurrentModeId",
                principalTable: "WashingMachineModeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
