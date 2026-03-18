using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingdummydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
            -- ================= CLEAN =================
                DELETE FROM Inventories;
                DELETE FROM ProductVariants;
                DELETE FROM ProductImages
                DELETE FROM Products;
                DELETE FROM Categories;

            -- ================= CATEGORY =================
            DECLARE @MenId UNIQUEIDENTIFIER = NEWID();
            DECLARE @WomenId UNIQUEIDENTIFIER = NEWID();
            DECLARE @DummyActor UNIQUEIDENTIFIER = NEWID();

            INSERT INTO Categories (Id, Name, ParentId, CreatedAt, CreatedBy)
            VALUES
            (@MenId, 'Men', NULL, GETUTCDATE(), @DummyActor),
            (@WomenId, 'Women', NULL, GETUTCDATE(), @DummyActor);

            -- ================= PRODUCT =================
            DECLARE @TshirtId1 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId1 UNIQUEIDENTIFIER = NEWID();

            DECLARE @TshirtId2 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId2 UNIQUEIDENTIFIER = NEWID();

            DECLARE @TshirtId3 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId3 UNIQUEIDENTIFIER = NEWID();

            DECLARE @TshirtId4 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId4 UNIQUEIDENTIFIER = NEWID();

            DECLARE @TshirtId5 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId5 UNIQUEIDENTIFIER = NEWID();

            DECLARE @TshirtId6 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId6 UNIQUEIDENTIFIER = NEWID();

            DECLARE @TshirtId7 UNIQUEIDENTIFIER = NEWID();
            DECLARE @HoodieId7 UNIQUEIDENTIFIER = NEWID();

            INSERT INTO Products (Id, Name, Description, CategoryId, CreatedAt, CreatedBy)
            VALUES
            (@TshirtId1, 'Classic Cotton T-Shirt - Spring 2020', 'Breathable cotton, regular fit', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId1, 'Oversized Hoodie - Winter 2020', 'Fleece-lined, relaxed fit', @WomenId, GETUTCDATE(), @DummyActor),

            (@TshirtId2, 'Slim Fit T-Shirt - Summer 2021', 'Lightweight cotton, slim fit', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId2, 'Zip-Up Hoodie - Fall 2021', 'Soft fabric, front zipper', @WomenId, GETUTCDATE(), @DummyActor),

            (@TshirtId3, 'Graphic Print T-Shirt - Spring 2022', 'Streetwear graphic design', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId3, 'Pullover Hoodie - Winter 2022', 'Thick fabric, warm and cozy', @WomenId, GETUTCDATE(), @DummyActor),

            (@TshirtId4, 'Oversized T-Shirt - Summer 2023', 'Loose fit, trendy style', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId4, 'Cropped Hoodie - Fall 2023', 'Modern cropped cut', @WomenId, GETUTCDATE(), @DummyActor),

            (@TshirtId5, 'Premium Cotton T-Shirt - Spring 2024', 'High-quality fabric, durable', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId5, 'Minimalist Hoodie - Winter 2024', 'Clean design, neutral tones', @WomenId, GETUTCDATE(), @DummyActor),

            (@TshirtId6, 'Athletic Fit T-Shirt - Summer 2025', 'Stretch fabric, performance wear', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId6, 'Tech Fleece Hoodie - Fall 2025', 'Lightweight warmth, modern tech fabric', @WomenId, GETUTCDATE(), @DummyActor),

            (@TshirtId7, 'Eco-Friendly T-Shirt - Spring 2026', 'Organic cotton, sustainable', @MenId, GETUTCDATE(), @DummyActor),
            (@HoodieId7, 'Recycled Fabric Hoodie - Winter 2026', 'Made from recycled materials', @WomenId, GETUTCDATE(), @DummyActor)

            ;

            -- ================= VARIANTS =================
            DECLARE @Var1 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var2 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var3 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var4 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var5 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var6 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var7 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var8 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var9 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var10 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var11 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var12 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var13 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var14 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var15 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var16 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var17 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var18 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var19 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var20 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var21 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var22 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var23 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var24 UNIQUEIDENTIFIER = NEWID();

            DECLARE @Var25 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var26 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var27 UNIQUEIDENTIFIER = NEWID();
            DECLARE @Var28 UNIQUEIDENTIFIER = NEWID();

            INSERT INTO ProductVariants (Id, ProductId, SKU, Price, Attributes, CreatedBy, IsDeleted, CreatedAt)
            VALUES
            -- 1
            (@Var1, @TshirtId1, 'TS1-RED-M', 19.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var2, @TshirtId1, 'TS1-BLUE-L', 21.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var3, @HoodieId1, 'HD1-BLACK-M', 49.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var4, @HoodieId1, 'HD1-YELLOW-M', 49.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),

            -- 2
            (@Var5, @TshirtId2, 'TS2-RED-M', 20.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var6, @TshirtId2, 'TS2-BLUE-L', 22.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var7, @HoodieId2, 'HD2-BLACK-M', 51.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var8, @HoodieId2, 'HD2-YELLOW-M', 51.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),

            -- 3
            (@Var9, @TshirtId3, 'TS3-RED-M', 21.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var10, @TshirtId3, 'TS3-BLUE-L', 23.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var11, @HoodieId3, 'HD3-BLACK-M', 53.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var12, @HoodieId3, 'HD3-YELLOW-M', 53.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),

            -- 4
            (@Var13, @TshirtId4, 'TS4-RED-M', 22.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var14, @TshirtId4, 'TS4-BLUE-L', 24.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var15, @HoodieId4, 'HD4-BLACK-M', 55.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var16, @HoodieId4, 'HD4-YELLOW-M', 55.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),

            -- 5
            (@Var17, @TshirtId5, 'TS5-RED-M', 23.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var18, @TshirtId5, 'TS5-BLUE-L', 25.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var19, @HoodieId5, 'HD5-BLACK-M', 57.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var20, @HoodieId5, 'HD5-YELLOW-M', 57.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),

            -- 6
            (@Var21, @TshirtId6, 'TS6-RED-M', 24.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var22, @TshirtId6, 'TS6-BLUE-L', 26.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var23, @HoodieId6, 'HD6-BLACK-M', 59.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var24, @HoodieId6, 'HD6-YELLOW-M', 59.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),

            -- 7
            (@Var25, @TshirtId7, 'TS7-RED-M', 25.99, N'{""color"":""red"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var26, @TshirtId7, 'TS7-BLUE-L', 27.99, N'{""color"":""blue"",""size"":""L""}', @DummyActor, 0, GETUTCDATE()),
            (@Var27, @HoodieId7, 'HD7-BLACK-M', 61.99, N'{""color"":""black"",""size"":""M""}', @DummyActor, 0, GETUTCDATE()),
            (@Var28, @HoodieId7, 'HD7-YELLOW-M', 61.99, N'{""color"":""yellow"",""size"":""M""}', @DummyActor, 0, GETUTCDATE())
                ;

            -- ================= INVENTORY =================
            INSERT INTO Inventories (Id, VariantId, Quantity, ReservedQuantity, CreatedBy, IsDeleted, CreatedAt)
            VALUES
            (NEWID(), @Var1, 100, 0, @DummyActor, 0, GETUTCDATE()),
            (NEWID(), @Var2, 50, 0, @DummyActor, 0, GETUTCDATE()),
            (NEWID(), @Var3, 30, 0, @DummyActor, 0, GETUTCDATE()),

            (NEWID(), @Var4, 100, 0, @DummyActor, 0, GETUTCDATE()),
            (NEWID(), @Var5, 50, 0, @DummyActor, 0, GETUTCDATE()),
            (NEWID(), @Var6, 30, 0, @DummyActor, 0, GETUTCDATE())
            ;

            -- ================= ProductImages =================
            INSERT INTO ProductImages (Id, ProductId, Url, IsPrimary, CreatedAt, CreatedBy, IsDeleted)
            VALUES
            -- T-Shirts
            (NEWID(),  @TshirtId1, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @TshirtId2, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @TshirtId3, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @TshirtId4, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @TshirtId5, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @TshirtId6, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @TshirtId7, 'https://blanestore.com/cdn/shop/files/basic-beyaz_304f4144-c54a-4bea-bd55-2558c98858b2.jpg?v=1737342310&width=1946', 1, GETUTCDATE(), @DummyActor, 0),

            -- Hoodies
            (newid(),  @HoodieId1, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(),  @HoodieId2, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(), @HoodieId3, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(), @HoodieId4, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(), @HoodieId5, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(), @HoodieId6, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0),
            (newid(), @HoodieId7, 'https://product.hstatic.net/1000150581/product/1624d7721s-3__2__4cb52ca880ee437597742860ed43bc34.jpg', 1, GETUTCDATE(), @DummyActor, 0);
            
            ";

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
