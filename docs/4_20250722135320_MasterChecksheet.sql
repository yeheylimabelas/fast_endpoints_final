START TRANSACTION;

ALTER TABLE "AdditionalJobs" ADD "UnitApplication" varchar(100) NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250609071415_AddUnitApplicationInAdditionalJobs', '8.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "ChecksheetMaster" DROP COLUMN "CustomerCode";

ALTER TABLE "MSector" RENAME COLUMN "Sector" TO "Name";

ALTER TABLE "ChecksheetMaster" ADD "UnitApplicationId" uuid;

CREATE TABLE "MUnitApplication" (
    "Id" uuid NOT NULL,
    "SectorId" uuid,
    "Name" varchar(100) NOT NULL,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_MUnitApplication" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_MUnitApplication_MSector_SectorId" FOREIGN KEY ("SectorId") REFERENCES "MSector" ("Id") ON DELETE SET NULL
);

CREATE TABLE "MasterChecksheetCustomer" (
    "Id" uuid NOT NULL,
    "UnitApplicationId" uuid,
    "CustomerId" uuid,
    "CustomerCode" varchar(20),
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_MasterChecksheetCustomer" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_MasterChecksheetCustomer_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE SET NULL,
    CONSTRAINT "FK_MasterChecksheetCustomer_MUnitApplication_UnitApplicationId" FOREIGN KEY ("UnitApplicationId") REFERENCES "MUnitApplication" ("Id") ON DELETE SET NULL
);

CREATE INDEX "IX_MasterChecksheetCustomer_CustomerId" ON "MasterChecksheetCustomer" ("CustomerId");

CREATE INDEX "IX_MasterChecksheetCustomer_IsActive" ON "MasterChecksheetCustomer" ("IsActive");

CREATE INDEX "IX_MasterChecksheetCustomer_UnitApplicationId" ON "MasterChecksheetCustomer" ("UnitApplicationId");

CREATE INDEX "IX_MUnitApplication_IsActive" ON "MUnitApplication" ("IsActive");

CREATE INDEX "IX_MUnitApplication_SectorId" ON "MUnitApplication" ("SectorId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250623074511_NewTableMasterChecksheetCustomer', '8.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "MasterChecksheetCustomer" ADD "UpdatedByName" varchar(200);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250717015211_NewColumnUpdatedByName', '8.0.5');

COMMIT;

