START TRANSACTION;

ALTER TABLE "EquipmentIdentities" DROP CONSTRAINT "FK_EquipmentIdentities_Equipments_EquipmentId";

ALTER TABLE "Equipments" DROP CONSTRAINT "PK_Equipments";

ALTER TABLE "Equipments" RENAME TO "UnitPopulations";

ALTER INDEX "IX_Equipments_WorkCenterCode" RENAME TO "IX_UnitPopulations_WorkCenterCode";

ALTER INDEX "IX_Equipments_IsActive" RENAME TO "IX_UnitPopulations_IsActive";

ALTER INDEX "IX_Equipments_EquipmentNumber" RENAME TO "IX_UnitPopulations_EquipmentNumber";

ALTER TABLE "UnitPopulations" ADD CONSTRAINT "PK_UnitPopulations" PRIMARY KEY ("Id");

ALTER TABLE "EquipmentIdentities" ADD CONSTRAINT "FK_EquipmentIdentities_UnitPopulations_EquipmentId" FOREIGN KEY ("EquipmentId") REFERENCES "UnitPopulations" ("Id") ON DELETE SET NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241216021309_RenameTheEquipmentsTableToUnitPopulations', '8.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "UnitPopulations" ADD "CustomerId" uuid;

CREATE INDEX "IX_UnitPopulations_CustomerId" ON "UnitPopulations" ("CustomerId");

ALTER TABLE "UnitPopulations" ADD CONSTRAINT "FK_UnitPopulations_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE SET NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250108075502_AddingCustomerIdinUnitPopulation', '8.0.5');

COMMIT;

START TRANSACTION;

CREATE TABLE "Plants" (
    "Id" uuid NOT NULL,
    "PlantName" varchar(50) NOT NULL,
    "PlantDescription" varchar(50) NOT NULL,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_Plants" PRIMARY KEY ("Id")
);

CREATE INDEX "IX_Plants_IsActive" ON "Plants" ("IsActive");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250204024850_AddNewTablePlant', '8.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "Jobs" ADD "JobType" varchar(20);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250303075511_NewColumnJobTypeInTableJobs', '8.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "Jobs" ALTER COLUMN "CreatedByName" TYPE varchar(100);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250304035909_AddMaximumStringCreatedByName', '8.0.5');

COMMIT;

START TRANSACTION;

DROP INDEX "IX_UnitPopulations_WorkCenterCode";

ALTER TABLE "UnitPopulations" DROP COLUMN "ABCInd";

ALTER TABLE "UnitPopulations" DROP COLUMN "CommisioningStatus";

ALTER TABLE "UnitPopulations" DROP COLUMN "ContractPackage";

ALTER TABLE "UnitPopulations" DROP COLUMN "CustomerGroup";

ALTER TABLE "UnitPopulations" DROP COLUMN "CustomerGroupName";

ALTER TABLE "UnitPopulations" DROP COLUMN "FuelConsumptionPerDay";

ALTER TABLE "UnitPopulations" DROP COLUMN "Industry";

ALTER TABLE "UnitPopulations" DROP COLUMN "InterbranchDate";

ALTER TABLE "UnitPopulations" DROP COLUMN "IsAvailable";

ALTER TABLE "UnitPopulations" DROP COLUMN "IsInterbranchStatus";

ALTER TABLE "UnitPopulations" DROP COLUMN "IsPendingCommisioning";

ALTER TABLE "UnitPopulations" DROP COLUMN "IsUnitCaution";

ALTER TABLE "UnitPopulations" DROP COLUMN "LastLocationDate";

ALTER TABLE "UnitPopulations" DROP COLUMN "LastTransmitted";

ALTER TABLE "UnitPopulations" DROP COLUMN "MaterialGroup";

ALTER TABLE "UnitPopulations" DROP COLUMN "MaterialNumber";

ALTER TABLE "UnitPopulations" DROP COLUMN "MeasuringDocument";

ALTER TABLE "UnitPopulations" DROP COLUMN "MeasuringPoint";

ALTER TABLE "UnitPopulations" DROP COLUMN "ObjectType";

ALTER TABLE "UnitPopulations" DROP COLUMN "OperationStatus";

ALTER TABLE "UnitPopulations" DROP COLUMN "StartTransmitted";

ALTER TABLE "UnitPopulations" DROP COLUMN "SystemStatus";

ALTER TABLE "UnitPopulations" DROP COLUMN "TransmitStatus";

ALTER TABLE "UnitPopulations" DROP COLUMN "TransmittedLatitude";

ALTER TABLE "UnitPopulations" DROP COLUMN "TransmittedLongitude";

ALTER TABLE "UnitPopulations" DROP COLUMN "TransmittedPlantCode";

ALTER TABLE "UnitPopulations" DROP COLUMN "TransmittedPlantKabupaten";

ALTER TABLE "UnitPopulations" DROP COLUMN "TransmittedPlantZipCode";

ALTER TABLE "UnitPopulations" DROP COLUMN "UOM";

ALTER TABLE "UnitPopulations" DROP COLUMN "UnitCodeDescription";

ALTER TABLE "UnitPopulations" DROP COLUMN "UnitDescription";

ALTER TABLE "UnitPopulations" DROP COLUMN "UnitStatus";

ALTER TABLE "UnitPopulations" DROP COLUMN "WarrantyType";

ALTER TABLE "UnitPopulations" DROP COLUMN "WorkCenterDesc";

ALTER TABLE "UnitPopulations" RENAME COLUMN "ManufactureSerialNumber" TO "AttachmentType";

ALTER TABLE "UnitPopulations" RENAME COLUMN "ManufacturePartNumber" TO "AttachmentModel";

ALTER TABLE "UnitPopulations" ADD "IsAllFleet" bool NOT NULL DEFAULT TRUE;

CREATE INDEX "IX_UnitPopulations_SerialNumber" ON "UnitPopulations" ("SerialNumber");

CREATE INDEX "IX_UnitPopulations_UnitModel" ON "UnitPopulations" ("UnitModel");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250313012643_UpdateFieldEquipmentTable', '8.0.5');

COMMIT;

