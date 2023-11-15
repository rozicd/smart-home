using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_state_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("068676fd-eb30-4360-9228-671e5f3af640"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0b5e7297-0c91-462e-97ba-c979312b1c34"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0ba6f3e8-0407-4dea-b92b-fd782a688a79"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0ceb5e2e-e328-42e6-8733-0febc8a9a869"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2257b18d-d7f0-451a-992d-7c821a3eb8c8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2385cbec-8697-4964-9b8a-b52f117be4d2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("23db35bb-9251-4202-b06e-5420672b74ad"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38215fbc-6ca2-4e10-85e1-d5be6c9af2fb"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3e044031-f4ff-4329-92be-87111328bf5b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("467b1f83-a872-415c-9ecd-2e6d76dbfea5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("46c42b20-da6a-46f8-86f2-c6e780b59b74"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("56b03cfb-48bc-44bc-b3d3-815cc5b964db"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5d957a27-5916-4094-9b79-dde9b259e68e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("678c7c05-d356-466f-9417-02aaa072e65b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6d2e2a48-45e2-4a9e-b0e7-e62918a22faf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("71d48394-f90b-4c9b-8d69-50a0ba3fbd2e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("77f5fe75-2f60-4a76-90e2-d445b2529344"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("85513312-3315-4536-804f-7ed3f332152d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("88ce900c-432b-4f46-8786-eea2d77b10ba"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8b07b70a-b51c-405c-9a5e-d2b00de0fbde"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8fde6d88-6914-4b67-b062-aaf79b8aa22f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("90fbf35a-de7c-4d55-8f87-cadbdec2af05"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9846bc0f-e3b1-4778-9aa5-33352f9e4215"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c0c80b9-02bf-4fe5-b713-9c50525d64d6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a123633b-a109-47dc-a4c0-0afa18e8be4d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a9705c60-c172-4820-b7e8-eb160fd21443"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ab0a8e1f-e4d2-4f20-b776-681333d2e9ae"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ad8e4fb1-f933-4eef-b335-24f38697101a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b54d6e16-d2c6-4e0a-abc8-5dabc7e6f2f5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b583d9d6-8274-49de-9f56-1222caed1fcc"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bb0f731f-d58e-4bcc-880b-2477a4f37b73"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bd450c30-ad38-48d9-9654-a947f90dc4a5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bd818fda-668d-47cf-a7c4-7a594f4deb22"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c85de4ae-6786-4e84-bc4e-40717952bd01"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c9432e20-beb8-4c61-b5c5-0dc1a9d4f406"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d91146e7-06a7-4cf6-a6e0-ed52acf19e57"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e1ed0dce-24ad-4cc3-bc40-82e0536f9c4b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e73c37f0-c4ab-4613-9ca5-26eae3400033"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e805b847-df83-42db-841d-58553b5e5376"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("eb220fbb-5364-40ef-babd-557fc8bfc3f8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f2009493-5511-4163-b8e1-e718236b1bcc"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fa9fd9a2-21b5-448c-abf8-3d00df2b8b74"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fd110166-ec59-4b39-a852-5cbace1b2444"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("001d0400-8069-4831-bd8a-e7960c77ca00"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("04f751fd-5041-40d4-a460-8644cff8d689"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("06ae197e-f7ec-4c4e-9b33-7423bc09d158"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0b2c3386-02e3-4147-a756-485ffb6a4b35"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("246a520b-beda-4eec-9305-e9504761a0ad"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2d153fbd-86b9-4cbd-a85a-edef793fa065"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("310ae403-e2d9-425b-ae37-11f9e6eba134"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("353316dd-f171-4149-951f-272a234bf910"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("39a1c684-b99e-4fc5-835b-4cfa4e7cb86a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3fe69907-2c99-4cb3-b5e2-919998a72dcf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("439e4dca-082a-48ac-a600-e4bb29baaf83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4a158e35-abd5-4cd6-8255-ee3920bb542b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4c6f861a-256b-40a3-a39b-030bfaebf0e8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55ac250e-9ff3-4dd1-8450-b3640517d08d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5bf24e24-1dc0-480c-ae29-345d828a1ca4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5fe2e7b2-2a1f-432a-8389-a4649ac221a5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60d49e4e-d733-4dbb-a4e9-ed89ae388fd3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6d863dff-235e-4b1c-8310-be6d9564c3c5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6e193476-c988-41a2-8a75-c5b6801d0caf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("73229010-6971-4016-82c0-056de0a0ee5a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("81c593af-2a7f-4589-8862-e0caaadb1c21"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("88547e50-5d34-4ae3-8384-6b671bf338ff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8e33f77e-ca76-40fb-b386-c10aaccfa4d3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("95539198-93cd-4555-a3b9-65c28486cc5f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a8f8631f-1671-4c1c-a9d6-6d919969e471"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ac48a9dd-df13-49a3-87fa-012c27900b62"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ad494b8c-1712-4dae-856e-b298c5594c0e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aeb2da0d-5b65-47f3-83a0-12f6764db54f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c04042c6-c471-4d2c-9617-2916a3c66bdc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c7ead1d2-a1f0-4f1c-a6d4-561ecffdab3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cca165f6-8567-491a-9a04-58a9fd715c10"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cdd4d44f-8a6f-4136-8d3c-c03905d14f46"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ce95ee7c-d4ee-4d10-b520-b397180335c4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d9bb4c52-7c1d-447b-8b2c-93d454e76491"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e1bfb08f-5636-44ec-a4db-bcc398d18f46"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4537558-1c23-40e0-a559-df1074d26b45"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9298563-8669-4661-900a-348a366e48db"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ecba7d9e-9b4f-4610-8096-87f6eb663110"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f74c5676-6f40-4447-9135-9fc19a7152bb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f801aba6-6ef2-483c-b987-d29bfa0a22b2"));

            migrationBuilder.DropColumn(
                name: "State",
                table: "Properties");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d61592e-651d-46d1-9296-908d08293212"), "Egypt" },
                    { new Guid("0d898d61-c525-43d4-8cd5-436d657e23d6"), "Russia" },
                    { new Guid("24abc113-c34b-42c9-9a6d-a23e299681e3"), "Thailand" },
                    { new Guid("4692cd79-1790-482a-9063-c7ba170f50b6"), "India" },
                    { new Guid("4732345b-8f5f-44f1-a5bd-64e2fbdffd83"), "Finland" },
                    { new Guid("4cad111c-9b24-4660-a87e-8cb369e37692"), "Canada" },
                    { new Guid("51cc5b23-f4a7-4fdc-8773-18455a391bb1"), "Greece" },
                    { new Guid("55e35db5-31f5-4184-b8ae-ec9b2f95283b"), "France" },
                    { new Guid("5d84c5c2-7bd5-444f-a274-0e9c05de7d3e"), "Hungary" },
                    { new Guid("61b345e2-9cf6-4f86-b4ed-c9b3c2a650df"), "China" },
                    { new Guid("69717bd8-d87f-4b73-a0cd-066e5f3736cf"), "Germany" },
                    { new Guid("69dc3b7c-672a-485f-99dd-1665973ec4b0"), "Japan" },
                    { new Guid("6a43676b-40ac-496b-9081-9625a78dade6"), "Poland" },
                    { new Guid("7e8b12b3-3cdc-489f-b276-7dc5605f169f"), "Netherlands" },
                    { new Guid("8636eef2-c829-4219-8fa2-5cf95e82f432"), "Norway" },
                    { new Guid("899ab8ff-d3a5-4967-ba6c-afd33b02d139"), "Spain" },
                    { new Guid("8a614192-9f1c-47cf-88ec-57bab38b7152"), "Kenya" },
                    { new Guid("8bcd6da6-779c-47f5-b962-295d4526a180"), "Argentina" },
                    { new Guid("8ebda805-936f-4155-b585-a3460c9ddbe9"), "New Zealand" },
                    { new Guid("9a4a487d-ef7b-42c6-8a51-45518c9808fd"), "Belgium" },
                    { new Guid("9f14667f-f967-46db-adc6-53b23ccf13b9"), "Sweden" },
                    { new Guid("9f516054-e2d4-4274-8dcf-4e9bd747c098"), "South Korea" },
                    { new Guid("a0d7e642-4556-456a-a645-df2b44722908"), "Nigeria" },
                    { new Guid("a1ff6be2-7ba6-41ea-8fff-a49a4e5ea918"), "Brazil" },
                    { new Guid("a487b860-868e-4375-ac13-0331b0625717"), "USA" },
                    { new Guid("a538f002-7836-4fff-ab81-4571c9082adf"), "Australia" },
                    { new Guid("a7245aba-9a18-4539-82a8-ed212377d8c3"), "Mexico" },
                    { new Guid("afb3148f-dd36-4cad-b92e-5bc83306f191"), "Czech Republic" },
                    { new Guid("bdca7b68-6b3b-468c-a512-809e19b5157b"), "Ireland" },
                    { new Guid("c517c32c-554a-47c4-a70d-e36aa98c1c9c"), "Denmark" },
                    { new Guid("c7b85521-7752-4e18-a15d-382c1f6ef0e3"), "UK" },
                    { new Guid("d8909638-9869-4772-b4f7-cb6022dee271"), "Singapore" },
                    { new Guid("e0d2a23b-301c-4b28-bcc6-c222055a2210"), "Austria" },
                    { new Guid("e4df2293-737e-415a-ae20-d5b53e6589ce"), "Italy" },
                    { new Guid("e5c66940-6e2b-4dd5-9a41-180f9bede4d4"), "Turkey" },
                    { new Guid("e9a53832-e676-4e7c-b3ca-f3ea075ffb51"), "Switzerland" },
                    { new Guid("e9c734e6-6695-4f90-8898-a4471c0e4470"), "Vietnam" },
                    { new Guid("ecd62d25-939c-483c-b234-942f26b3770c"), "Portugal" },
                    { new Guid("f577d21c-b996-4aca-9bf4-df146bf54b7d"), "South Africa" },
                    { new Guid("fd19e97f-6fe5-4c71-b07a-24ecb662e091"), "UAE" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("038bd5ae-5f4e-474f-be06-efe33b006f2c"), new Guid("a487b860-868e-4375-ac13-0331b0625717"), "New York" },
                    { new Guid("0856468f-ab04-4753-97a8-716d2bd6d05f"), new Guid("51cc5b23-f4a7-4fdc-8773-18455a391bb1"), "Athens" },
                    { new Guid("0c17fd42-ba6c-4946-b84f-c9a57ee18fd5"), new Guid("7e8b12b3-3cdc-489f-b276-7dc5605f169f"), "Amsterdam" },
                    { new Guid("18339fac-03fd-4a2b-9be7-e7acdc1f2808"), new Guid("bdca7b68-6b3b-468c-a512-809e19b5157b"), "Dublin" },
                    { new Guid("18fe8afd-85b2-4c03-9580-a229eb9ca9d1"), new Guid("8bcd6da6-779c-47f5-b962-295d4526a180"), "Buenos Aires" },
                    { new Guid("224bba57-dd9e-4dc6-9377-7a1909d08121"), new Guid("a487b860-868e-4375-ac13-0331b0625717"), "Chicago" },
                    { new Guid("224d50f9-17a5-4e98-b755-0267352c346e"), new Guid("69717bd8-d87f-4b73-a0cd-066e5f3736cf"), "Berlin" },
                    { new Guid("243da2bc-cef5-40ad-9630-51bb0efb5396"), new Guid("4732345b-8f5f-44f1-a5bd-64e2fbdffd83"), "Helsinki" },
                    { new Guid("2b9248f0-e302-4c7d-9b5c-9ed7de0b0e50"), new Guid("61b345e2-9cf6-4f86-b4ed-c9b3c2a650df"), "Beijing" },
                    { new Guid("3050e751-9cc4-481b-8f49-0223f75d3047"), new Guid("c517c32c-554a-47c4-a70d-e36aa98c1c9c"), "Copenhagen" },
                    { new Guid("3921bf84-2687-4fc9-b327-ae58497fc1bf"), new Guid("9f516054-e2d4-4274-8dcf-4e9bd747c098"), "Seoul" },
                    { new Guid("3a3857b3-56ef-45ab-b527-be03c4f63463"), new Guid("a538f002-7836-4fff-ab81-4571c9082adf"), "Sydney" },
                    { new Guid("4366aee7-32b4-41d2-8560-5ac069229b40"), new Guid("ecd62d25-939c-483c-b234-942f26b3770c"), "Lisbon" },
                    { new Guid("47600cc1-f971-4d4a-af86-2cff072eee43"), new Guid("e9c734e6-6695-4f90-8898-a4471c0e4470"), "Hanoi" },
                    { new Guid("4bbd88f5-a474-4bc9-bc16-9b6bde86338b"), new Guid("899ab8ff-d3a5-4967-ba6c-afd33b02d139"), "Barcelona" },
                    { new Guid("56c02b16-fce1-427e-a46d-fea9eaccc0c3"), new Guid("0d61592e-651d-46d1-9296-908d08293212"), "Cairo" },
                    { new Guid("62750f6c-d369-412a-9b61-b2396790cdc4"), new Guid("e4df2293-737e-415a-ae20-d5b53e6589ce"), "Rome" },
                    { new Guid("713a20a9-15c5-4474-88f4-fb8e13e32401"), new Guid("d8909638-9869-4772-b4f7-cb6022dee271"), "Singapore" },
                    { new Guid("7b5d464b-14cd-4c2a-9e9c-93517e9e756f"), new Guid("4692cd79-1790-482a-9063-c7ba170f50b6"), "Mumbai" },
                    { new Guid("83f2cc6a-bef2-4046-8250-8b9639fafb2b"), new Guid("8ebda805-936f-4155-b585-a3460c9ddbe9"), "Auckland" },
                    { new Guid("8849cc57-5f7a-4bea-84eb-fd8fa54b4a12"), new Guid("f577d21c-b996-4aca-9bf4-df146bf54b7d"), "Cape Town" },
                    { new Guid("8fc14292-5e4d-42b0-8791-e55855023798"), new Guid("e5c66940-6e2b-4dd5-9a41-180f9bede4d4"), "Istanbul" },
                    { new Guid("91b7106f-114e-437f-938a-954a770f042b"), new Guid("61b345e2-9cf6-4f86-b4ed-c9b3c2a650df"), "Hong Kong" },
                    { new Guid("9bf5dac3-ebc1-4404-a0a7-ee9d0eb16681"), new Guid("8636eef2-c829-4219-8fa2-5cf95e82f432"), "Oslo" },
                    { new Guid("9eb6c78a-ab27-46f3-9412-bb6dbb07dc8d"), new Guid("4cad111c-9b24-4660-a87e-8cb369e37692"), "Toronto" },
                    { new Guid("b0ef0e10-aba9-45c0-9ef1-da085e7f0a45"), new Guid("a487b860-868e-4375-ac13-0331b0625717"), "Los Angeles" },
                    { new Guid("b3157d30-8cf3-400b-a6b8-e69617517cdf"), new Guid("9f14667f-f967-46db-adc6-53b23ccf13b9"), "Stockholm" },
                    { new Guid("b7f69cca-6b7f-45bd-ba49-36fe2259217e"), new Guid("6a43676b-40ac-496b-9081-9625a78dade6"), "Warsaw" },
                    { new Guid("b94ee992-b268-4d5f-a4cc-38d7023410f7"), new Guid("a1ff6be2-7ba6-41ea-8fff-a49a4e5ea918"), "Rio de Janeiro" },
                    { new Guid("b952a029-2553-4694-86e4-b9198bda6e2a"), new Guid("e0d2a23b-301c-4b28-bcc6-c222055a2210"), "Vienna" },
                    { new Guid("c2ff4c50-d031-4e3f-ad18-8f9a2e1492d9"), new Guid("c7b85521-7752-4e18-a15d-382c1f6ef0e3"), "London" },
                    { new Guid("cdf75c24-76ba-4464-baf7-0c27bf4a1cf6"), new Guid("fd19e97f-6fe5-4c71-b07a-24ecb662e091"), "Dubai" },
                    { new Guid("d3da3474-6a39-4676-b6de-703fd4026ca6"), new Guid("9a4a487d-ef7b-42c6-8a51-45518c9808fd"), "Brussels" },
                    { new Guid("da2b7027-ef57-4091-9b7a-60397a02fcd8"), new Guid("24abc113-c34b-42c9-9a6d-a23e299681e3"), "Bangkok" },
                    { new Guid("deea4bb9-e00f-490c-92d5-c421b0ef321a"), new Guid("afb3148f-dd36-4cad-b92e-5bc83306f191"), "Prague" },
                    { new Guid("df11d3df-bd31-42e8-b0a6-5d0d53ba7084"), new Guid("a0d7e642-4556-456a-a645-df2b44722908"), "Lagos" },
                    { new Guid("e6eb7c6e-d924-43e5-8920-47ee43903503"), new Guid("a7245aba-9a18-4539-82a8-ed212377d8c3"), "Mexico City" },
                    { new Guid("e90ddf01-9be4-4d34-84c1-1ab6625f9e9f"), new Guid("5d84c5c2-7bd5-444f-a274-0e9c05de7d3e"), "Budapest" },
                    { new Guid("ec24bd38-8616-473c-9374-d37cd205e3de"), new Guid("e9a53832-e676-4e7c-b3ca-f3ea075ffb51"), "Zurich" },
                    { new Guid("f247acb5-dbb2-4712-9e54-c52e3d50c072"), new Guid("8a614192-9f1c-47cf-88ec-57bab38b7152"), "Nairobi" },
                    { new Guid("f4096292-ca86-4168-8d0d-bc73a42ca383"), new Guid("55e35db5-31f5-4184-b8ae-ec9b2f95283b"), "Paris" },
                    { new Guid("f5c8900b-29d3-4761-9c12-7ec7d025475f"), new Guid("69dc3b7c-672a-485f-99dd-1665973ec4b0"), "Tokyo" },
                    { new Guid("f734135e-8e6e-4a00-ab10-1b3491ecec28"), new Guid("0d898d61-c525-43d4-8cd5-436d657e23d6"), "Moscow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("038bd5ae-5f4e-474f-be06-efe33b006f2c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0856468f-ab04-4753-97a8-716d2bd6d05f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("0c17fd42-ba6c-4946-b84f-c9a57ee18fd5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("18339fac-03fd-4a2b-9be7-e7acdc1f2808"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("18fe8afd-85b2-4c03-9580-a229eb9ca9d1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("224bba57-dd9e-4dc6-9377-7a1909d08121"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("224d50f9-17a5-4e98-b755-0267352c346e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("243da2bc-cef5-40ad-9630-51bb0efb5396"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2b9248f0-e302-4c7d-9b5c-9ed7de0b0e50"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3050e751-9cc4-481b-8f49-0223f75d3047"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3921bf84-2687-4fc9-b327-ae58497fc1bf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3a3857b3-56ef-45ab-b527-be03c4f63463"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4366aee7-32b4-41d2-8560-5ac069229b40"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("47600cc1-f971-4d4a-af86-2cff072eee43"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4bbd88f5-a474-4bc9-bc16-9b6bde86338b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("56c02b16-fce1-427e-a46d-fea9eaccc0c3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("62750f6c-d369-412a-9b61-b2396790cdc4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("713a20a9-15c5-4474-88f4-fb8e13e32401"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7b5d464b-14cd-4c2a-9e9c-93517e9e756f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("83f2cc6a-bef2-4046-8250-8b9639fafb2b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8849cc57-5f7a-4bea-84eb-fd8fa54b4a12"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8fc14292-5e4d-42b0-8791-e55855023798"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("91b7106f-114e-437f-938a-954a770f042b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9bf5dac3-ebc1-4404-a0a7-ee9d0eb16681"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9eb6c78a-ab27-46f3-9412-bb6dbb07dc8d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b0ef0e10-aba9-45c0-9ef1-da085e7f0a45"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b3157d30-8cf3-400b-a6b8-e69617517cdf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b7f69cca-6b7f-45bd-ba49-36fe2259217e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b94ee992-b268-4d5f-a4cc-38d7023410f7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b952a029-2553-4694-86e4-b9198bda6e2a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c2ff4c50-d031-4e3f-ad18-8f9a2e1492d9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cdf75c24-76ba-4464-baf7-0c27bf4a1cf6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d3da3474-6a39-4676-b6de-703fd4026ca6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("da2b7027-ef57-4091-9b7a-60397a02fcd8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("deea4bb9-e00f-490c-92d5-c421b0ef321a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("df11d3df-bd31-42e8-b0a6-5d0d53ba7084"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e6eb7c6e-d924-43e5-8920-47ee43903503"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e90ddf01-9be4-4d34-84c1-1ab6625f9e9f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ec24bd38-8616-473c-9374-d37cd205e3de"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f247acb5-dbb2-4712-9e54-c52e3d50c072"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f4096292-ca86-4168-8d0d-bc73a42ca383"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f5c8900b-29d3-4761-9c12-7ec7d025475f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f734135e-8e6e-4a00-ab10-1b3491ecec28"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0d61592e-651d-46d1-9296-908d08293212"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0d898d61-c525-43d4-8cd5-436d657e23d6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("24abc113-c34b-42c9-9a6d-a23e299681e3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4692cd79-1790-482a-9063-c7ba170f50b6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4732345b-8f5f-44f1-a5bd-64e2fbdffd83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4cad111c-9b24-4660-a87e-8cb369e37692"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("51cc5b23-f4a7-4fdc-8773-18455a391bb1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("55e35db5-31f5-4184-b8ae-ec9b2f95283b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d84c5c2-7bd5-444f-a274-0e9c05de7d3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("61b345e2-9cf6-4f86-b4ed-c9b3c2a650df"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69717bd8-d87f-4b73-a0cd-066e5f3736cf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69dc3b7c-672a-485f-99dd-1665973ec4b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a43676b-40ac-496b-9081-9625a78dade6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e8b12b3-3cdc-489f-b276-7dc5605f169f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8636eef2-c829-4219-8fa2-5cf95e82f432"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("899ab8ff-d3a5-4967-ba6c-afd33b02d139"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8a614192-9f1c-47cf-88ec-57bab38b7152"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8bcd6da6-779c-47f5-b962-295d4526a180"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8ebda805-936f-4155-b585-a3460c9ddbe9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9a4a487d-ef7b-42c6-8a51-45518c9808fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f14667f-f967-46db-adc6-53b23ccf13b9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f516054-e2d4-4274-8dcf-4e9bd747c098"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a0d7e642-4556-456a-a645-df2b44722908"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a1ff6be2-7ba6-41ea-8fff-a49a4e5ea918"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a487b860-868e-4375-ac13-0331b0625717"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a538f002-7836-4fff-ab81-4571c9082adf"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a7245aba-9a18-4539-82a8-ed212377d8c3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("afb3148f-dd36-4cad-b92e-5bc83306f191"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bdca7b68-6b3b-468c-a512-809e19b5157b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c517c32c-554a-47c4-a70d-e36aa98c1c9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c7b85521-7752-4e18-a15d-382c1f6ef0e3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d8909638-9869-4772-b4f7-cb6022dee271"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e0d2a23b-301c-4b28-bcc6-c222055a2210"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e4df2293-737e-415a-ae20-d5b53e6589ce"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e5c66940-6e2b-4dd5-9a41-180f9bede4d4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9a53832-e676-4e7c-b3ca-f3ea075ffb51"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e9c734e6-6695-4f90-8898-a4471c0e4470"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ecd62d25-939c-483c-b234-942f26b3770c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f577d21c-b996-4aca-9bf4-df146bf54b7d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fd19e97f-6fe5-4c71-b07a-24ecb662e091"));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("001d0400-8069-4831-bd8a-e7960c77ca00"), "Russia" },
                    { new Guid("04f751fd-5041-40d4-a460-8644cff8d689"), "Poland" },
                    { new Guid("06ae197e-f7ec-4c4e-9b33-7423bc09d158"), "India" },
                    { new Guid("0b2c3386-02e3-4147-a756-485ffb6a4b35"), "Greece" },
                    { new Guid("246a520b-beda-4eec-9305-e9504761a0ad"), "South Korea" },
                    { new Guid("2d153fbd-86b9-4cbd-a85a-edef793fa065"), "Thailand" },
                    { new Guid("310ae403-e2d9-425b-ae37-11f9e6eba134"), "Italy" },
                    { new Guid("353316dd-f171-4149-951f-272a234bf910"), "South Africa" },
                    { new Guid("39a1c684-b99e-4fc5-835b-4cfa4e7cb86a"), "Egypt" },
                    { new Guid("3fe69907-2c99-4cb3-b5e2-919998a72dcf"), "New Zealand" },
                    { new Guid("439e4dca-082a-48ac-a600-e4bb29baaf83"), "UAE" },
                    { new Guid("4a158e35-abd5-4cd6-8255-ee3920bb542b"), "Singapore" },
                    { new Guid("4c6f861a-256b-40a3-a39b-030bfaebf0e8"), "Sweden" },
                    { new Guid("55ac250e-9ff3-4dd1-8450-b3640517d08d"), "Spain" },
                    { new Guid("5bf24e24-1dc0-480c-ae29-345d828a1ca4"), "Ireland" },
                    { new Guid("5fe2e7b2-2a1f-432a-8389-a4649ac221a5"), "Belgium" },
                    { new Guid("60d49e4e-d733-4dbb-a4e9-ed89ae388fd3"), "Argentina" },
                    { new Guid("6d863dff-235e-4b1c-8310-be6d9564c3c5"), "Vietnam" },
                    { new Guid("6e193476-c988-41a2-8a75-c5b6801d0caf"), "Hungary" },
                    { new Guid("73229010-6971-4016-82c0-056de0a0ee5a"), "Turkey" },
                    { new Guid("81c593af-2a7f-4589-8862-e0caaadb1c21"), "Netherlands" },
                    { new Guid("88547e50-5d34-4ae3-8384-6b671bf338ff"), "Brazil" },
                    { new Guid("8e33f77e-ca76-40fb-b386-c10aaccfa4d3"), "Norway" },
                    { new Guid("95539198-93cd-4555-a3b9-65c28486cc5f"), "Finland" },
                    { new Guid("a8f8631f-1671-4c1c-a9d6-6d919969e471"), "Nigeria" },
                    { new Guid("ac48a9dd-df13-49a3-87fa-012c27900b62"), "Austria" },
                    { new Guid("ad494b8c-1712-4dae-856e-b298c5594c0e"), "Czech Republic" },
                    { new Guid("aeb2da0d-5b65-47f3-83a0-12f6764db54f"), "China" },
                    { new Guid("c04042c6-c471-4d2c-9617-2916a3c66bdc"), "Kenya" },
                    { new Guid("c7ead1d2-a1f0-4f1c-a6d4-561ecffdab3e"), "Australia" },
                    { new Guid("cca165f6-8567-491a-9a04-58a9fd715c10"), "Mexico" },
                    { new Guid("cdd4d44f-8a6f-4136-8d3c-c03905d14f46"), "Switzerland" },
                    { new Guid("ce95ee7c-d4ee-4d10-b520-b397180335c4"), "USA" },
                    { new Guid("d9bb4c52-7c1d-447b-8b2c-93d454e76491"), "Denmark" },
                    { new Guid("e1bfb08f-5636-44ec-a4db-bcc398d18f46"), "France" },
                    { new Guid("e4537558-1c23-40e0-a559-df1074d26b45"), "UK" },
                    { new Guid("e9298563-8669-4661-900a-348a366e48db"), "Portugal" },
                    { new Guid("ecba7d9e-9b4f-4610-8096-87f6eb663110"), "Japan" },
                    { new Guid("f74c5676-6f40-4447-9135-9fc19a7152bb"), "Germany" },
                    { new Guid("f801aba6-6ef2-483c-b987-d29bfa0a22b2"), "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("068676fd-eb30-4360-9228-671e5f3af640"), new Guid("d9bb4c52-7c1d-447b-8b2c-93d454e76491"), "Copenhagen" },
                    { new Guid("0b5e7297-0c91-462e-97ba-c979312b1c34"), new Guid("0b2c3386-02e3-4147-a756-485ffb6a4b35"), "Athens" },
                    { new Guid("0ba6f3e8-0407-4dea-b92b-fd782a688a79"), new Guid("001d0400-8069-4831-bd8a-e7960c77ca00"), "Moscow" },
                    { new Guid("0ceb5e2e-e328-42e6-8733-0febc8a9a869"), new Guid("310ae403-e2d9-425b-ae37-11f9e6eba134"), "Rome" },
                    { new Guid("2257b18d-d7f0-451a-992d-7c821a3eb8c8"), new Guid("e9298563-8669-4661-900a-348a366e48db"), "Lisbon" },
                    { new Guid("2385cbec-8697-4964-9b8a-b52f117be4d2"), new Guid("ce95ee7c-d4ee-4d10-b520-b397180335c4"), "Chicago" },
                    { new Guid("23db35bb-9251-4202-b06e-5420672b74ad"), new Guid("f74c5676-6f40-4447-9135-9fc19a7152bb"), "Berlin" },
                    { new Guid("38215fbc-6ca2-4e10-85e1-d5be6c9af2fb"), new Guid("ecba7d9e-9b4f-4610-8096-87f6eb663110"), "Tokyo" },
                    { new Guid("3e044031-f4ff-4329-92be-87111328bf5b"), new Guid("4a158e35-abd5-4cd6-8255-ee3920bb542b"), "Singapore" },
                    { new Guid("467b1f83-a872-415c-9ecd-2e6d76dbfea5"), new Guid("cca165f6-8567-491a-9a04-58a9fd715c10"), "Mexico City" },
                    { new Guid("46c42b20-da6a-46f8-86f2-c6e780b59b74"), new Guid("95539198-93cd-4555-a3b9-65c28486cc5f"), "Helsinki" },
                    { new Guid("56b03cfb-48bc-44bc-b3d3-815cc5b964db"), new Guid("aeb2da0d-5b65-47f3-83a0-12f6764db54f"), "Beijing" },
                    { new Guid("5d957a27-5916-4094-9b79-dde9b259e68e"), new Guid("4c6f861a-256b-40a3-a39b-030bfaebf0e8"), "Stockholm" },
                    { new Guid("678c7c05-d356-466f-9417-02aaa072e65b"), new Guid("6e193476-c988-41a2-8a75-c5b6801d0caf"), "Budapest" },
                    { new Guid("6d2e2a48-45e2-4a9e-b0e7-e62918a22faf"), new Guid("88547e50-5d34-4ae3-8384-6b671bf338ff"), "Rio de Janeiro" },
                    { new Guid("71d48394-f90b-4c9b-8d69-50a0ba3fbd2e"), new Guid("6d863dff-235e-4b1c-8310-be6d9564c3c5"), "Hanoi" },
                    { new Guid("77f5fe75-2f60-4a76-90e2-d445b2529344"), new Guid("ce95ee7c-d4ee-4d10-b520-b397180335c4"), "Los Angeles" },
                    { new Guid("85513312-3315-4536-804f-7ed3f332152d"), new Guid("cdd4d44f-8a6f-4136-8d3c-c03905d14f46"), "Zurich" },
                    { new Guid("88ce900c-432b-4f46-8786-eea2d77b10ba"), new Guid("81c593af-2a7f-4589-8862-e0caaadb1c21"), "Amsterdam" },
                    { new Guid("8b07b70a-b51c-405c-9a5e-d2b00de0fbde"), new Guid("55ac250e-9ff3-4dd1-8450-b3640517d08d"), "Barcelona" },
                    { new Guid("8fde6d88-6914-4b67-b062-aaf79b8aa22f"), new Guid("ac48a9dd-df13-49a3-87fa-012c27900b62"), "Vienna" },
                    { new Guid("90fbf35a-de7c-4d55-8f87-cadbdec2af05"), new Guid("04f751fd-5041-40d4-a460-8644cff8d689"), "Warsaw" },
                    { new Guid("9846bc0f-e3b1-4778-9aa5-33352f9e4215"), new Guid("60d49e4e-d733-4dbb-a4e9-ed89ae388fd3"), "Buenos Aires" },
                    { new Guid("9c0c80b9-02bf-4fe5-b713-9c50525d64d6"), new Guid("5bf24e24-1dc0-480c-ae29-345d828a1ca4"), "Dublin" },
                    { new Guid("a123633b-a109-47dc-a4c0-0afa18e8be4d"), new Guid("a8f8631f-1671-4c1c-a9d6-6d919969e471"), "Lagos" },
                    { new Guid("a9705c60-c172-4820-b7e8-eb160fd21443"), new Guid("73229010-6971-4016-82c0-056de0a0ee5a"), "Istanbul" },
                    { new Guid("ab0a8e1f-e4d2-4f20-b776-681333d2e9ae"), new Guid("246a520b-beda-4eec-9305-e9504761a0ad"), "Seoul" },
                    { new Guid("ad8e4fb1-f933-4eef-b335-24f38697101a"), new Guid("439e4dca-082a-48ac-a600-e4bb29baaf83"), "Dubai" },
                    { new Guid("b54d6e16-d2c6-4e0a-abc8-5dabc7e6f2f5"), new Guid("3fe69907-2c99-4cb3-b5e2-919998a72dcf"), "Auckland" },
                    { new Guid("b583d9d6-8274-49de-9f56-1222caed1fcc"), new Guid("2d153fbd-86b9-4cbd-a85a-edef793fa065"), "Bangkok" },
                    { new Guid("bb0f731f-d58e-4bcc-880b-2477a4f37b73"), new Guid("c04042c6-c471-4d2c-9617-2916a3c66bdc"), "Nairobi" },
                    { new Guid("bd450c30-ad38-48d9-9654-a947f90dc4a5"), new Guid("8e33f77e-ca76-40fb-b386-c10aaccfa4d3"), "Oslo" },
                    { new Guid("bd818fda-668d-47cf-a7c4-7a594f4deb22"), new Guid("aeb2da0d-5b65-47f3-83a0-12f6764db54f"), "Hong Kong" },
                    { new Guid("c85de4ae-6786-4e84-bc4e-40717952bd01"), new Guid("ce95ee7c-d4ee-4d10-b520-b397180335c4"), "New York" },
                    { new Guid("c9432e20-beb8-4c61-b5c5-0dc1a9d4f406"), new Guid("e1bfb08f-5636-44ec-a4db-bcc398d18f46"), "Paris" },
                    { new Guid("d91146e7-06a7-4cf6-a6e0-ed52acf19e57"), new Guid("f801aba6-6ef2-483c-b987-d29bfa0a22b2"), "Toronto" },
                    { new Guid("e1ed0dce-24ad-4cc3-bc40-82e0536f9c4b"), new Guid("353316dd-f171-4149-951f-272a234bf910"), "Cape Town" },
                    { new Guid("e73c37f0-c4ab-4613-9ca5-26eae3400033"), new Guid("e4537558-1c23-40e0-a559-df1074d26b45"), "London" },
                    { new Guid("e805b847-df83-42db-841d-58553b5e5376"), new Guid("ad494b8c-1712-4dae-856e-b298c5594c0e"), "Prague" },
                    { new Guid("eb220fbb-5364-40ef-babd-557fc8bfc3f8"), new Guid("c7ead1d2-a1f0-4f1c-a6d4-561ecffdab3e"), "Sydney" },
                    { new Guid("f2009493-5511-4163-b8e1-e718236b1bcc"), new Guid("06ae197e-f7ec-4c4e-9b33-7423bc09d158"), "Mumbai" },
                    { new Guid("fa9fd9a2-21b5-448c-abf8-3d00df2b8b74"), new Guid("39a1c684-b99e-4fc5-835b-4cfa4e7cb86a"), "Cairo" },
                    { new Guid("fd110166-ec59-4b39-a852-5cbace1b2444"), new Guid("5fe2e7b2-2a1f-432a-8389-a4649ac221a5"), "Brussels" }
                });
        }
    }
}
