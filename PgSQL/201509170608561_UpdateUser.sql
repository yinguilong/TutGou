﻿CREATE SCHEMA IF NOT EXISTS dbo
;

CREATE TABLE "dbo"."Roles"("Id" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',"Name" text,"Description" text,CONSTRAINT "PK_dbo.Roles" PRIMARY KEY ("Id"))
;

CREATE TABLE "dbo"."UserRoles"("Id" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',"UserId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',"RoleId" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',CONSTRAINT "PK_dbo.UserRoles" PRIMARY KEY ("Id"))
;

ALTER TABLE "dbo"."Users" ADD "LoginAccount" text
;

ALTER TABLE "dbo"."Users" ADD "DeliveryAddress_Id" uuid
;

CREATE INDEX "Users_IX_DeliveryAddress_Id" ON "dbo"."Users" ("DeliveryAddress_Id")
;

ALTER TABLE "dbo"."Users" ADD CONSTRAINT "FK_dbo.Users_dbo.Addresses_DeliveryAddress_Id" FOREIGN KEY ("DeliveryAddress_Id") REFERENCES "dbo"."Addresses" ("Id")
;

INSERT INTO "dbo"."__MigrationHistory"("MigrationId","ContextKey","Model","ProductVersion") VALUES (E'201509170608561_UpdateUser',E'OnlineNative.Repositories.Migrations.Configuration',decode('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', 'base64'),E'6.1.3-40302')
