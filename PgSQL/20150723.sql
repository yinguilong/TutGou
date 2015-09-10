CREATE SCHEMA IF NOT EXISTS dbo
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."Categories"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"Name" varchar(25) NOT NULL DEFAULT '',"Description" text,CONSTRAINT "PK_dbo.Categories" PRIMARY KEY ("Id"))
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."NativeProducts"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"Name" varchar(40) NOT NULL DEFAULT '',"Description" text NOT NULL DEFAULT '',"UnitPrice" numeric(18,2) NOT NULL DEFAULT 0,"ImageUrl" varchar(255),"InitialAddress" text,"IsNew" boolean NOT NULL DEFAULT FALSE,"ShopId" int4 NOT NULL DEFAULT 0,CONSTRAINT "PK_dbo.NativeProducts" PRIMARY KEY ("Id"))
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."Orders"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"Status" int4 NOT NULL DEFAULT 0,"CreatedDate" timestamp NOT NULL DEFAULT '-infinity',"DispatchedDate" timestamp,"DeliveredDate" timestamp,"DeliveryAddress_Id" uuid,"User_Id" uuid,CONSTRAINT "PK_dbo.Orders" PRIMARY KEY ("Id"))
;

CREATE INDEX "Orders_IX_DeliveryAddress_Id" ON "dbo"."Orders" ("DeliveryAddress_Id")
;

CREATE INDEX "Orders_IX_User_Id" ON "dbo"."Orders" ("User_Id")
;

CREATE TABLE "dbo"."Addresses"("Id" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',"Country" text,"State" text,"City" text,"Street" text,"Zip" text,"UserId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',CONSTRAINT "PK_dbo.Addresses" PRIMARY KEY ("Id"))
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."OrderItems"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"Quantity" int4 NOT NULL DEFAULT 0,"Order_Id" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',"Product_Id" uuid,CONSTRAINT "PK_dbo.OrderItems" PRIMARY KEY ("Id"))
;

CREATE INDEX "OrderItems_IX_Order_Id" ON "dbo"."OrderItems" ("Order_Id")
;

CREATE INDEX "OrderItems_IX_Product_Id" ON "dbo"."OrderItems" ("Product_Id")
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."Users"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"UserName" varchar(20) NOT NULL DEFAULT '',"Password" varchar(20) NOT NULL DEFAULT '',"Email" varchar(80) NOT NULL DEFAULT '',"PhoneNumber" text,"IsDisabled" boolean NOT NULL DEFAULT FALSE,"RegisteredDate" timestamp NOT NULL DEFAULT '-infinity',"LastLogonDate" timestamp,"Contact" text,"ContactAddress_Id" uuid,CONSTRAINT "PK_dbo.Users" PRIMARY KEY ("Id"))
;

CREATE INDEX "Users_IX_ContactAddress_Id" ON "dbo"."Users" ("ContactAddress_Id")
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."ProductCategorizations"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"CategoryId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',"ProductId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',CONSTRAINT "PK_dbo.ProductCategorizations" PRIMARY KEY ("Id"))
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."ShoppingCarts"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"User_Id" uuid,CONSTRAINT "PK_dbo.ShoppingCarts" PRIMARY KEY ("Id"))
;

CREATE INDEX "ShoppingCarts_IX_User_Id" ON "dbo"."ShoppingCarts" ("User_Id")
;

select * from uuid_generate_v4()
;

CREATE TABLE "dbo"."ShoppingCartItems"("Id" uuid NOT NULL DEFAULT uuid_generate_v4(),"Quantity" int4 NOT NULL DEFAULT 0,"Product_Id" uuid,"ShoopingCart_Id" uuid,CONSTRAINT "PK_dbo.ShoppingCartItems" PRIMARY KEY ("Id"))
;

CREATE INDEX "ShoppingCartItems_IX_Product_Id" ON "dbo"."ShoppingCartItems" ("Product_Id")
;

CREATE INDEX "ShoppingCartItems_IX_ShoopingCart_Id" ON "dbo"."ShoppingCartItems" ("ShoopingCart_Id")
;

ALTER TABLE "dbo"."Orders" ADD CONSTRAINT "FK_dbo.Orders_dbo.Addresses_DeliveryAddress_Id" FOREIGN KEY ("DeliveryAddress_Id") REFERENCES "dbo"."Addresses" ("Id")
;

ALTER TABLE "dbo"."Orders" ADD CONSTRAINT "FK_dbo.Orders_dbo.Users_User_Id" FOREIGN KEY ("User_Id") REFERENCES "dbo"."Users" ("Id")
;

ALTER TABLE "dbo"."OrderItems" ADD CONSTRAINT "FK_dbo.OrderItems_dbo.Orders_Order_Id" FOREIGN KEY ("Order_Id") REFERENCES "dbo"."Orders" ("Id") ON DELETE CASCADE
;

ALTER TABLE "dbo"."OrderItems" ADD CONSTRAINT "FK_dbo.OrderItems_dbo.NativeProducts_Product_Id" FOREIGN KEY ("Product_Id") REFERENCES "dbo"."NativeProducts" ("Id")
;

ALTER TABLE "dbo"."Users" ADD CONSTRAINT "FK_dbo.Users_dbo.Addresses_ContactAddress_Id" FOREIGN KEY ("ContactAddress_Id") REFERENCES "dbo"."Addresses" ("Id")
;

ALTER TABLE "dbo"."ShoppingCarts" ADD CONSTRAINT "FK_dbo.ShoppingCarts_dbo.Users_User_Id" FOREIGN KEY ("User_Id") REFERENCES "dbo"."Users" ("Id")
;

ALTER TABLE "dbo"."ShoppingCartItems" ADD CONSTRAINT "FK_dbo.ShoppingCartItems_dbo.NativeProducts_Product_Id" FOREIGN KEY ("Product_Id") REFERENCES "dbo"."NativeProducts" ("Id")
;

ALTER TABLE "dbo"."ShoppingCartItems" ADD CONSTRAINT "FK_dbo.ShoppingCartItems_dbo.ShoppingCarts_ShoopingCart_Id" FOREIGN KEY ("ShoopingCart_Id") REFERENCES "dbo"."ShoppingCarts" ("Id")
;

CREATE TABLE "dbo"."__MigrationHistory"("MigrationId" varchar(150) NOT NULL DEFAULT '',"ContextKey" varchar(300) NOT NULL DEFAULT '',"Model" bytea NOT NULL DEFAULT '',"ProductVersion" varchar(32) NOT NULL DEFAULT '',CONSTRAINT "PK_dbo.__MigrationHistory" PRIMARY KEY ("MigrationId","ContextKey"))
;

INSERT INTO "dbo"."__MigrationHistory"("MigrationId","ContextKey","Model","ProductVersion") VALUES (E'201507230928028_InitialCreate',E'OnlineNative.Repositories.Migrations.Configuration',decode('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', 'base64'),E'6.0.0-20911')
