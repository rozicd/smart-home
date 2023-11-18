using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class asx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnvironmentalConditionsSensors_Users_UserId",
                table: "EnvironmentalConditionsSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnvironmentalConditionsSensors",
                table: "EnvironmentalConditionsSensors");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("025b4f49-bf30-45cb-affe-6a34e1aba4b6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("02917a8e-416a-4cd9-adf6-739792bd6016"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12874959-2995-479b-b280-b41d0716b261"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1a975889-0e59-4472-96e7-f176ec78fd3d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1c864655-644a-4c68-98a2-66a91a18a587"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2d861b87-b537-4891-bf07-696c3e9f9bf3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("37fe0bc9-03d6-4ef5-85d8-07c63ae2e86f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38fa18dd-5cd6-4078-b687-89dccd9c47a0"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("39b2af47-bf5f-45b4-a902-8ca82a15c1f0"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3ba0c7cd-cc53-407a-a50d-9a9348c19fba"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("42509673-eca4-401e-9aed-19840d3b87d3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("48b6ee8e-83f6-45ba-9f7a-e0e352dec970"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4e660e53-6d7e-4349-a7fd-21bf60079eb5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4f0ac43c-9460-410a-824a-25f32e83667a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("58aeb1af-eb71-4611-b667-6d4269973442"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("58bb9888-b326-47a4-b773-3b49847d9b3b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5e0f65e8-fc54-4500-bb37-4d7fd219120a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("62272b92-06c1-4b60-89f7-608a85f74df9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("66a34ea8-05b7-4fea-9434-59d9a9243e1d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("69236f31-f412-4f02-a7b1-34f7a926337b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("742923bf-5281-4aa5-ae21-3b52e197ea25"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8c2280e0-54d8-49e3-b7d9-5e7520d3911f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8f447d83-eafd-4b7d-9c34-c9c9711f2a1c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("986a4c4a-b1ee-4020-b558-7e9ed5db8463"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9fe51711-a6f4-45b0-92ba-31c163be6309"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a0fbe8c3-9171-4c52-be9c-e948335d2e92"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a1095970-f744-4334-b41e-b38e0c8d106d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a751717f-1741-4f80-8ef6-a422b1cf0857"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a82f9eee-b104-4b48-b7d2-952060ae6aab"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a8bd80aa-7955-4842-b43b-b57f898a0568"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ba9ad9e9-e74e-429b-8f1a-0a2a3e0adb1e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c39c5fad-d2df-494a-9604-d8bbfd2a6e17"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c4f749ec-b422-4383-a31b-2f896e52460d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c7a3cd93-91d3-4e6b-a440-9a2ce1e92227"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d3e23f32-fe6e-4ad3-8d39-ae416528c79a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d40f2005-b82a-446c-b8d6-eeaf43979aef"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d873639b-c516-4f2f-9b29-4d94c5ad9326"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("db5d7749-68a2-470b-8a7c-5e1e4cee1a2a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("df9cb790-23ab-4af6-a773-12cbd4c8eb66"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e8af23e0-5211-4596-9d3b-198edfb30aae"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("eef39606-9206-490e-a22a-f982792fb9d7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f0d0946a-94af-47a9-9da4-0f62474c2c44"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f3131274-65d4-4390-a0b1-5f4296f74733"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00a37fb5-0342-4fc1-9579-16caf71fa126"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("00c651a8-abde-437d-9126-375fa6c9b0a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0e752679-387a-46a0-a213-f925d1089e06"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1ac2c1c1-051f-43fb-aa74-06bdeead2138"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("241a7192-dfaa-42c6-9d3a-650c4462fe79"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2eeeb467-a913-4055-bfc2-8b54364023b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ce3968e-fe0e-4c27-9a21-6a32653cd1bd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4423e5ac-4734-4c54-bdc8-6f3e70834797"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5924fd67-953c-467c-bc5f-87913c6a0345"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c0f2c4c-6307-4971-823b-b3b2570003d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5c6f37fb-761b-4019-994a-8e48236f4bc5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6625abaa-b1d2-438b-a0ac-da3da69f2810"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6ccae10a-a4d9-4b2b-8727-a443a9cc3921"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6d70790e-8625-4227-850e-8846a6fe7f3f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6e5a94d1-be6a-4f7a-9bcc-3a0d74064770"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("71e800ce-0988-424c-a102-fc5c2664bdb4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("72a38283-f08f-486c-8a83-c94405e3fd34"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7453bcc4-22d4-4d92-8622-3eaf0a802d63"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("78944876-6ba3-4397-b3eb-8580e7069197"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7a024f32-2049-4f77-b37a-710e39e51dad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("89d102f9-01c4-4fff-9d35-f162269896c2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8cb071f2-7567-4075-8599-aa7ed392ca00"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("989f8440-7833-445a-9176-6d76d9ddea4b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aecec9ad-1662-456d-ad74-ce9da234fc87"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b20ccc23-bed6-4b8c-aad4-1c47ada6cba8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bb2ab922-7206-4d54-be8e-f101e0d1abbe"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bd199e7b-b2e4-473e-b4af-99a9a9c0f951"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bdc1011d-957c-466c-b82b-0138670e68cd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("be351882-ef94-47d0-8f4c-125478258e59"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bf5c0c7a-c700-4324-9211-ecfcf3c0f751"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c90d037a-60af-4507-952d-5405a749bb1f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d4fab1c1-856e-4765-aa00-f831e612bfb3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e415098e-aef7-43d7-a1b4-98546a668181"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e5d102d6-8fb7-43c6-95a7-e76c998bc227"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ecf773fe-9643-4c34-84b4-bf0988b070eb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ee42f1df-40c1-4a7f-b74f-b448699e7abb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ef305156-73d4-4a21-b344-dbddad61f13b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f6b305d8-cb9d-413a-8403-c8978a2c2d74"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f6e3f2a2-a057-4871-8c5b-931618e5cc21"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f991fb80-eeba-4e45-98c1-a8c46d308495"));

            migrationBuilder.RenameTable(
                name: "EnvironmentalConditionsSensors",
                newName: "SmartDevices");

            migrationBuilder.RenameIndex(
                name: "IX_EnvironmentalConditionsSensors_UserId",
                table: "SmartDevices",
                newName: "IX_SmartDevices_UserId");

            migrationBuilder.AddColumn<string>(
                name: "SmartDeviceType",
                table: "SmartDevices",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmartDevices",
                table: "SmartDevices",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04eb8241-8fb2-480f-9ee8-0432d5e4b35d"), "Czech Republic" },
                    { new Guid("06b43574-4cb3-4a67-b14b-9546196b3fa2"), "China" },
                    { new Guid("094b5da8-7a19-4291-b987-3e5dced5f059"), "Brazil" },
                    { new Guid("0c7e623d-de8c-47b8-9029-049ba388b46f"), "South Africa" },
                    { new Guid("0da5653f-021a-41d1-baef-3a820e554831"), "Egypt" },
                    { new Guid("152f17fb-79e2-44d8-86dd-d8efb1fe1a78"), "Australia" },
                    { new Guid("1de329a0-2816-423a-84a2-f6a97549b3c9"), "India" },
                    { new Guid("21ca0b12-67d5-4753-8fe8-962f6c5e9236"), "Austria" },
                    { new Guid("249ddede-af56-4214-b252-1ef6a3be7bae"), "Mexico" },
                    { new Guid("2b86dc14-7878-494f-b958-e797b89b5fc2"), "USA" },
                    { new Guid("2bcf94de-cc9c-49e4-b8ec-220cf601b1fa"), "Portugal" },
                    { new Guid("313f63b1-16b4-406f-a67f-9af6bb92e5ac"), "Poland" },
                    { new Guid("34ee40aa-c2f3-49c4-bd3e-2759e0da0d30"), "Belgium" },
                    { new Guid("4090c727-c295-477c-aafd-ca7fa8120e78"), "UAE" },
                    { new Guid("425dc9c3-bdc6-4320-8f4b-47b32f08c8b8"), "Denmark" },
                    { new Guid("43a99cc1-d349-45f1-9c7d-fd8d1e96428f"), "Vietnam" },
                    { new Guid("4d53d04f-4b28-46d5-b20b-6b4841667ba8"), "Russia" },
                    { new Guid("4eba6996-319e-4a77-aab9-36a10aaf870d"), "South Korea" },
                    { new Guid("5812007b-90e0-44eb-b7cf-39a2660f852c"), "Canada" },
                    { new Guid("5cd90fb4-2efb-49ed-beb2-3f1d7eba3b0d"), "Finland" },
                    { new Guid("5ded7a9d-efbe-45b5-9afa-5417410d302a"), "Singapore" },
                    { new Guid("5ffdbebb-6cf0-4dbb-9868-cffeffe0e772"), "Switzerland" },
                    { new Guid("6c6fe3cb-db70-418b-8028-0884e2e5f2f3"), "Japan" },
                    { new Guid("7103a8a2-6d2e-433e-8ed8-c59a4fa80f15"), "Norway" },
                    { new Guid("714e2821-1325-4355-bb31-a7357e205932"), "Argentina" },
                    { new Guid("81596874-988d-4c89-9247-333d9fbd74dd"), "Turkey" },
                    { new Guid("8162009d-ca0c-4867-bf74-0729cdea38a0"), "Netherlands" },
                    { new Guid("82a38b43-2fc9-4151-a19f-4015f94d6493"), "Ireland" },
                    { new Guid("9022e7fc-1af5-4436-b47a-0ebc12e0a7ba"), "UK" },
                    { new Guid("9e6d0643-53c2-4915-858b-febe346b4765"), "France" },
                    { new Guid("a87955b2-2618-46e7-9135-578f73ad6a49"), "Spain" },
                    { new Guid("a8dbbaa0-2e85-4d0f-b4de-ee894acf39d4"), "Hungary" },
                    { new Guid("acdbd3b1-655d-442b-99c4-866bdb5a95b5"), "Thailand" },
                    { new Guid("b35988c3-2502-4622-a748-f5ad69b554aa"), "Italy" },
                    { new Guid("b3a76afc-5d0e-4ad1-804b-574b00ef38f9"), "Kenya" },
                    { new Guid("c1871859-963f-49b8-9fb9-5d69ea657b58"), "Greece" },
                    { new Guid("cdee8502-e94b-42f9-a3c2-d784de2f5214"), "New Zealand" },
                    { new Guid("d69a7d76-c2b8-4a0f-be21-9542264dc6ba"), "Nigeria" },
                    { new Guid("ddbf702d-5761-46ac-9cc5-c908df8e24a8"), "Sweden" },
                    { new Guid("ec57a5aa-e50b-4605-94f3-c5ce12fcf43e"), "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("0ee723c0-e133-4a95-b5e7-949a4fbc6d74"), new Guid("2b86dc14-7878-494f-b958-e797b89b5fc2"), "Chicago" },
                    { new Guid("1208dc22-8f3d-4967-80f5-8a4358eb7f8a"), new Guid("43a99cc1-d349-45f1-9c7d-fd8d1e96428f"), "Hanoi" },
                    { new Guid("17a0df9a-010e-4e62-afa8-cca2a93f2865"), new Guid("06b43574-4cb3-4a67-b14b-9546196b3fa2"), "Hong Kong" },
                    { new Guid("18b8bb8e-e458-42d3-82d1-9e41a0b58706"), new Guid("152f17fb-79e2-44d8-86dd-d8efb1fe1a78"), "Sydney" },
                    { new Guid("190cc2ef-a17d-49ff-a423-3e88ba12fda3"), new Guid("82a38b43-2fc9-4151-a19f-4015f94d6493"), "Dublin" },
                    { new Guid("1a223591-2ddf-48f0-9211-c30b9227bbc5"), new Guid("4eba6996-319e-4a77-aab9-36a10aaf870d"), "Seoul" },
                    { new Guid("1ce34eb5-ca67-4ae4-a72d-e3173a7a0551"), new Guid("ec57a5aa-e50b-4605-94f3-c5ce12fcf43e"), "Berlin" },
                    { new Guid("20a30bb5-a7dc-4664-b147-13781161015c"), new Guid("4d53d04f-4b28-46d5-b20b-6b4841667ba8"), "Moscow" },
                    { new Guid("2382247c-a7e2-4fb7-b1a4-4686022a3baf"), new Guid("acdbd3b1-655d-442b-99c4-866bdb5a95b5"), "Bangkok" },
                    { new Guid("268b1eb3-a2a3-49e0-9e03-c1a4d871aa74"), new Guid("5ded7a9d-efbe-45b5-9afa-5417410d302a"), "Singapore" },
                    { new Guid("38827d41-0d81-4979-9caa-94ead815cb48"), new Guid("0c7e623d-de8c-47b8-9029-049ba388b46f"), "Cape Town" },
                    { new Guid("395914b3-d096-4e4d-884d-e77dc0e4661e"), new Guid("9e6d0643-53c2-4915-858b-febe346b4765"), "Paris" },
                    { new Guid("407548bd-2bba-4ed5-ac7c-7ba1e8f1be1c"), new Guid("a87955b2-2618-46e7-9135-578f73ad6a49"), "Barcelona" },
                    { new Guid("468a7c6f-f359-4f56-a465-a85959b33949"), new Guid("2b86dc14-7878-494f-b958-e797b89b5fc2"), "New York" },
                    { new Guid("47e40f1f-6791-40cd-9d55-231436d49c09"), new Guid("2b86dc14-7878-494f-b958-e797b89b5fc2"), "Los Angeles" },
                    { new Guid("58672a50-4aaf-4caa-be40-785094befcf3"), new Guid("6c6fe3cb-db70-418b-8028-0884e2e5f2f3"), "Tokyo" },
                    { new Guid("60a63ab7-4e32-470b-8363-451728372574"), new Guid("b3a76afc-5d0e-4ad1-804b-574b00ef38f9"), "Nairobi" },
                    { new Guid("639ecea0-cd3e-4a01-a7be-fd559ceef989"), new Guid("81596874-988d-4c89-9247-333d9fbd74dd"), "Istanbul" },
                    { new Guid("64150bc5-ff60-4c39-85c1-d0600014e514"), new Guid("c1871859-963f-49b8-9fb9-5d69ea657b58"), "Athens" },
                    { new Guid("6a95c3a0-980a-4f86-afc9-78683cb614d5"), new Guid("ddbf702d-5761-46ac-9cc5-c908df8e24a8"), "Stockholm" },
                    { new Guid("6ec7a511-21ba-4daa-bf4a-aea29567e1ab"), new Guid("714e2821-1325-4355-bb31-a7357e205932"), "Buenos Aires" },
                    { new Guid("71530b18-0f95-428b-9b96-a74d4f9583f5"), new Guid("34ee40aa-c2f3-49c4-bd3e-2759e0da0d30"), "Brussels" },
                    { new Guid("739845f2-c4ba-40d3-8d6b-2cfbd93057b8"), new Guid("5cd90fb4-2efb-49ed-beb2-3f1d7eba3b0d"), "Helsinki" },
                    { new Guid("762b3530-e016-435e-8fa0-31c4e39c437e"), new Guid("d69a7d76-c2b8-4a0f-be21-9542264dc6ba"), "Lagos" },
                    { new Guid("7e5bf240-d6a8-4591-a523-d7e07224dab6"), new Guid("a8dbbaa0-2e85-4d0f-b4de-ee894acf39d4"), "Budapest" },
                    { new Guid("849cfd7a-824e-4464-94ff-c6cf4ce720b2"), new Guid("094b5da8-7a19-4291-b987-3e5dced5f059"), "Rio de Janeiro" },
                    { new Guid("8dc9c0ef-8e1f-4333-bd0f-42cd4ddd0c26"), new Guid("313f63b1-16b4-406f-a67f-9af6bb92e5ac"), "Warsaw" },
                    { new Guid("91ce24b0-c524-4ea3-8cdf-691d074b9ab5"), new Guid("425dc9c3-bdc6-4320-8f4b-47b32f08c8b8"), "Copenhagen" },
                    { new Guid("96bebaa9-2f13-43f8-bce3-ec9ab0b117a4"), new Guid("cdee8502-e94b-42f9-a3c2-d784de2f5214"), "Auckland" },
                    { new Guid("998ea7a5-0d15-4d8a-bfd4-c026d1f1f82c"), new Guid("1de329a0-2816-423a-84a2-f6a97549b3c9"), "Mumbai" },
                    { new Guid("9b9e58e3-1a1c-4c79-a199-4350eae3252d"), new Guid("8162009d-ca0c-4867-bf74-0729cdea38a0"), "Amsterdam" },
                    { new Guid("a85c418e-5782-4522-a73c-fff8d4245ef9"), new Guid("9022e7fc-1af5-4436-b47a-0ebc12e0a7ba"), "London" },
                    { new Guid("a970bb28-5193-43e9-a81f-f808af72ba61"), new Guid("b35988c3-2502-4622-a748-f5ad69b554aa"), "Rome" },
                    { new Guid("b6cdead3-df1d-4ac7-b1ab-3488de7d4687"), new Guid("06b43574-4cb3-4a67-b14b-9546196b3fa2"), "Beijing" },
                    { new Guid("b8f37e8a-83d8-4659-b1aa-d1c3b2a3509b"), new Guid("5ffdbebb-6cf0-4dbb-9868-cffeffe0e772"), "Zurich" },
                    { new Guid("c5546f47-9b38-45e9-9a86-97e00055ce67"), new Guid("2bcf94de-cc9c-49e4-b8ec-220cf601b1fa"), "Lisbon" },
                    { new Guid("d1a5be71-f597-42ca-9f92-d2b2d52280e4"), new Guid("249ddede-af56-4214-b252-1ef6a3be7bae"), "Mexico City" },
                    { new Guid("d6753720-af77-4cdf-9636-303b72ef8b7a"), new Guid("04eb8241-8fb2-480f-9ee8-0432d5e4b35d"), "Prague" },
                    { new Guid("d88c0a89-8ee1-4fbf-9518-af9cada14755"), new Guid("7103a8a2-6d2e-433e-8ed8-c59a4fa80f15"), "Oslo" },
                    { new Guid("e10ef7c7-a764-4989-b25b-9b2ee8bb55f1"), new Guid("5812007b-90e0-44eb-b7cf-39a2660f852c"), "Toronto" },
                    { new Guid("e6780323-d51d-4b58-87b0-c098944b6831"), new Guid("0da5653f-021a-41d1-baef-3a820e554831"), "Cairo" },
                    { new Guid("f5b42cd1-4d0b-4ab9-978b-402def5ef95f"), new Guid("4090c727-c295-477c-aafd-ca7fa8120e78"), "Dubai" },
                    { new Guid("f7c6cf4e-511b-42df-a660-e895b9b9d38e"), new Guid("21ca0b12-67d5-4753-8fe8-962f6c5e9236"), "Vienna" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SmartDevices_Users_UserId",
                table: "SmartDevices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartDevices_Users_UserId",
                table: "SmartDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmartDevices",
                table: "SmartDevices");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0ee723c0-e133-4a95-b5e7-949a4fbc6d74"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1208dc22-8f3d-4967-80f5-8a4358eb7f8a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("17a0df9a-010e-4e62-afa8-cca2a93f2865"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("18b8bb8e-e458-42d3-82d1-9e41a0b58706"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("190cc2ef-a17d-49ff-a423-3e88ba12fda3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1a223591-2ddf-48f0-9211-c30b9227bbc5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1ce34eb5-ca67-4ae4-a72d-e3173a7a0551"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("20a30bb5-a7dc-4664-b147-13781161015c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2382247c-a7e2-4fb7-b1a4-4686022a3baf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("268b1eb3-a2a3-49e0-9e03-c1a4d871aa74"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38827d41-0d81-4979-9caa-94ead815cb48"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("395914b3-d096-4e4d-884d-e77dc0e4661e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("407548bd-2bba-4ed5-ac7c-7ba1e8f1be1c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("468a7c6f-f359-4f56-a465-a85959b33949"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("47e40f1f-6791-40cd-9d55-231436d49c09"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("58672a50-4aaf-4caa-be40-785094befcf3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("60a63ab7-4e32-470b-8363-451728372574"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("639ecea0-cd3e-4a01-a7be-fd559ceef989"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("64150bc5-ff60-4c39-85c1-d0600014e514"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6a95c3a0-980a-4f86-afc9-78683cb614d5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6ec7a511-21ba-4daa-bf4a-aea29567e1ab"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("71530b18-0f95-428b-9b96-a74d4f9583f5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("739845f2-c4ba-40d3-8d6b-2cfbd93057b8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("762b3530-e016-435e-8fa0-31c4e39c437e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7e5bf240-d6a8-4591-a523-d7e07224dab6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("849cfd7a-824e-4464-94ff-c6cf4ce720b2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8dc9c0ef-8e1f-4333-bd0f-42cd4ddd0c26"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("91ce24b0-c524-4ea3-8cdf-691d074b9ab5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("96bebaa9-2f13-43f8-bce3-ec9ab0b117a4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("998ea7a5-0d15-4d8a-bfd4-c026d1f1f82c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9b9e58e3-1a1c-4c79-a199-4350eae3252d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a85c418e-5782-4522-a73c-fff8d4245ef9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a970bb28-5193-43e9-a81f-f808af72ba61"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b6cdead3-df1d-4ac7-b1ab-3488de7d4687"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b8f37e8a-83d8-4659-b1aa-d1c3b2a3509b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c5546f47-9b38-45e9-9a86-97e00055ce67"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d1a5be71-f597-42ca-9f92-d2b2d52280e4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d6753720-af77-4cdf-9636-303b72ef8b7a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d88c0a89-8ee1-4fbf-9518-af9cada14755"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e10ef7c7-a764-4989-b25b-9b2ee8bb55f1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e6780323-d51d-4b58-87b0-c098944b6831"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f5b42cd1-4d0b-4ab9-978b-402def5ef95f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f7c6cf4e-511b-42df-a660-e895b9b9d38e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04eb8241-8fb2-480f-9ee8-0432d5e4b35d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("06b43574-4cb3-4a67-b14b-9546196b3fa2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("094b5da8-7a19-4291-b987-3e5dced5f059"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0c7e623d-de8c-47b8-9029-049ba388b46f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0da5653f-021a-41d1-baef-3a820e554831"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("152f17fb-79e2-44d8-86dd-d8efb1fe1a78"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1de329a0-2816-423a-84a2-f6a97549b3c9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("21ca0b12-67d5-4753-8fe8-962f6c5e9236"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("249ddede-af56-4214-b252-1ef6a3be7bae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2b86dc14-7878-494f-b958-e797b89b5fc2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2bcf94de-cc9c-49e4-b8ec-220cf601b1fa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("313f63b1-16b4-406f-a67f-9af6bb92e5ac"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("34ee40aa-c2f3-49c4-bd3e-2759e0da0d30"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4090c727-c295-477c-aafd-ca7fa8120e78"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("425dc9c3-bdc6-4320-8f4b-47b32f08c8b8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("43a99cc1-d349-45f1-9c7d-fd8d1e96428f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d53d04f-4b28-46d5-b20b-6b4841667ba8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4eba6996-319e-4a77-aab9-36a10aaf870d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5812007b-90e0-44eb-b7cf-39a2660f852c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5cd90fb4-2efb-49ed-beb2-3f1d7eba3b0d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5ded7a9d-efbe-45b5-9afa-5417410d302a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5ffdbebb-6cf0-4dbb-9868-cffeffe0e772"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6c6fe3cb-db70-418b-8028-0884e2e5f2f3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7103a8a2-6d2e-433e-8ed8-c59a4fa80f15"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("714e2821-1325-4355-bb31-a7357e205932"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("81596874-988d-4c89-9247-333d9fbd74dd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8162009d-ca0c-4867-bf74-0729cdea38a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("82a38b43-2fc9-4151-a19f-4015f94d6493"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9022e7fc-1af5-4436-b47a-0ebc12e0a7ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9e6d0643-53c2-4915-858b-febe346b4765"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a87955b2-2618-46e7-9135-578f73ad6a49"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a8dbbaa0-2e85-4d0f-b4de-ee894acf39d4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acdbd3b1-655d-442b-99c4-866bdb5a95b5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b35988c3-2502-4622-a748-f5ad69b554aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b3a76afc-5d0e-4ad1-804b-574b00ef38f9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c1871859-963f-49b8-9fb9-5d69ea657b58"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cdee8502-e94b-42f9-a3c2-d784de2f5214"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d69a7d76-c2b8-4a0f-be21-9542264dc6ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ddbf702d-5761-46ac-9cc5-c908df8e24a8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ec57a5aa-e50b-4605-94f3-c5ce12fcf43e"));

            migrationBuilder.DropColumn(
                name: "SmartDeviceType",
                table: "SmartDevices");

            migrationBuilder.RenameTable(
                name: "SmartDevices",
                newName: "EnvironmentalConditionsSensors");

            migrationBuilder.RenameIndex(
                name: "IX_SmartDevices_UserId",
                table: "EnvironmentalConditionsSensors",
                newName: "IX_EnvironmentalConditionsSensors_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnvironmentalConditionsSensors",
                table: "EnvironmentalConditionsSensors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00a37fb5-0342-4fc1-9579-16caf71fa126"), "Portugal" },
                    { new Guid("00c651a8-abde-437d-9126-375fa6c9b0a5"), "Thailand" },
                    { new Guid("0e752679-387a-46a0-a213-f925d1089e06"), "India" },
                    { new Guid("1ac2c1c1-051f-43fb-aa74-06bdeead2138"), "UAE" },
                    { new Guid("241a7192-dfaa-42c6-9d3a-650c4462fe79"), "Kenya" },
                    { new Guid("2eeeb467-a913-4055-bfc2-8b54364023b8"), "Spain" },
                    { new Guid("3ce3968e-fe0e-4c27-9a21-6a32653cd1bd"), "Switzerland" },
                    { new Guid("4423e5ac-4734-4c54-bdc8-6f3e70834797"), "China" },
                    { new Guid("5924fd67-953c-467c-bc5f-87913c6a0345"), "New Zealand" },
                    { new Guid("5c0f2c4c-6307-4971-823b-b3b2570003d1"), "Denmark" },
                    { new Guid("5c6f37fb-761b-4019-994a-8e48236f4bc5"), "Russia" },
                    { new Guid("6625abaa-b1d2-438b-a0ac-da3da69f2810"), "Sweden" },
                    { new Guid("6ccae10a-a4d9-4b2b-8727-a443a9cc3921"), "Turkey" },
                    { new Guid("6d70790e-8625-4227-850e-8846a6fe7f3f"), "Singapore" },
                    { new Guid("6e5a94d1-be6a-4f7a-9bcc-3a0d74064770"), "Italy" },
                    { new Guid("71e800ce-0988-424c-a102-fc5c2664bdb4"), "USA" },
                    { new Guid("72a38283-f08f-486c-8a83-c94405e3fd34"), "Egypt" },
                    { new Guid("7453bcc4-22d4-4d92-8622-3eaf0a802d63"), "Brazil" },
                    { new Guid("78944876-6ba3-4397-b3eb-8580e7069197"), "Czech Republic" },
                    { new Guid("7a024f32-2049-4f77-b37a-710e39e51dad"), "Poland" },
                    { new Guid("89d102f9-01c4-4fff-9d35-f162269896c2"), "Argentina" },
                    { new Guid("8cb071f2-7567-4075-8599-aa7ed392ca00"), "Japan" },
                    { new Guid("989f8440-7833-445a-9176-6d76d9ddea4b"), "Austria" },
                    { new Guid("aecec9ad-1662-456d-ad74-ce9da234fc87"), "Hungary" },
                    { new Guid("b20ccc23-bed6-4b8c-aad4-1c47ada6cba8"), "Netherlands" },
                    { new Guid("bb2ab922-7206-4d54-be8e-f101e0d1abbe"), "Ireland" },
                    { new Guid("bd199e7b-b2e4-473e-b4af-99a9a9c0f951"), "Germany" },
                    { new Guid("bdc1011d-957c-466c-b82b-0138670e68cd"), "France" },
                    { new Guid("be351882-ef94-47d0-8f4c-125478258e59"), "South Korea" },
                    { new Guid("bf5c0c7a-c700-4324-9211-ecfcf3c0f751"), "Australia" },
                    { new Guid("c90d037a-60af-4507-952d-5405a749bb1f"), "South Africa" },
                    { new Guid("d4fab1c1-856e-4765-aa00-f831e612bfb3"), "Nigeria" },
                    { new Guid("e415098e-aef7-43d7-a1b4-98546a668181"), "Greece" },
                    { new Guid("e5d102d6-8fb7-43c6-95a7-e76c998bc227"), "Norway" },
                    { new Guid("ecf773fe-9643-4c34-84b4-bf0988b070eb"), "Canada" },
                    { new Guid("ee42f1df-40c1-4a7f-b74f-b448699e7abb"), "Vietnam" },
                    { new Guid("ef305156-73d4-4a21-b344-dbddad61f13b"), "UK" },
                    { new Guid("f6b305d8-cb9d-413a-8403-c8978a2c2d74"), "Finland" },
                    { new Guid("f6e3f2a2-a057-4871-8c5b-931618e5cc21"), "Mexico" },
                    { new Guid("f991fb80-eeba-4e45-98c1-a8c46d308495"), "Belgium" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("025b4f49-bf30-45cb-affe-6a34e1aba4b6"), new Guid("89d102f9-01c4-4fff-9d35-f162269896c2"), "Buenos Aires" },
                    { new Guid("02917a8e-416a-4cd9-adf6-739792bd6016"), new Guid("ef305156-73d4-4a21-b344-dbddad61f13b"), "London" },
                    { new Guid("12874959-2995-479b-b280-b41d0716b261"), new Guid("2eeeb467-a913-4055-bfc2-8b54364023b8"), "Barcelona" },
                    { new Guid("1a975889-0e59-4472-96e7-f176ec78fd3d"), new Guid("bdc1011d-957c-466c-b82b-0138670e68cd"), "Paris" },
                    { new Guid("1c864655-644a-4c68-98a2-66a91a18a587"), new Guid("7a024f32-2049-4f77-b37a-710e39e51dad"), "Warsaw" },
                    { new Guid("2d861b87-b537-4891-bf07-696c3e9f9bf3"), new Guid("4423e5ac-4734-4c54-bdc8-6f3e70834797"), "Hong Kong" },
                    { new Guid("37fe0bc9-03d6-4ef5-85d8-07c63ae2e86f"), new Guid("7453bcc4-22d4-4d92-8622-3eaf0a802d63"), "Rio de Janeiro" },
                    { new Guid("38fa18dd-5cd6-4078-b687-89dccd9c47a0"), new Guid("e5d102d6-8fb7-43c6-95a7-e76c998bc227"), "Oslo" },
                    { new Guid("39b2af47-bf5f-45b4-a902-8ca82a15c1f0"), new Guid("00c651a8-abde-437d-9126-375fa6c9b0a5"), "Bangkok" },
                    { new Guid("3ba0c7cd-cc53-407a-a50d-9a9348c19fba"), new Guid("0e752679-387a-46a0-a213-f925d1089e06"), "Mumbai" },
                    { new Guid("42509673-eca4-401e-9aed-19840d3b87d3"), new Guid("6625abaa-b1d2-438b-a0ac-da3da69f2810"), "Stockholm" },
                    { new Guid("48b6ee8e-83f6-45ba-9f7a-e0e352dec970"), new Guid("b20ccc23-bed6-4b8c-aad4-1c47ada6cba8"), "Amsterdam" },
                    { new Guid("4e660e53-6d7e-4349-a7fd-21bf60079eb5"), new Guid("f6b305d8-cb9d-413a-8403-c8978a2c2d74"), "Helsinki" },
                    { new Guid("4f0ac43c-9460-410a-824a-25f32e83667a"), new Guid("bf5c0c7a-c700-4324-9211-ecfcf3c0f751"), "Sydney" },
                    { new Guid("58aeb1af-eb71-4611-b667-6d4269973442"), new Guid("f6e3f2a2-a057-4871-8c5b-931618e5cc21"), "Mexico City" },
                    { new Guid("58bb9888-b326-47a4-b773-3b49847d9b3b"), new Guid("71e800ce-0988-424c-a102-fc5c2664bdb4"), "New York" },
                    { new Guid("5e0f65e8-fc54-4500-bb37-4d7fd219120a"), new Guid("71e800ce-0988-424c-a102-fc5c2664bdb4"), "Chicago" },
                    { new Guid("62272b92-06c1-4b60-89f7-608a85f74df9"), new Guid("3ce3968e-fe0e-4c27-9a21-6a32653cd1bd"), "Zurich" },
                    { new Guid("66a34ea8-05b7-4fea-9434-59d9a9243e1d"), new Guid("be351882-ef94-47d0-8f4c-125478258e59"), "Seoul" },
                    { new Guid("69236f31-f412-4f02-a7b1-34f7a926337b"), new Guid("5c0f2c4c-6307-4971-823b-b3b2570003d1"), "Copenhagen" },
                    { new Guid("742923bf-5281-4aa5-ae21-3b52e197ea25"), new Guid("5c6f37fb-761b-4019-994a-8e48236f4bc5"), "Moscow" },
                    { new Guid("8c2280e0-54d8-49e3-b7d9-5e7520d3911f"), new Guid("f991fb80-eeba-4e45-98c1-a8c46d308495"), "Brussels" },
                    { new Guid("8f447d83-eafd-4b7d-9c34-c9c9711f2a1c"), new Guid("989f8440-7833-445a-9176-6d76d9ddea4b"), "Vienna" },
                    { new Guid("986a4c4a-b1ee-4020-b558-7e9ed5db8463"), new Guid("6ccae10a-a4d9-4b2b-8727-a443a9cc3921"), "Istanbul" },
                    { new Guid("9fe51711-a6f4-45b0-92ba-31c163be6309"), new Guid("241a7192-dfaa-42c6-9d3a-650c4462fe79"), "Nairobi" },
                    { new Guid("a0fbe8c3-9171-4c52-be9c-e948335d2e92"), new Guid("bd199e7b-b2e4-473e-b4af-99a9a9c0f951"), "Berlin" },
                    { new Guid("a1095970-f744-4334-b41e-b38e0c8d106d"), new Guid("c90d037a-60af-4507-952d-5405a749bb1f"), "Cape Town" },
                    { new Guid("a751717f-1741-4f80-8ef6-a422b1cf0857"), new Guid("6d70790e-8625-4227-850e-8846a6fe7f3f"), "Singapore" },
                    { new Guid("a82f9eee-b104-4b48-b7d2-952060ae6aab"), new Guid("00a37fb5-0342-4fc1-9579-16caf71fa126"), "Lisbon" },
                    { new Guid("a8bd80aa-7955-4842-b43b-b57f898a0568"), new Guid("6e5a94d1-be6a-4f7a-9bcc-3a0d74064770"), "Rome" },
                    { new Guid("ba9ad9e9-e74e-429b-8f1a-0a2a3e0adb1e"), new Guid("bb2ab922-7206-4d54-be8e-f101e0d1abbe"), "Dublin" },
                    { new Guid("c39c5fad-d2df-494a-9604-d8bbfd2a6e17"), new Guid("ecf773fe-9643-4c34-84b4-bf0988b070eb"), "Toronto" },
                    { new Guid("c4f749ec-b422-4383-a31b-2f896e52460d"), new Guid("aecec9ad-1662-456d-ad74-ce9da234fc87"), "Budapest" },
                    { new Guid("c7a3cd93-91d3-4e6b-a440-9a2ce1e92227"), new Guid("8cb071f2-7567-4075-8599-aa7ed392ca00"), "Tokyo" },
                    { new Guid("d3e23f32-fe6e-4ad3-8d39-ae416528c79a"), new Guid("1ac2c1c1-051f-43fb-aa74-06bdeead2138"), "Dubai" },
                    { new Guid("d40f2005-b82a-446c-b8d6-eeaf43979aef"), new Guid("72a38283-f08f-486c-8a83-c94405e3fd34"), "Cairo" },
                    { new Guid("d873639b-c516-4f2f-9b29-4d94c5ad9326"), new Guid("d4fab1c1-856e-4765-aa00-f831e612bfb3"), "Lagos" },
                    { new Guid("db5d7749-68a2-470b-8a7c-5e1e4cee1a2a"), new Guid("71e800ce-0988-424c-a102-fc5c2664bdb4"), "Los Angeles" },
                    { new Guid("df9cb790-23ab-4af6-a773-12cbd4c8eb66"), new Guid("e415098e-aef7-43d7-a1b4-98546a668181"), "Athens" },
                    { new Guid("e8af23e0-5211-4596-9d3b-198edfb30aae"), new Guid("5924fd67-953c-467c-bc5f-87913c6a0345"), "Auckland" },
                    { new Guid("eef39606-9206-490e-a22a-f982792fb9d7"), new Guid("4423e5ac-4734-4c54-bdc8-6f3e70834797"), "Beijing" },
                    { new Guid("f0d0946a-94af-47a9-9da4-0f62474c2c44"), new Guid("78944876-6ba3-4397-b3eb-8580e7069197"), "Prague" },
                    { new Guid("f3131274-65d4-4390-a0b1-5f4296f74733"), new Guid("ee42f1df-40c1-4a7f-b74f-b448699e7abb"), "Hanoi" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EnvironmentalConditionsSensors_Users_UserId",
                table: "EnvironmentalConditionsSensors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
