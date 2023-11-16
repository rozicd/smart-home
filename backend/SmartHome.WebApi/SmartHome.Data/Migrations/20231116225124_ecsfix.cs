using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartHome.Data.Migrations
{
    /// <inheritdoc />
    public partial class ecsfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("08e0cfb3-2bf4-483f-9b98-c9ced3f330eb"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1a738e20-acf3-4fd4-b403-cfa5f5bdc99a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1c966435-41c0-493d-9a03-473b73ae65e3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2bb365f3-08ac-4132-ad24-79d3e9fda262"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3a8b727f-d280-4858-b183-c5626c9ede64"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3f99161e-9942-4bd6-ade4-26fd3e3d9bad"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4d787b6d-e475-45a3-bb83-bb7c301240dc"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4e81c4a9-5b79-497d-a518-85c652c48fc4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4ec13ea6-7778-4db2-be1b-d2d5a485ec26"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5a4d5777-6a05-4a87-b533-c263ce5f0c66"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5f4f38f0-e8e8-4477-82d4-b24e40d707a8"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6315d2af-7b70-4aa4-aa47-1a1d869eb791"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("67f553fa-5bc9-4a8b-ab41-e6f5cc17c4c1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6cb812cb-bc9c-40e1-9169-559bce14e699"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("735bb26b-b86a-4894-b9bc-941f13cbbc93"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7a92e7bf-c265-4a32-9ff0-54e5960d7d10"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7f8b6271-4a05-44e7-a138-a8ef8eaab14d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8dd78fac-c7dd-44ee-8127-e8c1ea6228aa"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a1e5cf9f-b565-4b61-b857-84e02d793ea9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a7d55187-d5a8-469c-b0df-61f4f002ef4b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a989dc51-fa8c-4ecd-9009-80d6776f2caf"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b0839cad-30df-4c7d-b6a0-d66d2d723c08"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b4c7d391-ee85-4c1e-aa18-22c91b6c7a10"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b5f77004-36ef-4d5d-9382-e5e5379c6b85"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b72f3856-c14f-4236-871a-9b6fd65dfb7d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ba89b05e-d6ce-491e-b7c9-de93fc966026"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bb9266fd-d80e-49bb-97d0-2dae374e2d26"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("bd25997b-cab7-4672-b327-dd12f47e389e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c408f493-4f48-4da3-9333-30c7ca58a2ff"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cdd77fa2-c2e7-4fbd-a305-019d72230f0c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ce5f6a19-ce4c-474d-b37d-8d5943908c4d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d16ec04b-693d-4f36-814e-612e66c33c88"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d1bffbdc-2859-44e7-be6e-e1427848134d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d482ce69-2334-4a63-82f1-ca6863e053b0"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d7d0760f-733e-456c-be28-381010760b19"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dadbdf0b-f358-4759-bc03-f99238f4752e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e02a2bfe-6a10-4c7c-8594-60f2040ef84b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e4d10339-3680-4f89-b468-ff67723de51f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f0ca1380-b1e3-4c03-b297-2dd6afc5cd9c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f3e40d2a-3abe-4939-9ffc-a10ec2caf126"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f51a0d31-8043-4fdf-82bc-27c661586b5e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fa1abf86-1120-4e49-be01-c296df561376"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fdd02f60-83ba-4ed3-bde0-62b8ce538920"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0f9d0c04-93d6-4070-9d58-63b42896ffb4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1efbbe97-c438-40d2-84b2-426330b98f3c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2db178c1-c424-4d8c-861d-09911bbba51e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("308f66fa-f4be-429b-a0ce-8a152b4e5927"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a77c84f-8875-4132-9fae-c07f03432435"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4029f4aa-a9dc-4463-af4f-0cb685d8c420"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("46357de9-5c2a-48fb-885e-9dc1e599006e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4ce32c13-50ac-4baf-be28-2fbb5df2f289"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d61d77f-f475-470a-90d3-f7c92af95e00"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("547732b0-5335-4742-9181-9b15817fe56d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("589128f9-3259-4cfb-96e9-8f45996fa396"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5d93e087-1aa0-40ad-8e6e-68133ddd835e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("62e0dd7c-ff47-4f62-a63d-075dc6b49320"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6a5cf285-3793-4cce-a155-3cfdef88e4ff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7c0b3044-2382-449f-a603-b80e5a5fc74f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8041ff0a-7bdd-4340-a349-7b0417210e7c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("833aecc4-85e5-4859-85ee-cc2e840bb303"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("87ecaa49-f347-46e4-a1c3-02ed7663bb03"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("90da958f-8edc-4ebe-874d-059b9f4f6a42"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9792f174-3ab1-4c4d-a29d-ec2e4fbdc25b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("98218ff2-df6b-4653-be16-20f2070ee3d8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("997a44d8-0934-48a6-9e95-1d9ae837a087"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a4a95dc3-b9ed-4df4-903b-0bf45c142417"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aa13becc-1f9f-46f3-9d71-7c6d5a68cf91"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aabcafe9-7833-413d-977b-0c0924783148"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b03f6cac-67cc-4b53-a1a2-4663460e3809"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b3a3f6dd-34b6-48b5-b463-d89eee98043d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b7638789-3bea-4e28-b8bc-da6015bfa2b3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bfb2d56c-f6c5-44c2-b788-a7abd4beb1a9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c4ee01ea-7396-41bb-85fb-157f4139d71a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ca23f9e6-2c1a-44ea-8207-fa36c9880365"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cb187c9a-7ab2-4862-b209-19cbb2f0c390"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d7704069-7b5c-4330-904d-a7b96d0de365"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("da8338d1-4f2d-41d4-8824-bf8a6f5f47d7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7af8513-68f3-404d-b1c9-d703ce6c3cab"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e94a3deb-7432-4500-91a0-856d70438f18"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f8648b59-176b-4750-9d1c-f36bc2fe88ec"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ff57aa9a-8b92-498f-bc32-07bf52cf2965"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01ea3d25-f233-4a90-8a5a-5634fb45f24c"), "Sweden" },
                    { new Guid("0cee95e9-9417-4066-9eb9-4b49622e2c13"), "USA" },
                    { new Guid("10ddd8a1-870b-40d2-95bc-1065aa570f0c"), "Belgium" },
                    { new Guid("19764850-4919-4da5-8ab1-86cda55434d1"), "South Korea" },
                    { new Guid("1e3296eb-0cee-4702-bcee-b5ca88daa9b3"), "Spain" },
                    { new Guid("21ef19c9-62ae-454d-8fdb-3659d1b633a4"), "Russia" },
                    { new Guid("2589e0cc-e0ef-48cb-8cef-4a475334e43e"), "Australia" },
                    { new Guid("270feb8f-17c8-449f-8b68-8ac43ca47a01"), "UAE" },
                    { new Guid("36fda027-f8a9-4a32-9558-dbb315cc07ba"), "Hungary" },
                    { new Guid("38a8a5ab-c6ff-452b-bbda-c1a8639106ba"), "Vietnam" },
                    { new Guid("3d72b757-9c0c-4125-8ce5-b72a8bf3a01c"), "Singapore" },
                    { new Guid("41c7c074-278a-48f1-ab3e-962c7b205e83"), "China" },
                    { new Guid("42a5d641-0bc8-498e-8112-033f58355556"), "Greece" },
                    { new Guid("42e4e8ed-4d2f-44f4-9e5a-ce9d214686d9"), "Czech Republic" },
                    { new Guid("4cdf9df8-5013-4906-8f15-a9a02bed3fae"), "Italy" },
                    { new Guid("60c031b0-3312-4cb6-926a-01492ab2fb9c"), "South Africa" },
                    { new Guid("68a2bd45-268a-46b8-8926-2c32425ae1de"), "Netherlands" },
                    { new Guid("69f1ec39-8508-4942-bf13-2d86267158c7"), "Turkey" },
                    { new Guid("712bf4ad-6672-4463-99b8-27209e163699"), "Canada" },
                    { new Guid("763b266f-a732-4aad-b677-15ad25c0884b"), "Austria" },
                    { new Guid("873dc26d-867f-4ad6-b996-6f328844f8b5"), "Finland" },
                    { new Guid("9c5a0a6b-ca49-4403-a3b9-7029a6ce6b57"), "Denmark" },
                    { new Guid("a4ef9350-0dca-4679-822e-afda10c52270"), "Switzerland" },
                    { new Guid("a7e5f493-4f53-4a7b-9c2e-ba66cfbc2e01"), "Mexico" },
                    { new Guid("ab601e65-8cfe-4f02-ab93-bfac1565749e"), "Poland" },
                    { new Guid("acf3b45f-8016-416a-a85d-76fab1e7e195"), "Portugal" },
                    { new Guid("aef33b82-4978-4b19-bcc9-76e197206d09"), "Egypt" },
                    { new Guid("b9943703-1ac0-4d15-97ea-29b369c78d90"), "Thailand" },
                    { new Guid("bbde1cc2-c54c-46a5-8909-d9c5cf8c5a8f"), "India" },
                    { new Guid("bec4ca57-f1d2-45ae-b5b0-e373d7e4d95b"), "New Zealand" },
                    { new Guid("d21512a8-5216-47d4-b9c7-0fe2829d3607"), "Kenya" },
                    { new Guid("d83df9c0-bfa5-4877-b3ee-582659c1c3a0"), "France" },
                    { new Guid("db8015ea-ab8b-47f0-b50a-e51292f8cfff"), "Brazil" },
                    { new Guid("dd4bc7f7-644e-4d81-b94a-ac6c1531f7ee"), "Nigeria" },
                    { new Guid("dfa27aa3-14b8-4f77-97e2-bc02193f5b55"), "UK" },
                    { new Guid("e5f585a7-5098-4105-bfcd-3402b7c18ef7"), "Japan" },
                    { new Guid("ed45cb2f-5364-4a7f-99e9-d8568083fc96"), "Argentina" },
                    { new Guid("f1f89772-ea0f-4138-8be2-0406918275f5"), "Germany" },
                    { new Guid("f5ba25d1-8180-4c1c-8c4f-ee9da8ad3878"), "Norway" },
                    { new Guid("fdec6670-84b2-444c-bc93-b3670bdc4630"), "Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("00509613-f1ec-4784-a0f7-726b319a2e05"), new Guid("fdec6670-84b2-444c-bc93-b3670bdc4630"), "Dublin" },
                    { new Guid("01a0948e-5811-439b-8cb3-b65cd27eb90f"), new Guid("ed45cb2f-5364-4a7f-99e9-d8568083fc96"), "Buenos Aires" },
                    { new Guid("12a3e5ae-80af-4627-8335-73b4ea2e127c"), new Guid("10ddd8a1-870b-40d2-95bc-1065aa570f0c"), "Brussels" },
                    { new Guid("157554a6-5d56-43bb-b613-227215664005"), new Guid("db8015ea-ab8b-47f0-b50a-e51292f8cfff"), "Rio de Janeiro" },
                    { new Guid("2360a5e8-1a1c-417a-9910-96347077c942"), new Guid("0cee95e9-9417-4066-9eb9-4b49622e2c13"), "Los Angeles" },
                    { new Guid("2a7b72f8-092b-4693-a18b-bff7889a47a5"), new Guid("36fda027-f8a9-4a32-9558-dbb315cc07ba"), "Budapest" },
                    { new Guid("365c57cc-0b4f-474b-ad39-235472d41053"), new Guid("4cdf9df8-5013-4906-8f15-a9a02bed3fae"), "Rome" },
                    { new Guid("385f3f17-f098-4047-81f0-adfba98413e3"), new Guid("42e4e8ed-4d2f-44f4-9e5a-ce9d214686d9"), "Prague" },
                    { new Guid("389c0934-16c9-4ba3-8f8e-3ac6a174dbc2"), new Guid("acf3b45f-8016-416a-a85d-76fab1e7e195"), "Lisbon" },
                    { new Guid("3b483a52-a149-44d6-9d87-1f82afc7df9b"), new Guid("d83df9c0-bfa5-4877-b3ee-582659c1c3a0"), "Paris" },
                    { new Guid("3dbc6e31-7e18-47ed-b648-818f3fe37610"), new Guid("9c5a0a6b-ca49-4403-a3b9-7029a6ce6b57"), "Copenhagen" },
                    { new Guid("4167a382-133d-4146-a99b-fb7eb1212fd4"), new Guid("41c7c074-278a-48f1-ab3e-962c7b205e83"), "Beijing" },
                    { new Guid("5081a03d-ceaa-4a0e-b098-ac8002362596"), new Guid("d21512a8-5216-47d4-b9c7-0fe2829d3607"), "Nairobi" },
                    { new Guid("574fe3aa-d43c-4447-865c-b1df3dca408a"), new Guid("270feb8f-17c8-449f-8b68-8ac43ca47a01"), "Dubai" },
                    { new Guid("5bd93349-c95e-4168-be77-c44fddb35877"), new Guid("e5f585a7-5098-4105-bfcd-3402b7c18ef7"), "Tokyo" },
                    { new Guid("5c42ddc4-ab5f-4ee9-b5a7-31002010501b"), new Guid("69f1ec39-8508-4942-bf13-2d86267158c7"), "Istanbul" },
                    { new Guid("5fc84993-31b3-4024-878c-d0a2f24a75e5"), new Guid("60c031b0-3312-4cb6-926a-01492ab2fb9c"), "Cape Town" },
                    { new Guid("6ca14b6b-8d5e-46dd-bc98-274fed6af9ca"), new Guid("0cee95e9-9417-4066-9eb9-4b49622e2c13"), "Chicago" },
                    { new Guid("6e3c43db-44ed-492c-8023-46f3428c20b5"), new Guid("01ea3d25-f233-4a90-8a5a-5634fb45f24c"), "Stockholm" },
                    { new Guid("6f5a9347-5970-4e1d-a6a6-5119c699ccd3"), new Guid("f5ba25d1-8180-4c1c-8c4f-ee9da8ad3878"), "Oslo" },
                    { new Guid("70d76b32-386c-4b6c-a37c-fb25cff74fb0"), new Guid("dfa27aa3-14b8-4f77-97e2-bc02193f5b55"), "London" },
                    { new Guid("725f1fdb-174c-462f-9374-d3fd0ca2e55a"), new Guid("42a5d641-0bc8-498e-8112-033f58355556"), "Athens" },
                    { new Guid("72e89d72-e285-4ca7-a9fe-e36e951fec9f"), new Guid("a4ef9350-0dca-4679-822e-afda10c52270"), "Zurich" },
                    { new Guid("7ee05b12-c8a5-4afd-8cba-d111643d3022"), new Guid("41c7c074-278a-48f1-ab3e-962c7b205e83"), "Hong Kong" },
                    { new Guid("823e504f-11e0-4132-b6d8-1704b3dd65a5"), new Guid("f1f89772-ea0f-4138-8be2-0406918275f5"), "Berlin" },
                    { new Guid("88b9ffbf-05c2-45a7-b9b3-59548bbb1929"), new Guid("68a2bd45-268a-46b8-8926-2c32425ae1de"), "Amsterdam" },
                    { new Guid("8a83738c-5613-4d84-a6c3-d8f29fb69c1e"), new Guid("0cee95e9-9417-4066-9eb9-4b49622e2c13"), "New York" },
                    { new Guid("8b79c386-1842-4181-ba48-4483df306355"), new Guid("bbde1cc2-c54c-46a5-8909-d9c5cf8c5a8f"), "Mumbai" },
                    { new Guid("905784fe-9620-4f72-9d4c-8753864ca94d"), new Guid("38a8a5ab-c6ff-452b-bbda-c1a8639106ba"), "Hanoi" },
                    { new Guid("91be4929-29d8-4fa0-8084-b58f74418063"), new Guid("763b266f-a732-4aad-b677-15ad25c0884b"), "Vienna" },
                    { new Guid("92489f30-9e40-4054-85d0-3b3898fa1446"), new Guid("ab601e65-8cfe-4f02-ab93-bfac1565749e"), "Warsaw" },
                    { new Guid("96470867-546f-4462-b743-3df0b2cf7419"), new Guid("a7e5f493-4f53-4a7b-9c2e-ba66cfbc2e01"), "Mexico City" },
                    { new Guid("9ef5bb89-fa4a-4a4a-8609-4b1c957203fe"), new Guid("dd4bc7f7-644e-4d81-b94a-ac6c1531f7ee"), "Lagos" },
                    { new Guid("a44955dc-5371-41cd-ad5e-5b2c4d8cd7c5"), new Guid("b9943703-1ac0-4d15-97ea-29b369c78d90"), "Bangkok" },
                    { new Guid("c7061e00-0fff-4415-8fc8-0408c5320a11"), new Guid("3d72b757-9c0c-4125-8ce5-b72a8bf3a01c"), "Singapore" },
                    { new Guid("cea59a13-4138-4a50-96d8-d2490e5acbf2"), new Guid("21ef19c9-62ae-454d-8fdb-3659d1b633a4"), "Moscow" },
                    { new Guid("d53b10b6-f8ec-4f40-8462-b50b2a826491"), new Guid("19764850-4919-4da5-8ab1-86cda55434d1"), "Seoul" },
                    { new Guid("dd5dd9c8-95b9-4236-9404-a90552281c37"), new Guid("2589e0cc-e0ef-48cb-8cef-4a475334e43e"), "Sydney" },
                    { new Guid("debebac5-2f5a-475c-a1bd-4e3cfb0d39a4"), new Guid("873dc26d-867f-4ad6-b996-6f328844f8b5"), "Helsinki" },
                    { new Guid("e508a17a-66ef-44c7-bdb8-7c150a83ac0c"), new Guid("1e3296eb-0cee-4702-bcee-b5ca88daa9b3"), "Barcelona" },
                    { new Guid("f022b6ed-4908-40a7-9e7f-95f5516e930a"), new Guid("aef33b82-4978-4b19-bcc9-76e197206d09"), "Cairo" },
                    { new Guid("f100a6f6-d7c2-4e12-9693-43fbc13f9ad1"), new Guid("bec4ca57-f1d2-45ae-b5b0-e373d7e4d95b"), "Auckland" },
                    { new Guid("fc64e09d-2415-4cad-9a97-a3a9bc50b654"), new Guid("712bf4ad-6672-4463-99b8-27209e163699"), "Toronto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("00509613-f1ec-4784-a0f7-726b319a2e05"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("01a0948e-5811-439b-8cb3-b65cd27eb90f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("12a3e5ae-80af-4627-8335-73b4ea2e127c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("157554a6-5d56-43bb-b613-227215664005"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2360a5e8-1a1c-417a-9910-96347077c942"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2a7b72f8-092b-4693-a18b-bff7889a47a5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("365c57cc-0b4f-474b-ad39-235472d41053"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("385f3f17-f098-4047-81f0-adfba98413e3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("389c0934-16c9-4ba3-8f8e-3ac6a174dbc2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3b483a52-a149-44d6-9d87-1f82afc7df9b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3dbc6e31-7e18-47ed-b648-818f3fe37610"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4167a382-133d-4146-a99b-fb7eb1212fd4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5081a03d-ceaa-4a0e-b098-ac8002362596"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("574fe3aa-d43c-4447-865c-b1df3dca408a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5bd93349-c95e-4168-be77-c44fddb35877"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5c42ddc4-ab5f-4ee9-b5a7-31002010501b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5fc84993-31b3-4024-878c-d0a2f24a75e5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6ca14b6b-8d5e-46dd-bc98-274fed6af9ca"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6e3c43db-44ed-492c-8023-46f3428c20b5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6f5a9347-5970-4e1d-a6a6-5119c699ccd3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("70d76b32-386c-4b6c-a37c-fb25cff74fb0"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("725f1fdb-174c-462f-9374-d3fd0ca2e55a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("72e89d72-e285-4ca7-a9fe-e36e951fec9f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("7ee05b12-c8a5-4afd-8cba-d111643d3022"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("823e504f-11e0-4132-b6d8-1704b3dd65a5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("88b9ffbf-05c2-45a7-b9b3-59548bbb1929"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a83738c-5613-4d84-a6c3-d8f29fb69c1e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8b79c386-1842-4181-ba48-4483df306355"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("905784fe-9620-4f72-9d4c-8753864ca94d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("91be4929-29d8-4fa0-8084-b58f74418063"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("92489f30-9e40-4054-85d0-3b3898fa1446"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("96470867-546f-4462-b743-3df0b2cf7419"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9ef5bb89-fa4a-4a4a-8609-4b1c957203fe"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("a44955dc-5371-41cd-ad5e-5b2c4d8cd7c5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c7061e00-0fff-4415-8fc8-0408c5320a11"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cea59a13-4138-4a50-96d8-d2490e5acbf2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d53b10b6-f8ec-4f40-8462-b50b2a826491"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("dd5dd9c8-95b9-4236-9404-a90552281c37"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("debebac5-2f5a-475c-a1bd-4e3cfb0d39a4"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e508a17a-66ef-44c7-bdb8-7c150a83ac0c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f022b6ed-4908-40a7-9e7f-95f5516e930a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f100a6f6-d7c2-4e12-9693-43fbc13f9ad1"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fc64e09d-2415-4cad-9a97-a3a9bc50b654"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("01ea3d25-f233-4a90-8a5a-5634fb45f24c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0cee95e9-9417-4066-9eb9-4b49622e2c13"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("10ddd8a1-870b-40d2-95bc-1065aa570f0c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("19764850-4919-4da5-8ab1-86cda55434d1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1e3296eb-0cee-4702-bcee-b5ca88daa9b3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("21ef19c9-62ae-454d-8fdb-3659d1b633a4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("2589e0cc-e0ef-48cb-8cef-4a475334e43e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("270feb8f-17c8-449f-8b68-8ac43ca47a01"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("36fda027-f8a9-4a32-9558-dbb315cc07ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("38a8a5ab-c6ff-452b-bbda-c1a8639106ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3d72b757-9c0c-4125-8ce5-b72a8bf3a01c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("41c7c074-278a-48f1-ab3e-962c7b205e83"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42a5d641-0bc8-498e-8112-033f58355556"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("42e4e8ed-4d2f-44f4-9e5a-ce9d214686d9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4cdf9df8-5013-4906-8f15-a9a02bed3fae"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60c031b0-3312-4cb6-926a-01492ab2fb9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("68a2bd45-268a-46b8-8926-2c32425ae1de"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("69f1ec39-8508-4942-bf13-2d86267158c7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("712bf4ad-6672-4463-99b8-27209e163699"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("763b266f-a732-4aad-b677-15ad25c0884b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("873dc26d-867f-4ad6-b996-6f328844f8b5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9c5a0a6b-ca49-4403-a3b9-7029a6ce6b57"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a4ef9350-0dca-4679-822e-afda10c52270"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a7e5f493-4f53-4a7b-9c2e-ba66cfbc2e01"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ab601e65-8cfe-4f02-ab93-bfac1565749e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("acf3b45f-8016-416a-a85d-76fab1e7e195"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("aef33b82-4978-4b19-bcc9-76e197206d09"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b9943703-1ac0-4d15-97ea-29b369c78d90"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bbde1cc2-c54c-46a5-8909-d9c5cf8c5a8f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bec4ca57-f1d2-45ae-b5b0-e373d7e4d95b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d21512a8-5216-47d4-b9c7-0fe2829d3607"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d83df9c0-bfa5-4877-b3ee-582659c1c3a0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("db8015ea-ab8b-47f0-b50a-e51292f8cfff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dd4bc7f7-644e-4d81-b94a-ac6c1531f7ee"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dfa27aa3-14b8-4f77-97e2-bc02193f5b55"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e5f585a7-5098-4105-bfcd-3402b7c18ef7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ed45cb2f-5364-4a7f-99e9-d8568083fc96"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f1f89772-ea0f-4138-8be2-0406918275f5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f5ba25d1-8180-4c1c-8c4f-ee9da8ad3878"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fdec6670-84b2-444c-bc93-b3670bdc4630"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f9d0c04-93d6-4070-9d58-63b42896ffb4"), "Brazil" },
                    { new Guid("1efbbe97-c438-40d2-84b2-426330b98f3c"), "UAE" },
                    { new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"), "USA" },
                    { new Guid("2db178c1-c424-4d8c-861d-09911bbba51e"), "Finland" },
                    { new Guid("308f66fa-f4be-429b-a0ce-8a152b4e5927"), "Ireland" },
                    { new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"), "China" },
                    { new Guid("3a77c84f-8875-4132-9fae-c07f03432435"), "France" },
                    { new Guid("4029f4aa-a9dc-4463-af4f-0cb685d8c420"), "Russia" },
                    { new Guid("46357de9-5c2a-48fb-885e-9dc1e599006e"), "Netherlands" },
                    { new Guid("4ce32c13-50ac-4baf-be28-2fbb5df2f289"), "Turkey" },
                    { new Guid("4d61d77f-f475-470a-90d3-f7c92af95e00"), "India" },
                    { new Guid("547732b0-5335-4742-9181-9b15817fe56d"), "Czech Republic" },
                    { new Guid("589128f9-3259-4cfb-96e9-8f45996fa396"), "South Korea" },
                    { new Guid("5d93e087-1aa0-40ad-8e6e-68133ddd835e"), "Portugal" },
                    { new Guid("62e0dd7c-ff47-4f62-a63d-075dc6b49320"), "Sweden" },
                    { new Guid("6a5cf285-3793-4cce-a155-3cfdef88e4ff"), "UK" },
                    { new Guid("7c0b3044-2382-449f-a603-b80e5a5fc74f"), "Hungary" },
                    { new Guid("8041ff0a-7bdd-4340-a349-7b0417210e7c"), "Belgium" },
                    { new Guid("833aecc4-85e5-4859-85ee-cc2e840bb303"), "Norway" },
                    { new Guid("87ecaa49-f347-46e4-a1c3-02ed7663bb03"), "Mexico" },
                    { new Guid("90da958f-8edc-4ebe-874d-059b9f4f6a42"), "Kenya" },
                    { new Guid("9792f174-3ab1-4c4d-a29d-ec2e4fbdc25b"), "Singapore" },
                    { new Guid("98218ff2-df6b-4653-be16-20f2070ee3d8"), "Austria" },
                    { new Guid("997a44d8-0934-48a6-9e95-1d9ae837a087"), "Greece" },
                    { new Guid("a4a95dc3-b9ed-4df4-903b-0bf45c142417"), "Thailand" },
                    { new Guid("aa13becc-1f9f-46f3-9d71-7c6d5a68cf91"), "Australia" },
                    { new Guid("aabcafe9-7833-413d-977b-0c0924783148"), "Argentina" },
                    { new Guid("b03f6cac-67cc-4b53-a1a2-4663460e3809"), "Italy" },
                    { new Guid("b3a3f6dd-34b6-48b5-b463-d89eee98043d"), "Switzerland" },
                    { new Guid("b7638789-3bea-4e28-b8bc-da6015bfa2b3"), "Germany" },
                    { new Guid("bfb2d56c-f6c5-44c2-b788-a7abd4beb1a9"), "Canada" },
                    { new Guid("c4ee01ea-7396-41bb-85fb-157f4139d71a"), "South Africa" },
                    { new Guid("ca23f9e6-2c1a-44ea-8207-fa36c9880365"), "New Zealand" },
                    { new Guid("cb187c9a-7ab2-4862-b209-19cbb2f0c390"), "Japan" },
                    { new Guid("d7704069-7b5c-4330-904d-a7b96d0de365"), "Poland" },
                    { new Guid("da8338d1-4f2d-41d4-8824-bf8a6f5f47d7"), "Vietnam" },
                    { new Guid("e7af8513-68f3-404d-b1c9-d703ce6c3cab"), "Denmark" },
                    { new Guid("e94a3deb-7432-4500-91a0-856d70438f18"), "Nigeria" },
                    { new Guid("f8648b59-176b-4750-9d1c-f36bc2fe88ec"), "Spain" },
                    { new Guid("ff57aa9a-8b92-498f-bc32-07bf52cf2965"), "Egypt" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("08e0cfb3-2bf4-483f-9b98-c9ced3f330eb"), new Guid("997a44d8-0934-48a6-9e95-1d9ae837a087"), "Athens" },
                    { new Guid("1a738e20-acf3-4fd4-b403-cfa5f5bdc99a"), new Guid("bfb2d56c-f6c5-44c2-b788-a7abd4beb1a9"), "Toronto" },
                    { new Guid("1c966435-41c0-493d-9a03-473b73ae65e3"), new Guid("4ce32c13-50ac-4baf-be28-2fbb5df2f289"), "Istanbul" },
                    { new Guid("2bb365f3-08ac-4132-ad24-79d3e9fda262"), new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"), "Los Angeles" },
                    { new Guid("3a8b727f-d280-4858-b183-c5626c9ede64"), new Guid("308f66fa-f4be-429b-a0ce-8a152b4e5927"), "Dublin" },
                    { new Guid("3f99161e-9942-4bd6-ade4-26fd3e3d9bad"), new Guid("ca23f9e6-2c1a-44ea-8207-fa36c9880365"), "Auckland" },
                    { new Guid("4d787b6d-e475-45a3-bb83-bb7c301240dc"), new Guid("d7704069-7b5c-4330-904d-a7b96d0de365"), "Warsaw" },
                    { new Guid("4e81c4a9-5b79-497d-a518-85c652c48fc4"), new Guid("c4ee01ea-7396-41bb-85fb-157f4139d71a"), "Cape Town" },
                    { new Guid("4ec13ea6-7778-4db2-be1b-d2d5a485ec26"), new Guid("aa13becc-1f9f-46f3-9d71-7c6d5a68cf91"), "Sydney" },
                    { new Guid("5a4d5777-6a05-4a87-b533-c263ce5f0c66"), new Guid("589128f9-3259-4cfb-96e9-8f45996fa396"), "Seoul" },
                    { new Guid("5f4f38f0-e8e8-4477-82d4-b24e40d707a8"), new Guid("4d61d77f-f475-470a-90d3-f7c92af95e00"), "Mumbai" },
                    { new Guid("6315d2af-7b70-4aa4-aa47-1a1d869eb791"), new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"), "New York" },
                    { new Guid("67f553fa-5bc9-4a8b-ab41-e6f5cc17c4c1"), new Guid("5d93e087-1aa0-40ad-8e6e-68133ddd835e"), "Lisbon" },
                    { new Guid("6cb812cb-bc9c-40e1-9169-559bce14e699"), new Guid("98218ff2-df6b-4653-be16-20f2070ee3d8"), "Vienna" },
                    { new Guid("735bb26b-b86a-4894-b9bc-941f13cbbc93"), new Guid("f8648b59-176b-4750-9d1c-f36bc2fe88ec"), "Barcelona" },
                    { new Guid("7a92e7bf-c265-4a32-9ff0-54e5960d7d10"), new Guid("3a77c84f-8875-4132-9fae-c07f03432435"), "Paris" },
                    { new Guid("7f8b6271-4a05-44e7-a138-a8ef8eaab14d"), new Guid("547732b0-5335-4742-9181-9b15817fe56d"), "Prague" },
                    { new Guid("8dd78fac-c7dd-44ee-8127-e8c1ea6228aa"), new Guid("ff57aa9a-8b92-498f-bc32-07bf52cf2965"), "Cairo" },
                    { new Guid("a1e5cf9f-b565-4b61-b857-84e02d793ea9"), new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"), "Hong Kong" },
                    { new Guid("a7d55187-d5a8-469c-b0df-61f4f002ef4b"), new Guid("e94a3deb-7432-4500-91a0-856d70438f18"), "Lagos" },
                    { new Guid("a989dc51-fa8c-4ecd-9009-80d6776f2caf"), new Guid("9792f174-3ab1-4c4d-a29d-ec2e4fbdc25b"), "Singapore" },
                    { new Guid("b0839cad-30df-4c7d-b6a0-d66d2d723c08"), new Guid("aabcafe9-7833-413d-977b-0c0924783148"), "Buenos Aires" },
                    { new Guid("b4c7d391-ee85-4c1e-aa18-22c91b6c7a10"), new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"), "Beijing" },
                    { new Guid("b5f77004-36ef-4d5d-9382-e5e5379c6b85"), new Guid("4029f4aa-a9dc-4463-af4f-0cb685d8c420"), "Moscow" },
                    { new Guid("b72f3856-c14f-4236-871a-9b6fd65dfb7d"), new Guid("a4a95dc3-b9ed-4df4-903b-0bf45c142417"), "Bangkok" },
                    { new Guid("ba89b05e-d6ce-491e-b7c9-de93fc966026"), new Guid("da8338d1-4f2d-41d4-8824-bf8a6f5f47d7"), "Hanoi" },
                    { new Guid("bb9266fd-d80e-49bb-97d0-2dae374e2d26"), new Guid("90da958f-8edc-4ebe-874d-059b9f4f6a42"), "Nairobi" },
                    { new Guid("bd25997b-cab7-4672-b327-dd12f47e389e"), new Guid("7c0b3044-2382-449f-a603-b80e5a5fc74f"), "Budapest" },
                    { new Guid("c408f493-4f48-4da3-9333-30c7ca58a2ff"), new Guid("6a5cf285-3793-4cce-a155-3cfdef88e4ff"), "London" },
                    { new Guid("cdd77fa2-c2e7-4fbd-a305-019d72230f0c"), new Guid("2db178c1-c424-4d8c-861d-09911bbba51e"), "Helsinki" },
                    { new Guid("ce5f6a19-ce4c-474d-b37d-8d5943908c4d"), new Guid("b7638789-3bea-4e28-b8bc-da6015bfa2b3"), "Berlin" },
                    { new Guid("d16ec04b-693d-4f36-814e-612e66c33c88"), new Guid("0f9d0c04-93d6-4070-9d58-63b42896ffb4"), "Rio de Janeiro" },
                    { new Guid("d1bffbdc-2859-44e7-be6e-e1427848134d"), new Guid("b03f6cac-67cc-4b53-a1a2-4663460e3809"), "Rome" },
                    { new Guid("d482ce69-2334-4a63-82f1-ca6863e053b0"), new Guid("62e0dd7c-ff47-4f62-a63d-075dc6b49320"), "Stockholm" },
                    { new Guid("d7d0760f-733e-456c-be28-381010760b19"), new Guid("46357de9-5c2a-48fb-885e-9dc1e599006e"), "Amsterdam" },
                    { new Guid("dadbdf0b-f358-4759-bc03-f99238f4752e"), new Guid("e7af8513-68f3-404d-b1c9-d703ce6c3cab"), "Copenhagen" },
                    { new Guid("e02a2bfe-6a10-4c7c-8594-60f2040ef84b"), new Guid("8041ff0a-7bdd-4340-a349-7b0417210e7c"), "Brussels" },
                    { new Guid("e4d10339-3680-4f89-b468-ff67723de51f"), new Guid("87ecaa49-f347-46e4-a1c3-02ed7663bb03"), "Mexico City" },
                    { new Guid("f0ca1380-b1e3-4c03-b297-2dd6afc5cd9c"), new Guid("b3a3f6dd-34b6-48b5-b463-d89eee98043d"), "Zurich" },
                    { new Guid("f3e40d2a-3abe-4939-9ffc-a10ec2caf126"), new Guid("1efbbe97-c438-40d2-84b2-426330b98f3c"), "Dubai" },
                    { new Guid("f51a0d31-8043-4fdf-82bc-27c661586b5e"), new Guid("833aecc4-85e5-4859-85ee-cc2e840bb303"), "Oslo" },
                    { new Guid("fa1abf86-1120-4e49-be01-c296df561376"), new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"), "Chicago" },
                    { new Guid("fdd02f60-83ba-4ed3-bde0-62b8ce538920"), new Guid("cb187c9a-7ab2-4862-b209-19cbb2f0c390"), "Tokyo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
