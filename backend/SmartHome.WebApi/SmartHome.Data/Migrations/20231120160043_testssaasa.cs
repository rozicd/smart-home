using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class testssaasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachines_WashingMachineModes_CurrentModeId",
                table: "WashingMachines");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0680ae2a-23be-4c38-bf5e-ce8b89149219"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("17f06129-f6be-4d85-a50b-527fda9bece3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1dc1f1cf-768d-424f-aa5f-41956b1614a5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("223468d1-c838-4733-ba66-5cb97cf9b11e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("25dd483f-a109-45d4-a2c7-fb17535b9865"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2616c9c4-1328-4561-bde9-32ba72b7448c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2753b55e-c49f-4858-8071-208786542fbb"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3659f5a6-5cbf-49f5-adbd-e98ebf064f9a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("39f0fc86-cd82-4e77-8ce7-0a55efbf9e11"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("41ac3c53-706a-4ed2-ac3a-3f682728fda8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("41e4490e-b380-47fd-ba10-a803815e202c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("446f2fbb-c3f8-447c-ae77-c89349720943"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("45e154a4-044e-49ce-b10f-ab324de6481d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("468f1c84-5793-4c0e-bf54-71596e38eeaa"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4796e598-9296-4876-95e6-4eb4b98d9dea"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("513eac37-8fbf-47a2-8d71-385f17af577f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("54c0c9b4-232d-46c9-afe2-e8c0187b45e1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("579b5ce1-78f7-49a6-ae55-e577585aa337"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5ab48680-36c0-4f14-a2b3-a3f87a34188e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5ae52838-a0c6-4eeb-a29f-7f7be0ceb355"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6574c091-4b0e-477a-bb62-5eb2b2aa413c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("67c57068-d13c-414d-8421-7ed56c9133f3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6846304f-be67-4551-acb1-eafd1f502e32"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6f3937dc-439d-4491-ab25-d2c602f3763d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7c7009fc-c744-4343-b05a-9147ebc80775"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9bb7c5a2-7047-4728-afec-b81058db8b16"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a2a54c02-f5cb-44b8-ac29-c8835a43967c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a464db0d-20e9-4d51-9457-b4c3e159cc98"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a693dfc5-d93b-4ac8-9cf0-6d9dec2967f7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a720cf13-173e-4993-ba17-88df1f91354e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("aaf64bd5-9c6c-4764-8688-c6d2f3d0c265"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b41e8d68-5d7b-4718-a876-1d018e4d6bcf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c159768b-a386-4eef-9395-2e048365f2c0"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c608d58c-118e-4eb3-9a5f-2ae62ab68e92"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c6a11de4-cba9-4713-8a94-e9209cd8b1c8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c75a8923-0e7a-4ff9-bb7e-e85cd9797d9a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ca0f4d88-c22c-46fe-9890-8f04cdea2c42"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cb1e9d69-bdd7-4996-a8bb-351674f0a490"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e7893701-7976-487d-b3fd-732629753b3e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e8229a9d-84a3-4680-97f1-6b08953d7b04"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f16d6245-7473-4f69-ba69-473011313451"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f7ef10a3-966c-495f-becb-ae902058dd30"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ffa3b0b7-985d-447b-9937-a17fc293d2bc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("03c5c85e-3d36-4ae9-8ffa-0ceca960375d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("068229ec-aa5d-485a-9d33-55b98476e083"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("07923a07-bbc9-4430-bca7-4fa8ab4d285a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("08bf0948-2545-43ce-bd63-a9ecbbdab857"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ae5dadd-2eeb-4bc6-a75a-4c81061d02d6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1e99d342-9e2c-4a9a-a258-5462104dd390"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1fcad7a9-ab66-4735-b501-9ef338938b62"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("202698fc-481f-47f5-84c3-ad91fa4cce03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("20e1b203-3527-409e-845e-86559aa65991"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3759b8b1-be01-4c23-bf19-59819e4756d9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a17a0c6-8a37-4b57-bb6a-aea88503fa85"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3d706f52-aa83-4e8d-a381-88673b31c70a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3da287b6-be7a-4447-9580-2ee45c711b37"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3f17b554-ca49-47e1-9627-c1f69649ccfd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42467fd1-a29e-44e4-863c-16b358d7c776"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42533db0-1e9f-4a27-b31b-98ebcf658514"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f002df8-0c8a-41f9-b66a-3699ddbeb029"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78d2f36b-11c2-44fe-8e8d-13040fd15486"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7facfb79-7a17-4d71-9171-bbba8a71b46a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8356d3e9-e0fd-4100-804e-3a4c2b9050ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8a0ff199-2053-4eb2-a86b-9cdde7e9dea8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8f670858-d3cc-4423-8da0-94f970160682"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("94f5e989-d24f-4330-9660-c38d42c3330c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("95e16d9f-08ce-46aa-9237-f079c91d23f7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9d8deb01-2585-4961-ab6c-7354f89886e4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a1c6dc73-0ecc-4f4f-9dc4-d5793566dbde"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a6d94df4-d368-4f28-ae27-ee42d209cc09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a82348c0-569f-4fef-a8ff-fc3466fa2142"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac2b1f2c-1b00-40ee-a6a7-d1fe4fd8de87"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b533e272-d1db-42fd-9920-ae9a8d601f19"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bfd47464-69b2-4677-966f-1adbe50e6d70"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c94790ae-246f-4e88-86cd-35c0fba341b5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("da089639-ea5f-492b-9031-a79b8fbde6cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("db7e1306-e1b7-45be-a555-9d7c9788da0f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4c81ecb-e5c4-4741-b398-bb4566955811"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8cc6ced-11d9-46cc-a20e-ec8d658db44c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e95f592b-75ef-4897-bc24-cdf3f2db0af7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed1d6e52-5f48-42fb-b8a9-98d03da97e54"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0518549-cee4-4d9d-9e6a-3b34599cba20"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f0dfa8b7-5dbe-47f0-9d37-f510d3b529c6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentModeId",
                table: "WashingMachines",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02b9ad19-af00-45da-872e-3aa9d6ed987c"), "Poland" },
                    { new Guid("08beb3ff-ea89-4e81-a0f4-d8eb638a8860"), "India" },
                    { new Guid("0cb3d793-f325-46dd-958d-8ba2e02fa7a3"), "Denmark" },
                    { new Guid("1111aaa6-556e-454a-9c2f-d983ecb62f3e"), "Japan" },
                    { new Guid("13716c3c-f4c3-4b78-96c0-048ddfce615a"), "USA" },
                    { new Guid("1e4e3833-1729-4c27-9a8b-45b9e8b46e5d"), "Turkey" },
                    { new Guid("29ee7af6-9cd4-42eb-be13-ebe2d686788a"), "Greece" },
                    { new Guid("2a0613cd-5380-41be-b431-4eecac68dfd5"), "Norway" },
                    { new Guid("2e32c56e-e024-4357-a9e5-cb5ec87d934a"), "Belgium" },
                    { new Guid("2e9c552c-308b-4fc0-933d-7fb5c26cd6ef"), "Ireland" },
                    { new Guid("3a77dfb6-ff73-4498-a5e1-4c0be13a9db9"), "Canada" },
                    { new Guid("497894c7-7d84-4bdf-83dd-da37181f3bbf"), "Netherlands" },
                    { new Guid("49a04141-b07c-4deb-a862-8b5f254e503e"), "Vietnam" },
                    { new Guid("4cd527d8-0483-4aa2-b318-723d8a8e96e7"), "Hungary" },
                    { new Guid("505e6786-947c-4e43-8f1c-748466f5393d"), "Portugal" },
                    { new Guid("5194a043-65a4-49d7-9fd2-e868fbaa3aa9"), "France" },
                    { new Guid("584aa65d-b8a6-4e57-aeee-8ef8ab9c5805"), "Spain" },
                    { new Guid("5cef1a83-df35-4fbd-873f-966c106b4441"), "Italy" },
                    { new Guid("649953f2-f93a-403c-b78a-097a5a192289"), "Brazil" },
                    { new Guid("72efab69-2c7b-482b-974e-10578106a089"), "Argentina" },
                    { new Guid("7bd2231a-48a4-488f-b99d-2490eb05c6b0"), "New Zealand" },
                    { new Guid("8de1345e-6385-4a14-8896-4df827560fb8"), "Austria" },
                    { new Guid("8e0a5183-f8e9-47f8-a45c-d0f1aa53e32b"), "UK" },
                    { new Guid("933fd123-6113-418d-91dc-0f036d656290"), "Russia" },
                    { new Guid("939bfd4d-780f-40a5-a479-3a9f8e2ef345"), "Germany" },
                    { new Guid("94460da3-3510-4139-98fd-27f983217742"), "Switzerland" },
                    { new Guid("a7446207-0e7f-460d-a6af-79b276ae70fa"), "Singapore" },
                    { new Guid("b7156ebb-2452-4cba-b745-4effdd8d897f"), "Sweden" },
                    { new Guid("bff05973-6fd7-4565-94bc-f0c00040c4b1"), "Mexico" },
                    { new Guid("c0672983-d2bc-4e36-b13f-83d209ab892a"), "Finland" },
                    { new Guid("c1517d4a-d37e-4427-949b-1540b4d4ef13"), "South Africa" },
                    { new Guid("c1edb356-231a-42f8-af75-783259de18e4"), "Thailand" },
                    { new Guid("c234b0d0-ef70-455c-87ff-d0fb52d82c03"), "Czech Republic" },
                    { new Guid("c428c298-1d27-41ef-b58f-7b35980346a1"), "Kenya" },
                    { new Guid("c43f3800-6c59-4c5b-8be1-81670f273f18"), "South Korea" },
                    { new Guid("d630c4af-9b5f-460b-a2f0-5caee4bc084b"), "Nigeria" },
                    { new Guid("d766a17c-11b1-4471-97c9-fdcb8b298c9f"), "Australia" },
                    { new Guid("df8b6d2e-c6a2-45b7-b319-5921859d900a"), "Egypt" },
                    { new Guid("eed7cba4-561d-42de-9798-1b93bfb7318e"), "China" },
                    { new Guid("feb42961-64a2-4993-938b-38ae036ee56c"), "UAE" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("02c8fcc9-fe2f-4142-9ed1-c811eeaaa5e6"), new Guid("d766a17c-11b1-4471-97c9-fdcb8b298c9f"), "Sydney" },
                    { new Guid("048c40fb-e689-41cd-8698-0fd79a0277ec"), new Guid("7bd2231a-48a4-488f-b99d-2490eb05c6b0"), "Auckland" },
                    { new Guid("0589a4d7-845e-465c-8c68-9708564acc71"), new Guid("497894c7-7d84-4bdf-83dd-da37181f3bbf"), "Amsterdam" },
                    { new Guid("0770e78c-53d0-4e5c-bf9f-6e3c182fdd03"), new Guid("5cef1a83-df35-4fbd-873f-966c106b4441"), "Rome" },
                    { new Guid("0a640d11-c721-4e6f-9096-1fe6fb181fec"), new Guid("584aa65d-b8a6-4e57-aeee-8ef8ab9c5805"), "Barcelona" },
                    { new Guid("0e86a01d-fdff-45ad-92d6-b04be9c58c76"), new Guid("c234b0d0-ef70-455c-87ff-d0fb52d82c03"), "Prague" },
                    { new Guid("261449ba-5033-423e-891a-5db5928446fa"), new Guid("13716c3c-f4c3-4b78-96c0-048ddfce615a"), "Chicago" },
                    { new Guid("26955b6e-56cf-49a7-9e45-7031e717a596"), new Guid("b7156ebb-2452-4cba-b745-4effdd8d897f"), "Stockholm" },
                    { new Guid("29f043fe-c7c1-4391-aeb7-d0ae01631dbb"), new Guid("c0672983-d2bc-4e36-b13f-83d209ab892a"), "Helsinki" },
                    { new Guid("308cc1d7-4105-4a8f-ad39-7c01b1f83b8d"), new Guid("1111aaa6-556e-454a-9c2f-d983ecb62f3e"), "Tokyo" },
                    { new Guid("33a68431-f6b6-4ddd-9a3e-034b15684e40"), new Guid("df8b6d2e-c6a2-45b7-b319-5921859d900a"), "Cairo" },
                    { new Guid("4bc1b3e7-fba3-44b6-83bc-af9963e29039"), new Guid("649953f2-f93a-403c-b78a-097a5a192289"), "Rio de Janeiro" },
                    { new Guid("553618a1-d410-4f51-89f6-237a0624128a"), new Guid("72efab69-2c7b-482b-974e-10578106a089"), "Buenos Aires" },
                    { new Guid("571bb5e6-b11c-47f3-a9ca-95d9a1b568e7"), new Guid("c1edb356-231a-42f8-af75-783259de18e4"), "Bangkok" },
                    { new Guid("5e7cf8ea-099f-4109-b354-0042b245fbb7"), new Guid("eed7cba4-561d-42de-9798-1b93bfb7318e"), "Hong Kong" },
                    { new Guid("63139d34-b4fa-44fa-a20f-a60f6a72d374"), new Guid("eed7cba4-561d-42de-9798-1b93bfb7318e"), "Beijing" },
                    { new Guid("6b11a826-23d2-4aaa-b5e5-9cd2ad7aa8ce"), new Guid("13716c3c-f4c3-4b78-96c0-048ddfce615a"), "Los Angeles" },
                    { new Guid("77188360-6fa2-48a1-83fb-9802d707a101"), new Guid("08beb3ff-ea89-4e81-a0f4-d8eb638a8860"), "Mumbai" },
                    { new Guid("80c3b4d7-0155-4706-a614-604559257c08"), new Guid("505e6786-947c-4e43-8f1c-748466f5393d"), "Lisbon" },
                    { new Guid("928f54cb-1438-41dc-87a8-01f72bb2178d"), new Guid("4cd527d8-0483-4aa2-b318-723d8a8e96e7"), "Budapest" },
                    { new Guid("944e387d-c3c1-437d-939b-27e4e70d301b"), new Guid("feb42961-64a2-4993-938b-38ae036ee56c"), "Dubai" },
                    { new Guid("959377aa-1ded-46a5-9d53-af5fb604921f"), new Guid("2a0613cd-5380-41be-b431-4eecac68dfd5"), "Oslo" },
                    { new Guid("9732cf5f-8868-42a8-9fd3-fa3a80063e6e"), new Guid("c43f3800-6c59-4c5b-8be1-81670f273f18"), "Seoul" },
                    { new Guid("abfdef4b-7c38-4583-9857-b87b559bf27e"), new Guid("5194a043-65a4-49d7-9fd2-e868fbaa3aa9"), "Paris" },
                    { new Guid("ae95cd84-5e0c-4f70-bbc8-1626ed9c6ca9"), new Guid("2e32c56e-e024-4357-a9e5-cb5ec87d934a"), "Brussels" },
                    { new Guid("b55de13a-9150-4fd6-b2ec-d3509183e60e"), new Guid("a7446207-0e7f-460d-a6af-79b276ae70fa"), "Singapore" },
                    { new Guid("b7facaf4-dbc3-49b2-9335-239005fa7a9b"), new Guid("94460da3-3510-4139-98fd-27f983217742"), "Zurich" },
                    { new Guid("b8d04243-366e-4625-a591-208d9be41b70"), new Guid("bff05973-6fd7-4565-94bc-f0c00040c4b1"), "Mexico City" },
                    { new Guid("bc95bc4c-4bf6-492c-9632-42bd6c08d454"), new Guid("d630c4af-9b5f-460b-a2f0-5caee4bc084b"), "Lagos" },
                    { new Guid("bd36de93-0c8e-421a-a9cb-c8bcdb10ccc6"), new Guid("8de1345e-6385-4a14-8896-4df827560fb8"), "Vienna" },
                    { new Guid("c047b8dd-252b-4f49-b53b-97a2bf8711f7"), new Guid("8e0a5183-f8e9-47f8-a45c-d0f1aa53e32b"), "London" },
                    { new Guid("c4adb8c9-b008-444c-9c4f-c7c2eb6f7917"), new Guid("2e9c552c-308b-4fc0-933d-7fb5c26cd6ef"), "Dublin" },
                    { new Guid("c715aa96-a179-4ad6-9b12-9fb3876ae826"), new Guid("02b9ad19-af00-45da-872e-3aa9d6ed987c"), "Warsaw" },
                    { new Guid("cb394446-2801-483a-9a92-77f4f0c04b3b"), new Guid("933fd123-6113-418d-91dc-0f036d656290"), "Moscow" },
                    { new Guid("d293540b-afd4-42da-9c16-1f0d8f3f37e3"), new Guid("c1517d4a-d37e-4427-949b-1540b4d4ef13"), "Cape Town" },
                    { new Guid("d41dd90a-3e2a-49c8-bc0e-70985c3c2318"), new Guid("3a77dfb6-ff73-4498-a5e1-4c0be13a9db9"), "Toronto" },
                    { new Guid("db2a6d31-6b0f-4b36-99d2-770822e1ed9e"), new Guid("1e4e3833-1729-4c27-9a8b-45b9e8b46e5d"), "Istanbul" },
                    { new Guid("dccb1c84-502b-48af-86c7-4b1fa9f0d4f4"), new Guid("49a04141-b07c-4deb-a862-8b5f254e503e"), "Hanoi" },
                    { new Guid("e326c1c0-bad1-4e0c-9731-9b0b9c621ae7"), new Guid("0cb3d793-f325-46dd-958d-8ba2e02fa7a3"), "Copenhagen" },
                    { new Guid("f22a2c1e-42e8-47d5-98be-5073a504cb3d"), new Guid("c428c298-1d27-41ef-b58f-7b35980346a1"), "Nairobi" },
                    { new Guid("f71b9aa2-2ccb-44ce-8352-ef436b260ac4"), new Guid("13716c3c-f4c3-4b78-96c0-048ddfce615a"), "New York" },
                    { new Guid("feab2395-0966-4fc4-a96c-e4c50c32a3db"), new Guid("29ee7af6-9cd4-42eb-be13-ebe2d686788a"), "Athens" },
                    { new Guid("ffc365a3-fde3-4db0-b262-59c9fff597a2"), new Guid("939bfd4d-780f-40a5-a479-3a9f8e2ef345"), "Berlin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachines_WashingMachineModes_CurrentModeId",
                table: "WashingMachines",
                column: "CurrentModeId",
                principalTable: "WashingMachineModes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WashingMachines_WashingMachineModes_CurrentModeId",
                table: "WashingMachines");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("02c8fcc9-fe2f-4142-9ed1-c811eeaaa5e6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("048c40fb-e689-41cd-8698-0fd79a0277ec"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0589a4d7-845e-465c-8c68-9708564acc71"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0770e78c-53d0-4e5c-bf9f-6e3c182fdd03"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0a640d11-c721-4e6f-9096-1fe6fb181fec"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0e86a01d-fdff-45ad-92d6-b04be9c58c76"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("261449ba-5033-423e-891a-5db5928446fa"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("26955b6e-56cf-49a7-9e45-7031e717a596"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("29f043fe-c7c1-4391-aeb7-d0ae01631dbb"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("308cc1d7-4105-4a8f-ad39-7c01b1f83b8d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("33a68431-f6b6-4ddd-9a3e-034b15684e40"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4bc1b3e7-fba3-44b6-83bc-af9963e29039"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("553618a1-d410-4f51-89f6-237a0624128a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("571bb5e6-b11c-47f3-a9ca-95d9a1b568e7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5e7cf8ea-099f-4109-b354-0042b245fbb7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("63139d34-b4fa-44fa-a20f-a60f6a72d374"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6b11a826-23d2-4aaa-b5e5-9cd2ad7aa8ce"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("77188360-6fa2-48a1-83fb-9802d707a101"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("80c3b4d7-0155-4706-a614-604559257c08"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("928f54cb-1438-41dc-87a8-01f72bb2178d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("944e387d-c3c1-437d-939b-27e4e70d301b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("959377aa-1ded-46a5-9d53-af5fb604921f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9732cf5f-8868-42a8-9fd3-fa3a80063e6e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("abfdef4b-7c38-4583-9857-b87b559bf27e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ae95cd84-5e0c-4f70-bbc8-1626ed9c6ca9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b55de13a-9150-4fd6-b2ec-d3509183e60e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b7facaf4-dbc3-49b2-9335-239005fa7a9b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b8d04243-366e-4625-a591-208d9be41b70"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bc95bc4c-4bf6-492c-9632-42bd6c08d454"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bd36de93-0c8e-421a-a9cb-c8bcdb10ccc6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c047b8dd-252b-4f49-b53b-97a2bf8711f7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c4adb8c9-b008-444c-9c4f-c7c2eb6f7917"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c715aa96-a179-4ad6-9b12-9fb3876ae826"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cb394446-2801-483a-9a92-77f4f0c04b3b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d293540b-afd4-42da-9c16-1f0d8f3f37e3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d41dd90a-3e2a-49c8-bc0e-70985c3c2318"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("db2a6d31-6b0f-4b36-99d2-770822e1ed9e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dccb1c84-502b-48af-86c7-4b1fa9f0d4f4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e326c1c0-bad1-4e0c-9731-9b0b9c621ae7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f22a2c1e-42e8-47d5-98be-5073a504cb3d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f71b9aa2-2ccb-44ce-8352-ef436b260ac4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("feab2395-0966-4fc4-a96c-e4c50c32a3db"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ffc365a3-fde3-4db0-b262-59c9fff597a2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("02b9ad19-af00-45da-872e-3aa9d6ed987c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("08beb3ff-ea89-4e81-a0f4-d8eb638a8860"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0cb3d793-f325-46dd-958d-8ba2e02fa7a3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1111aaa6-556e-454a-9c2f-d983ecb62f3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("13716c3c-f4c3-4b78-96c0-048ddfce615a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1e4e3833-1729-4c27-9a8b-45b9e8b46e5d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("29ee7af6-9cd4-42eb-be13-ebe2d686788a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2a0613cd-5380-41be-b431-4eecac68dfd5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e32c56e-e024-4357-a9e5-cb5ec87d934a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2e9c552c-308b-4fc0-933d-7fb5c26cd6ef"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a77dfb6-ff73-4498-a5e1-4c0be13a9db9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("497894c7-7d84-4bdf-83dd-da37181f3bbf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("49a04141-b07c-4deb-a862-8b5f254e503e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4cd527d8-0483-4aa2-b318-723d8a8e96e7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("505e6786-947c-4e43-8f1c-748466f5393d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5194a043-65a4-49d7-9fd2-e868fbaa3aa9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("584aa65d-b8a6-4e57-aeee-8ef8ab9c5805"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5cef1a83-df35-4fbd-873f-966c106b4441"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("649953f2-f93a-403c-b78a-097a5a192289"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("72efab69-2c7b-482b-974e-10578106a089"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7bd2231a-48a4-488f-b99d-2490eb05c6b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8de1345e-6385-4a14-8896-4df827560fb8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8e0a5183-f8e9-47f8-a45c-d0f1aa53e32b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("933fd123-6113-418d-91dc-0f036d656290"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("939bfd4d-780f-40a5-a479-3a9f8e2ef345"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("94460da3-3510-4139-98fd-27f983217742"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a7446207-0e7f-460d-a6af-79b276ae70fa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b7156ebb-2452-4cba-b745-4effdd8d897f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bff05973-6fd7-4565-94bc-f0c00040c4b1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c0672983-d2bc-4e36-b13f-83d209ab892a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1517d4a-d37e-4427-949b-1540b4d4ef13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1edb356-231a-42f8-af75-783259de18e4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c234b0d0-ef70-455c-87ff-d0fb52d82c03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c428c298-1d27-41ef-b58f-7b35980346a1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c43f3800-6c59-4c5b-8be1-81670f273f18"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d630c4af-9b5f-460b-a2f0-5caee4bc084b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d766a17c-11b1-4471-97c9-fdcb8b298c9f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("df8b6d2e-c6a2-45b7-b319-5921859d900a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eed7cba4-561d-42de-9798-1b93bfb7318e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("feb42961-64a2-4993-938b-38ae036ee56c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentModeId",
                table: "WashingMachines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03c5c85e-3d36-4ae9-8ffa-0ceca960375d"), "Switzerland" },
                    { new Guid("068229ec-aa5d-485a-9d33-55b98476e083"), "Sweden" },
                    { new Guid("07923a07-bbc9-4430-bca7-4fa8ab4d285a"), "Thailand" },
                    { new Guid("08bf0948-2545-43ce-bd63-a9ecbbdab857"), "USA" },
                    { new Guid("1ae5dadd-2eeb-4bc6-a75a-4c81061d02d6"), "Brazil" },
                    { new Guid("1e99d342-9e2c-4a9a-a258-5462104dd390"), "South Africa" },
                    { new Guid("1fcad7a9-ab66-4735-b501-9ef338938b62"), "Japan" },
                    { new Guid("202698fc-481f-47f5-84c3-ad91fa4cce03"), "Italy" },
                    { new Guid("20e1b203-3527-409e-845e-86559aa65991"), "India" },
                    { new Guid("3759b8b1-be01-4c23-bf19-59819e4756d9"), "Australia" },
                    { new Guid("3a17a0c6-8a37-4b57-bb6a-aea88503fa85"), "Canada" },
                    { new Guid("3d706f52-aa83-4e8d-a381-88673b31c70a"), "Vietnam" },
                    { new Guid("3da287b6-be7a-4447-9580-2ee45c711b37"), "Singapore" },
                    { new Guid("3f17b554-ca49-47e1-9627-c1f69649ccfd"), "Hungary" },
                    { new Guid("42467fd1-a29e-44e4-863c-16b358d7c776"), "Denmark" },
                    { new Guid("42533db0-1e9f-4a27-b31b-98ebcf658514"), "Mexico" },
                    { new Guid("6f002df8-0c8a-41f9-b66a-3699ddbeb029"), "Spain" },
                    { new Guid("78d2f36b-11c2-44fe-8e8d-13040fd15486"), "UK" },
                    { new Guid("7facfb79-7a17-4d71-9171-bbba8a71b46a"), "South Korea" },
                    { new Guid("8356d3e9-e0fd-4100-804e-3a4c2b9050ba"), "France" },
                    { new Guid("8a0ff199-2053-4eb2-a86b-9cdde7e9dea8"), "Austria" },
                    { new Guid("8f670858-d3cc-4423-8da0-94f970160682"), "UAE" },
                    { new Guid("94f5e989-d24f-4330-9660-c38d42c3330c"), "China" },
                    { new Guid("95e16d9f-08ce-46aa-9237-f079c91d23f7"), "Netherlands" },
                    { new Guid("9d8deb01-2585-4961-ab6c-7354f89886e4"), "Greece" },
                    { new Guid("a1c6dc73-0ecc-4f4f-9dc4-d5793566dbde"), "Finland" },
                    { new Guid("a6d94df4-d368-4f28-ae27-ee42d209cc09"), "Kenya" },
                    { new Guid("a82348c0-569f-4fef-a8ff-fc3466fa2142"), "Ireland" },
                    { new Guid("ac2b1f2c-1b00-40ee-a6a7-d1fe4fd8de87"), "Poland" },
                    { new Guid("b533e272-d1db-42fd-9920-ae9a8d601f19"), "Belgium" },
                    { new Guid("bfd47464-69b2-4677-966f-1adbe50e6d70"), "Czech Republic" },
                    { new Guid("c94790ae-246f-4e88-86cd-35c0fba341b5"), "Portugal" },
                    { new Guid("da089639-ea5f-492b-9031-a79b8fbde6cd"), "Egypt" },
                    { new Guid("db7e1306-e1b7-45be-a555-9d7c9788da0f"), "New Zealand" },
                    { new Guid("e4c81ecb-e5c4-4741-b398-bb4566955811"), "Nigeria" },
                    { new Guid("e8cc6ced-11d9-46cc-a20e-ec8d658db44c"), "Turkey" },
                    { new Guid("e95f592b-75ef-4897-bc24-cdf3f2db0af7"), "Norway" },
                    { new Guid("ed1d6e52-5f48-42fb-b8a9-98d03da97e54"), "Germany" },
                    { new Guid("f0518549-cee4-4d9d-9e6a-3b34599cba20"), "Argentina" },
                    { new Guid("f0dfa8b7-5dbe-47f0-9d37-f510d3b529c6"), "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0680ae2a-23be-4c38-bf5e-ce8b89149219"), new Guid("3da287b6-be7a-4447-9580-2ee45c711b37"), "Singapore" },
                    { new Guid("17f06129-f6be-4d85-a50b-527fda9bece3"), new Guid("20e1b203-3527-409e-845e-86559aa65991"), "Mumbai" },
                    { new Guid("1dc1f1cf-768d-424f-aa5f-41956b1614a5"), new Guid("3759b8b1-be01-4c23-bf19-59819e4756d9"), "Sydney" },
                    { new Guid("223468d1-c838-4733-ba66-5cb97cf9b11e"), new Guid("42467fd1-a29e-44e4-863c-16b358d7c776"), "Copenhagen" },
                    { new Guid("25dd483f-a109-45d4-a2c7-fb17535b9865"), new Guid("94f5e989-d24f-4330-9660-c38d42c3330c"), "Hong Kong" },
                    { new Guid("2616c9c4-1328-4561-bde9-32ba72b7448c"), new Guid("8a0ff199-2053-4eb2-a86b-9cdde7e9dea8"), "Vienna" },
                    { new Guid("2753b55e-c49f-4858-8071-208786542fbb"), new Guid("7facfb79-7a17-4d71-9171-bbba8a71b46a"), "Seoul" },
                    { new Guid("3659f5a6-5cbf-49f5-adbd-e98ebf064f9a"), new Guid("1e99d342-9e2c-4a9a-a258-5462104dd390"), "Cape Town" },
                    { new Guid("39f0fc86-cd82-4e77-8ce7-0a55efbf9e11"), new Guid("a82348c0-569f-4fef-a8ff-fc3466fa2142"), "Dublin" },
                    { new Guid("41ac3c53-706a-4ed2-ac3a-3f682728fda8"), new Guid("42533db0-1e9f-4a27-b31b-98ebcf658514"), "Mexico City" },
                    { new Guid("41e4490e-b380-47fd-ba10-a803815e202c"), new Guid("e95f592b-75ef-4897-bc24-cdf3f2db0af7"), "Oslo" },
                    { new Guid("446f2fbb-c3f8-447c-ae77-c89349720943"), new Guid("08bf0948-2545-43ce-bd63-a9ecbbdab857"), "Los Angeles" },
                    { new Guid("45e154a4-044e-49ce-b10f-ab324de6481d"), new Guid("94f5e989-d24f-4330-9660-c38d42c3330c"), "Beijing" },
                    { new Guid("468f1c84-5793-4c0e-bf54-71596e38eeaa"), new Guid("1fcad7a9-ab66-4735-b501-9ef338938b62"), "Tokyo" },
                    { new Guid("4796e598-9296-4876-95e6-4eb4b98d9dea"), new Guid("a6d94df4-d368-4f28-ae27-ee42d209cc09"), "Nairobi" },
                    { new Guid("513eac37-8fbf-47a2-8d71-385f17af577f"), new Guid("db7e1306-e1b7-45be-a555-9d7c9788da0f"), "Auckland" },
                    { new Guid("54c0c9b4-232d-46c9-afe2-e8c0187b45e1"), new Guid("c94790ae-246f-4e88-86cd-35c0fba341b5"), "Lisbon" },
                    { new Guid("579b5ce1-78f7-49a6-ae55-e577585aa337"), new Guid("b533e272-d1db-42fd-9920-ae9a8d601f19"), "Brussels" },
                    { new Guid("5ab48680-36c0-4f14-a2b3-a3f87a34188e"), new Guid("3a17a0c6-8a37-4b57-bb6a-aea88503fa85"), "Toronto" },
                    { new Guid("5ae52838-a0c6-4eeb-a29f-7f7be0ceb355"), new Guid("78d2f36b-11c2-44fe-8e8d-13040fd15486"), "London" },
                    { new Guid("6574c091-4b0e-477a-bb62-5eb2b2aa413c"), new Guid("202698fc-481f-47f5-84c3-ad91fa4cce03"), "Rome" },
                    { new Guid("67c57068-d13c-414d-8421-7ed56c9133f3"), new Guid("6f002df8-0c8a-41f9-b66a-3699ddbeb029"), "Barcelona" },
                    { new Guid("6846304f-be67-4551-acb1-eafd1f502e32"), new Guid("07923a07-bbc9-4430-bca7-4fa8ab4d285a"), "Bangkok" },
                    { new Guid("6f3937dc-439d-4491-ab25-d2c602f3763d"), new Guid("f0dfa8b7-5dbe-47f0-9d37-f510d3b529c6"), "Moscow" },
                    { new Guid("7c7009fc-c744-4343-b05a-9147ebc80775"), new Guid("ed1d6e52-5f48-42fb-b8a9-98d03da97e54"), "Berlin" },
                    { new Guid("9bb7c5a2-7047-4728-afec-b81058db8b16"), new Guid("a1c6dc73-0ecc-4f4f-9dc4-d5793566dbde"), "Helsinki" },
                    { new Guid("a2a54c02-f5cb-44b8-ac29-c8835a43967c"), new Guid("ac2b1f2c-1b00-40ee-a6a7-d1fe4fd8de87"), "Warsaw" },
                    { new Guid("a464db0d-20e9-4d51-9457-b4c3e159cc98"), new Guid("8f670858-d3cc-4423-8da0-94f970160682"), "Dubai" },
                    { new Guid("a693dfc5-d93b-4ac8-9cf0-6d9dec2967f7"), new Guid("03c5c85e-3d36-4ae9-8ffa-0ceca960375d"), "Zurich" },
                    { new Guid("a720cf13-173e-4993-ba17-88df1f91354e"), new Guid("3f17b554-ca49-47e1-9627-c1f69649ccfd"), "Budapest" },
                    { new Guid("aaf64bd5-9c6c-4764-8688-c6d2f3d0c265"), new Guid("e4c81ecb-e5c4-4741-b398-bb4566955811"), "Lagos" },
                    { new Guid("b41e8d68-5d7b-4718-a876-1d018e4d6bcf"), new Guid("9d8deb01-2585-4961-ab6c-7354f89886e4"), "Athens" },
                    { new Guid("c159768b-a386-4eef-9395-2e048365f2c0"), new Guid("08bf0948-2545-43ce-bd63-a9ecbbdab857"), "Chicago" },
                    { new Guid("c608d58c-118e-4eb3-9a5f-2ae62ab68e92"), new Guid("da089639-ea5f-492b-9031-a79b8fbde6cd"), "Cairo" },
                    { new Guid("c6a11de4-cba9-4713-8a94-e9209cd8b1c8"), new Guid("3d706f52-aa83-4e8d-a381-88673b31c70a"), "Hanoi" },
                    { new Guid("c75a8923-0e7a-4ff9-bb7e-e85cd9797d9a"), new Guid("f0518549-cee4-4d9d-9e6a-3b34599cba20"), "Buenos Aires" },
                    { new Guid("ca0f4d88-c22c-46fe-9890-8f04cdea2c42"), new Guid("8356d3e9-e0fd-4100-804e-3a4c2b9050ba"), "Paris" },
                    { new Guid("cb1e9d69-bdd7-4996-a8bb-351674f0a490"), new Guid("e8cc6ced-11d9-46cc-a20e-ec8d658db44c"), "Istanbul" },
                    { new Guid("e7893701-7976-487d-b3fd-732629753b3e"), new Guid("08bf0948-2545-43ce-bd63-a9ecbbdab857"), "New York" },
                    { new Guid("e8229a9d-84a3-4680-97f1-6b08953d7b04"), new Guid("1ae5dadd-2eeb-4bc6-a75a-4c81061d02d6"), "Rio de Janeiro" },
                    { new Guid("f16d6245-7473-4f69-ba69-473011313451"), new Guid("068229ec-aa5d-485a-9d33-55b98476e083"), "Stockholm" },
                    { new Guid("f7ef10a3-966c-495f-becb-ae902058dd30"), new Guid("95e16d9f-08ce-46aa-9237-f079c91d23f7"), "Amsterdam" },
                    { new Guid("ffa3b0b7-985d-447b-9937-a17fc293d2bc"), new Guid("bfd47464-69b2-4677-966f-1adbe50e6d70"), "Prague" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WashingMachines_WashingMachineModes_CurrentModeId",
                table: "WashingMachines",
                column: "CurrentModeId",
                principalTable: "WashingMachineModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
