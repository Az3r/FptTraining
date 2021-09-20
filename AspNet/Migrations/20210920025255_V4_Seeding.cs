using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServer.Migrations
{
  public partial class V4_Seeding : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "Categories",
          columns: new[] { "ID", "Name" },
          values: new object[,]
          {
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), "Book" },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), "Car" },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), "Television" },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), "Laptop" },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), "Mobile Phone" }
          });

      migrationBuilder.InsertData(
          table: "ProductDetails",
          columns: new[] { "ProductID", "Detail" },
          values: new object[,]
          {
                    { new Guid("0fdbf451-1ad4-4276-9ec6-c7711210b936"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("54a53467-b32c-4d47-8917-85f6d8cb3882"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("0ac4d331-c681-4382-8efe-7bdb9a176a2d"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("3fffaceb-6a0b-4676-9075-2667d0cd5f38"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("efe96324-d694-4228-bc29-1aef4b10e706"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("71223077-7fdb-4d11-8bad-4ffe8acd7371"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("d703a4b7-2fa9-4582-852e-1c1aff538db4"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("33cbebb4-46a9-4028-9d7d-714bbb3426bc"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("62495399-1606-49fa-bb39-c22a93b326a2"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("42c97850-04be-43c7-a7df-5fefaeed5c7e"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("443a40d5-3114-454a-bbc4-0486591e9416"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("044626ad-be04-4f57-9868-6c8c6c99972c"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("06750427-2506-4cb6-a89b-6f1e36a80ccd"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("76e01e67-d2e3-48be-ae5f-6a30460206e7"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("8551ac3d-5028-4fba-a4e1-87967b29dfa6"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("e7034dc7-2a52-4f24-a86f-02d134dcb705"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("db5a433f-b0e6-4f43-bc87-2c00c382b627"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("7efbd3dc-23a6-4c49-abe4-0706fc3f367c"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("e59b4568-f009-4b14-b749-15536f9ebb54"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("e825462b-fe82-4a4b-8f93-63ff41535e8f"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("99d6555a-4f59-4d33-b472-ed0779f95978"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("3ca3afa8-f4a2-4e6a-b8c6-8319d0ca76e3"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("4b3310be-bb9d-4eeb-b584-627b00fe9898"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("6d24ecc9-2fe7-4d4a-a805-2ffb7f2b409a"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("b65c835c-d85e-41c8-9d27-e7db1bada0ef"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("57bf3a0f-edda-4c86-a676-66769c630f20"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("1c29430b-84eb-47e9-a676-9717691b4bc3"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("802a702a-be68-4ef6-9953-3669bd6c1d29"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("7b1ebcbb-da0a-4e5d-8899-aeb120e7fc95"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("f3276149-b21d-4a66-b23a-d2e579ef8f42"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("222e4f86-09f7-41ed-8545-57be69ba9e13"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("4d8d2c0b-fb62-466d-97e4-03f45e96c50b"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("0e200b77-74c5-49b0-9a2f-6c8937f63c5b"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("20e4c639-07c4-431e-9c2d-2f3cf5e54c5b"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("edda4591-67d2-4698-aea3-9aea75c16e92"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("11b1cacd-ba0b-42f3-8d56-a6e69caee8bf"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("ca0b7956-5bf8-425c-b1d6-4dcc688df39c"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " }
          });

      migrationBuilder.InsertData(
          table: "ProductDetails",
          columns: new[] { "ProductID", "Detail" },
          values: new object[,]
          {
                    { new Guid("2e154709-6a31-4f07-b430-ad0070f30767"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("5cdbccb6-6415-4148-9087-7f690d77e76e"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("315b03d9-7794-486d-8bca-a6f059602582"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("4f139e74-3785-45b7-be30-016eb3006b84"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("8abd528f-00b3-4575-a88f-00f9436e5c26"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("843b47e8-28bd-4e1d-851c-334490093ad2"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("a25ad2ef-b0a2-4db0-806e-8baabc9c8bf4"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("c5df5ec3-c4cf-45ce-92fb-9c46e75ee242"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("fe694d82-dc3f-456d-b373-73fc599b5b75"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("3d2e3a4e-31d7-4a53-a264-724990d477b4"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("c0a054a1-a4de-4714-b0c4-5c5fe5c85ccb"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("5a6fde61-54eb-4a12-9b8d-cd8b764b8258"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("a6a260a2-e335-40d2-ae28-8341e7475615"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("c4b89587-38b8-4cd0-a346-5cac2ff84a7a"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("aa296adc-8f0c-412f-9182-71d71ee5adb8"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("edcfa79c-88fc-4fcb-a386-a83d88424c61"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("532a3a2c-3a3c-45fb-8917-b2b22680d0a5"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("0e9d5579-0c11-4eb5-bb08-2edb4a7622c4"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("c8199e99-0514-4b30-8329-cfe629ace7c4"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("c8423efc-967c-4fee-9018-ffe599f965de"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " },
                    { new Guid("18f96215-987c-43f0-aa26-fa728919418e"), "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. " }
          });

      migrationBuilder.InsertData(
          table: "Suppliers",
          columns: new[] { "ID", "Address", "Name" },
          values: new object[,]
          {
                    { new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36"), "Ha Noi City", "Beta" },
                    { new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201"), "Da Nang City", "Delta" },
                    { new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361"), "Ho Chi Minh City", "Alpha" }
          });

      migrationBuilder.InsertData(
          table: "Users",
          columns: new[] { "ID", "DisplayName", "HashedPassword" },
          values: new object[] { new Guid("a814ae1c-733f-46c4-a230-261e39072f6e"), "Tuan Nguyen", "$2a$13$xk2HTLFXnufoUgKKDrNeL.pT.6o.3tBcpQcfztHuIQ4Umyokg6.7a" });

      migrationBuilder.InsertData(
          table: "Products",
          columns: new[] { "ID", "Description", "DiscontinuedDate", "Name", "Price", "Rating", "ReleaseDate", "SupplierID" },
          values: new object[,]
          {
                    { new Guid("20e4c639-07c4-431e-9c2d-2f3cf5e54c5b"), "product's short description", null, "Harry Potter and the Order of the Phoenix (Harry Potter, #5)", 642.4555553321054, (short)0, new DateTime(2019, 3, 28, 0, 36, 0, 838, DateTimeKind.Utc).AddTicks(7758), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("99d6555a-4f59-4d33-b472-ed0779f95978"), "product's short description", null, "Samsung Galaxy Z Flip 3", 951.68983654663418, (short)0, new DateTime(2024, 11, 19, 22, 27, 10, 242, DateTimeKind.Utc).AddTicks(8183), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("1c29430b-84eb-47e9-a676-9717691b4bc3"), "product's short description", null, "OnePlus 9 Pro", 56.341407846818406, (short)4, new DateTime(2017, 11, 20, 1, 51, 2, 7, DateTimeKind.Utc).AddTicks(8283), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("edda4591-67d2-4698-aea3-9aea75c16e92"), "product's short description", null, "J.K. Rowling", 989.76714768901797, (short)1, new DateTime(2023, 3, 31, 17, 11, 43, 793, DateTimeKind.Utc).AddTicks(7768), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("11b1cacd-ba0b-42f3-8d56-a6e69caee8bf"), "product's short description", null, "To Kill a Mockingbird", 615.34640826999509, (short)1, new DateTime(2023, 9, 16, 14, 6, 53, 338, DateTimeKind.Utc).AddTicks(7775), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("2e154709-6a31-4f07-b430-ad0070f30767"), "product's short description", null, "Pride and Prejudice", 169.46715310656799, (short)3, new DateTime(2019, 10, 27, 3, 24, 7, 864, DateTimeKind.Utc).AddTicks(7797), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("315b03d9-7794-486d-8bca-a6f059602582"), "product's short description", null, "Twilight (The Twilight Saga, #1)", 13.614402624598892, (short)3, new DateTime(2024, 9, 26, 19, 20, 26, 591, DateTimeKind.Utc).AddTicks(7811), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("8abd528f-00b3-4575-a88f-00f9436e5c26"), "product's short description", null, "Abarth", 993.79634996587242, (short)1, new DateTime(2020, 8, 7, 22, 27, 35, 619, DateTimeKind.Utc).AddTicks(7837), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("843b47e8-28bd-4e1d-851c-334490093ad2"), "product's short description", null, "Acura", 675.40553010786209, (short)2, new DateTime(2021, 6, 14, 11, 15, 16, 694, DateTimeKind.Utc).AddTicks(7845), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("532a3a2c-3a3c-45fb-8917-b2b22680d0a5"), "product's short description", null, "Audi", 85.039602166525839, (short)4, new DateTime(2021, 8, 8, 2, 33, 8, 834, DateTimeKind.Utc).AddTicks(7864), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("5a6fde61-54eb-4a12-9b8d-cd8b764b8258"), "product's short description", null, "Buick", 875.82151399730776, (short)4, new DateTime(2018, 12, 17, 22, 23, 59, 74, DateTimeKind.Utc).AddTicks(7885), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("c4b89587-38b8-4cd0-a346-5cac2ff84a7a"), "product's short description", null, "Chevrolet", 774.29170150975312, (short)2, new DateTime(2017, 12, 31, 6, 31, 31, 80, DateTimeKind.Utc).AddTicks(7935), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("fe694d82-dc3f-456d-b373-73fc599b5b75"), "product's short description", null, "Audiovox", 836.59599294727479, (short)3, new DateTime(2024, 6, 1, 10, 54, 26, 614, DateTimeKind.Utc).AddTicks(7957), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("0e9d5579-0c11-4eb5-bb08-2edb4a7622c4"), "product's short description", null, "BPL india lmt", 26.342012931752024, (short)0, new DateTime(2019, 1, 7, 14, 39, 31, 280, DateTimeKind.Utc).AddTicks(7964), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("222e4f86-09f7-41ed-8545-57be69ba9e13"), "product's short description", null, "Gradiente", 439.16100284045609, (short)1, new DateTime(2018, 7, 10, 1, 58, 40, 194, DateTimeKind.Utc).AddTicks(7990), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("f3276149-b21d-4a66-b23a-d2e579ef8f42"), "product's short description", null, "Hannspree", 851.11425763513625, (short)0, new DateTime(2019, 12, 5, 5, 51, 40, 995, DateTimeKind.Utc).AddTicks(7997), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("7b1ebcbb-da0a-4e5d-8899-aeb120e7fc95"), "product's short description", null, "Heath Company", 651.28952621076701, (short)4, new DateTime(2023, 9, 7, 12, 31, 10, 43, DateTimeKind.Utc).AddTicks(8003), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("e7034dc7-2a52-4f24-a86f-02d134dcb705"), "product's short description", null, "Omen", 541.13244569913138, (short)4, new DateTime(2018, 5, 19, 18, 46, 30, 341, DateTimeKind.Utc).AddTicks(8012), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("62495399-1606-49fa-bb39-c22a93b326a2"), "product's short description", null, "Spectre", 825.20602775048746, (short)2, new DateTime(2017, 12, 26, 10, 31, 18, 716, DateTimeKind.Utc).AddTicks(8034), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("71223077-7fdb-4d11-8bad-4ffe8acd7371"), "product's short description", null, "Vostro", 694.0122571280283, (short)4, new DateTime(2017, 4, 29, 4, 54, 38, 807, DateTimeKind.Utc).AddTicks(8040), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("d703a4b7-2fa9-4582-852e-1c1aff538db4"), "product's short description", null, "MacBook", 202.55167419209687, (short)1, new DateTime(2018, 7, 23, 15, 17, 31, 127, DateTimeKind.Utc).AddTicks(8046), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("54a53467-b32c-4d47-8917-85f6d8cb3882"), "product's short description", null, "Gram", 993.86399052751437, (short)0, new DateTime(2017, 5, 19, 2, 49, 31, 684, DateTimeKind.Utc).AddTicks(8111), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("0fdbf451-1ad4-4276-9ec6-c7711210b936"), "product's short description", null, "VAIO", 827.01951257280052, (short)1, new DateTime(2019, 11, 14, 0, 39, 11, 251, DateTimeKind.Utc).AddTicks(8118), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("7efbd3dc-23a6-4c49-abe4-0706fc3f367c"), "product's short description", null, "Rs. 105,040", 377.3049653402087, (short)1, new DateTime(2019, 12, 28, 10, 49, 39, 173, DateTimeKind.Utc).AddTicks(8164), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("e59b4568-f009-4b14-b749-15536f9ebb54"), "product's short description", null, "Samsung Galaxy Z Fold 3", 685.15585301684018, (short)1, new DateTime(2019, 4, 27, 19, 25, 52, 278, DateTimeKind.Utc).AddTicks(8171), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("3ca3afa8-f4a2-4e6a-b8c6-8319d0ca76e3"), "product's short description", null, "Rs. 84,999", 441.46957594969757, (short)1, new DateTime(2018, 7, 5, 1, 13, 0, 295, DateTimeKind.Utc).AddTicks(8190), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("e825462b-fe82-4a4b-8f93-63ff41535e8f"), "product's short description", null, "Rs. 149,999", 324.10512041491694, (short)4, new DateTime(2018, 4, 29, 7, 30, 6, 620, DateTimeKind.Utc).AddTicks(8177), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("db5a433f-b0e6-4f43-bc87-2c00c382b627"), "product's short description", null, "Samsung Galaxy S21 Ultra", 410.3301793384972, (short)3, new DateTime(2022, 1, 14, 4, 8, 9, 649, DateTimeKind.Utc).AddTicks(8158), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("06750427-2506-4cb6-a89b-6f1e36a80ccd"), "product's short description", null, "Apple iPhone 12 Pro Max", 800.38987137395407, (short)3, new DateTime(2024, 1, 29, 6, 11, 18, 729, DateTimeKind.Utc).AddTicks(8132), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("33cbebb4-46a9-4028-9d7d-714bbb3426bc"), "product's short description", null, "HTC", 874.76672645414567, (short)4, new DateTime(2019, 8, 26, 14, 26, 23, 738, DateTimeKind.Utc).AddTicks(8125), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("ca0b7956-5bf8-425c-b1d6-4dcc688df39c"), "product's short description", null, "Harper Lee", 93.388480643457015, (short)4, new DateTime(2020, 7, 22, 5, 10, 59, 423, DateTimeKind.Utc).AddTicks(7790), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("3d2e3a4e-31d7-4a53-a264-724990d477b4"), "product's short description", null, "Bentley", 46.855521410170724, (short)3, new DateTime(2018, 11, 28, 9, 20, 7, 219, DateTimeKind.Utc).AddTicks(7871), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("aa296adc-8f0c-412f-9182-71d71ee5adb8"), "product's short description", null, "Acer", 320.90894008097655, (short)2, new DateTime(2021, 6, 2, 11, 30, 40, 598, DateTimeKind.Utc).AddTicks(7944), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("c8199e99-0514-4b30-8329-cfe629ace7c4"), "product's short description", null, "Bush", 476.30751481107785, (short)4, new DateTime(2017, 12, 30, 20, 55, 51, 690, DateTimeKind.Utc).AddTicks(7971), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("18f96215-987c-43f0-aa26-fa728919418e"), "product's short description", null, "Emerson", 306.02674712707602, (short)2, new DateTime(2018, 6, 11, 11, 2, 55, 200, DateTimeKind.Utc).AddTicks(7984), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("443a40d5-3114-454a-bbc4-0486591e9416"), "product's short description", null, "Pavilion", 22.440291020292925, (short)0, new DateTime(2017, 7, 11, 17, 14, 29, 416, DateTimeKind.Utc).AddTicks(8019), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("42c97850-04be-43c7-a7df-5fefaeed5c7e"), "product's short description", null, "ZBook", 203.0018801814885, (short)1, new DateTime(2025, 12, 1, 15, 15, 17, 813, DateTimeKind.Utc).AddTicks(8026), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("efe96324-d694-4228-bc29-1aef4b10e706"), "product's short description", null, "ROG", 568.16922713451515, (short)0, new DateTime(2018, 12, 23, 3, 25, 38, 456, DateTimeKind.Utc).AddTicks(8092), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("3fffaceb-6a0b-4676-9075-2667d0cd5f38"), "product's short description", null, "Pixelbook", 601.18403406868879, (short)3, new DateTime(2022, 7, 25, 1, 31, 5, 801, DateTimeKind.Utc).AddTicks(8098), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("802a702a-be68-4ef6-9953-3669bd6c1d29"), "product's short description", null, "Rs. 115,900", 508.71412619422853, (short)3, new DateTime(2020, 2, 16, 11, 50, 12, 790, DateTimeKind.Utc).AddTicks(8139), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("8551ac3d-5028-4fba-a4e1-87967b29dfa6"), "product's short description", null, "Xiaomi Mi 11 Ultra", 893.646356600172, (short)1, new DateTime(2023, 12, 7, 13, 16, 50, 343, DateTimeKind.Utc).AddTicks(8145), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("76e01e67-d2e3-48be-ae5f-6a30460206e7"), "product's short description", null, "Rs. 70,999", 861.34661494816964, (short)4, new DateTime(2025, 5, 23, 15, 26, 47, 707, DateTimeKind.Utc).AddTicks(8151), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") }
          });

      migrationBuilder.InsertData(
          table: "Products",
          columns: new[] { "ID", "Description", "DiscontinuedDate", "Name", "Price", "Rating", "ReleaseDate", "SupplierID" },
          values: new object[,]
          {
                    { new Guid("b65c835c-d85e-41c8-9d27-e7db1bada0ef"), "product's short description", null, "Vivo X60 Pro Plus", 829.07021037725269, (short)2, new DateTime(2021, 3, 5, 19, 27, 45, 757, DateTimeKind.Utc).AddTicks(8270), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") },
                    { new Guid("4b3310be-bb9d-4eeb-b584-627b00fe9898"), "product's short description", null, "Asus ROG Phone 5", 10.90355776758099, (short)1, new DateTime(2019, 7, 24, 17, 24, 8, 221, DateTimeKind.Utc).AddTicks(8196), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("4d8d2c0b-fb62-466d-97e4-03f45e96c50b"), "product's short description", null, "The Hunger Games (The Hunger Games, #1)", 110.74397718102855, (short)1, new DateTime(2024, 5, 24, 21, 28, 41, 527, DateTimeKind.Utc).AddTicks(3992), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("0e200b77-74c5-49b0-9a2f-6c8937f63c5b"), "product's short description", null, "Suzanne Collins", 432.78260130099142, (short)3, new DateTime(2026, 2, 4, 0, 34, 57, 779, DateTimeKind.Utc).AddTicks(7621), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("5cdbccb6-6415-4148-9087-7f690d77e76e"), "product's short description", null, "Jane Austen", 886.46954059902089, (short)4, new DateTime(2023, 11, 9, 8, 42, 1, 54, DateTimeKind.Utc).AddTicks(7803), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("4f139e74-3785-45b7-be30-016eb3006b84"), "product's short description", null, "Stephenie Meyer", 62.503324850696764, (short)4, new DateTime(2021, 12, 20, 1, 11, 39, 708, DateTimeKind.Utc).AddTicks(7820), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("c5df5ec3-c4cf-45ce-92fb-9c46e75ee242"), "product's short description", null, "Alfa Romeo", 353.48411060566275, (short)1, new DateTime(2018, 6, 18, 1, 23, 58, 734, DateTimeKind.Utc).AddTicks(7852), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("a25ad2ef-b0a2-4db0-806e-8baabc9c8bf4"), "product's short description", null, "Aston Martin", 691.694964511178, (short)1, new DateTime(2018, 4, 28, 3, 4, 58, 810, DateTimeKind.Utc).AddTicks(7858), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("c0a054a1-a4de-4714-b0c4-5c5fe5c85ccb"), "product's short description", null, "BMW", 311.90280537675261, (short)0, new DateTime(2019, 10, 24, 12, 6, 46, 975, DateTimeKind.Utc).AddTicks(7877), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("a6a260a2-e335-40d2-ae28-8341e7475615"), "product's short description", null, "Cadillac", 178.99329130490929, (short)0, new DateTime(2026, 3, 19, 15, 44, 6, 845, DateTimeKind.Utc).AddTicks(7891), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("edcfa79c-88fc-4fcb-a386-a83d88424c61"), "product's short description", null, "Alba", 386.87502890214091, (short)1, new DateTime(2016, 11, 12, 11, 35, 49, 290, DateTimeKind.Utc).AddTicks(7951), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("c8423efc-967c-4fee-9018-ffe599f965de"), "product's short description", null, "Element", 370.88594463229458, (short)0, new DateTime(2020, 6, 4, 10, 19, 23, 553, DateTimeKind.Utc).AddTicks(7978), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("044626ad-be04-4f57-9868-6c8c6c99972c"), "product's short description", null, "VivoBook", 680.91972343666464, (short)0, new DateTime(2019, 2, 18, 22, 58, 56, 518, DateTimeKind.Utc).AddTicks(8085), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("0ac4d331-c681-4382-8efe-7bdb9a176a2d"), "product's short description", null, "Pixelbook Go", 313.68857310790963, (short)3, new DateTime(2022, 1, 23, 18, 12, 5, 736, DateTimeKind.Utc).AddTicks(8105), new Guid("3bc7c37d-06ee-408f-ac34-32d574121a36") },
                    { new Guid("6d24ecc9-2fe7-4d4a-a805-2ffb7f2b409a"), "product's short description", null, "Rs. 49,999", 150.29569675694017, (short)4, new DateTime(2021, 9, 1, 9, 9, 8, 467, DateTimeKind.Utc).AddTicks(8261), new Guid("de7dfb6d-a4cb-40fa-8589-9f92c2f51361") },
                    { new Guid("57bf3a0f-edda-4c86-a676-66769c630f20"), "product's short description", null, "Rs. 69,990", 939.92799424562975, (short)2, new DateTime(2020, 5, 10, 12, 40, 46, 483, DateTimeKind.Utc).AddTicks(8276), new Guid("ae0a77b1-72dd-4f7a-8236-ca4860a75201") }
          });

      migrationBuilder.InsertData(
          table: "CategoryProduct",
          columns: new[] { "CategoriesID", "ProductsID" },
          values: new object[,]
          {
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("20e4c639-07c4-431e-9c2d-2f3cf5e54c5b") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("99d6555a-4f59-4d33-b472-ed0779f95978") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("1c29430b-84eb-47e9-a676-9717691b4bc3") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("edda4591-67d2-4698-aea3-9aea75c16e92") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("11b1cacd-ba0b-42f3-8d56-a6e69caee8bf") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("2e154709-6a31-4f07-b430-ad0070f30767") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("315b03d9-7794-486d-8bca-a6f059602582") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("8abd528f-00b3-4575-a88f-00f9436e5c26") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("843b47e8-28bd-4e1d-851c-334490093ad2") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("532a3a2c-3a3c-45fb-8917-b2b22680d0a5") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("5a6fde61-54eb-4a12-9b8d-cd8b764b8258") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("c4b89587-38b8-4cd0-a346-5cac2ff84a7a") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("fe694d82-dc3f-456d-b373-73fc599b5b75") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("0e9d5579-0c11-4eb5-bb08-2edb4a7622c4") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("222e4f86-09f7-41ed-8545-57be69ba9e13") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("f3276149-b21d-4a66-b23a-d2e579ef8f42") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("7b1ebcbb-da0a-4e5d-8899-aeb120e7fc95") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("e7034dc7-2a52-4f24-a86f-02d134dcb705") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("62495399-1606-49fa-bb39-c22a93b326a2") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("71223077-7fdb-4d11-8bad-4ffe8acd7371") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("d703a4b7-2fa9-4582-852e-1c1aff538db4") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("54a53467-b32c-4d47-8917-85f6d8cb3882") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("0fdbf451-1ad4-4276-9ec6-c7711210b936") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("7efbd3dc-23a6-4c49-abe4-0706fc3f367c") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("e59b4568-f009-4b14-b749-15536f9ebb54") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("3ca3afa8-f4a2-4e6a-b8c6-8319d0ca76e3") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("e825462b-fe82-4a4b-8f93-63ff41535e8f") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("db5a433f-b0e6-4f43-bc87-2c00c382b627") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("06750427-2506-4cb6-a89b-6f1e36a80ccd") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("33cbebb4-46a9-4028-9d7d-714bbb3426bc") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("ca0b7956-5bf8-425c-b1d6-4dcc688df39c") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("3d2e3a4e-31d7-4a53-a264-724990d477b4") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("aa296adc-8f0c-412f-9182-71d71ee5adb8") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("c8199e99-0514-4b30-8329-cfe629ace7c4") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("18f96215-987c-43f0-aa26-fa728919418e") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("443a40d5-3114-454a-bbc4-0486591e9416") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("42c97850-04be-43c7-a7df-5fefaeed5c7e") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("efe96324-d694-4228-bc29-1aef4b10e706") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("3fffaceb-6a0b-4676-9075-2667d0cd5f38") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("802a702a-be68-4ef6-9953-3669bd6c1d29") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("8551ac3d-5028-4fba-a4e1-87967b29dfa6") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("76e01e67-d2e3-48be-ae5f-6a30460206e7") }
          });

      migrationBuilder.InsertData(
          table: "CategoryProduct",
          columns: new[] { "CategoriesID", "ProductsID" },
          values: new object[,]
          {
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("b65c835c-d85e-41c8-9d27-e7db1bada0ef") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("4b3310be-bb9d-4eeb-b584-627b00fe9898") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("4d8d2c0b-fb62-466d-97e4-03f45e96c50b") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("0e200b77-74c5-49b0-9a2f-6c8937f63c5b") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("5cdbccb6-6415-4148-9087-7f690d77e76e") },
                    { new Guid("438abce7-1034-471c-bdc8-8cd6e865939a"), new Guid("4f139e74-3785-45b7-be30-016eb3006b84") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("c5df5ec3-c4cf-45ce-92fb-9c46e75ee242") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("a25ad2ef-b0a2-4db0-806e-8baabc9c8bf4") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("c0a054a1-a4de-4714-b0c4-5c5fe5c85ccb") },
                    { new Guid("ea76cc34-e8a5-4e91-899e-1edcde3dc869"), new Guid("a6a260a2-e335-40d2-ae28-8341e7475615") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("edcfa79c-88fc-4fcb-a386-a83d88424c61") },
                    { new Guid("2ee81735-67ce-4d68-aa49-c71034dd190a"), new Guid("c8423efc-967c-4fee-9018-ffe599f965de") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("044626ad-be04-4f57-9868-6c8c6c99972c") },
                    { new Guid("d6866030-7f1c-4388-ad3e-5f06ba307e6f"), new Guid("0ac4d331-c681-4382-8efe-7bdb9a176a2d") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("6d24ecc9-2fe7-4d4a-a805-2ffb7f2b409a") },
                    { new Guid("99b5e2e3-aeea-404b-bf0c-ee2e1b4325b6"), new Guid("57bf3a0f-edda-4c86-a676-66769c630f20") }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }
  }
}
