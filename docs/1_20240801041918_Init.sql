CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Changelogs" (
    "Id" uuid NOT NULL,
    "Method" varchar(6),
    "TableName" varchar(50),
    "KeyValues" varchar(100),
    "NewValues" text,
    "OldValues" text,
    "ChangeBy" varchar(150),
    "ChangeDate" timestamp with time zone NOT NULL DEFAULT (now()),
    CONSTRAINT "PK_Changelogs" PRIMARY KEY ("Id")
);

CREATE TABLE "ChecksheetMaster" (
    "Id" uuid NOT NULL,
    "Sector" varchar(50) NOT NULL,
    "Parameter" varchar(100),
    "AssessmentArea" varchar(250),
    "UnitApplication" varchar(100),
    "Klausul" varchar(5),
    "Description" varchar(250),
    "OperationStandard" varchar[] NOT NULL DEFAULT ARRAY[]::varchar[],
    "Guidance" varchar[] NOT NULL DEFAULT ARRAY[]::varchar[],
    "Score" integer[],
    "Weight" real NOT NULL,
    "Sequence" integer NOT NULL,
    "Measurement" varchar(5),
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_ChecksheetMaster" PRIMARY KEY ("Id")
);

CREATE TABLE "Customers" (
    "Id" uuid NOT NULL,
    "Code" varchar(20),
    "Name" varchar(100),
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_Customers" PRIMARY KEY ("Id")
);

CREATE TABLE "Equipments" (
    "Id" uuid NOT NULL,
    "UnitModel" varchar(50),
    "SerialNumber" varchar(50),
    "MaterialNumber" varchar(50),
    "MaterialGroup" varchar(50),
    "EquipmentNumber" varchar(36),
    "EquipmentCategory" varchar(250),
    "UnitCode" varchar(50),
    "UnitCodeDescription" varchar(250),
    "OperationStatus" integer,
    "UnitDescription" varchar(250),
    "CustomerCode" varchar(10),
    "CustomerGroup" varchar(10),
    "CustomerName" varchar(50),
    "CustomerGroupName" varchar(50),
    "PlantCode" varchar(10),
    "PlantDescription" varchar(250),
    "WorkCenterCode" varchar(10),
    "WorkCenterDesc" varchar(250),
    "BrandCode" varchar(10),
    "EngineModel" varchar(50),
    "EngineSerialNumber" varchar(50),
    "Industry" varchar(8),
    "ABCInd" varchar(5),
    "ObjectType" varchar(10),
    "MasterWarranty" varchar(25),
    "WarrantyStartDate" timestamp with time zone,
    "WarrantyEndDate" timestamp with time zone,
    "WarrantyType" varchar(50),
    "StartTransmitted" timestamp with time zone,
    "LastTransmitted" timestamp with time zone,
    "LastOperationDate" timestamp with time zone,
    "TransmittedLatitude" varchar(18),
    "TransmittedLongitude" varchar(18),
    "TransmittedPlantCode" varchar(10),
    "TransmittedPlantKabupaten" varchar(250),
    "TransmittedPlantZipCode" varchar(5),
    "FuelConsumptionPerDay" double precision,
    "SMRValuePerDayInMinutes" double precision,
    "SMRTotalInMinutes" double precision,
    "SMRLastValueDate" timestamp with time zone,
    "UOM" varchar(10),
    "IsUnitCaution" boolean,
    "IsInterbranchStatus" boolean,
    "InterbranchDate" timestamp with time zone,
    "IsPendingCommisioning" boolean,
    "CommisioningStatus" integer,
    "CautionCounter" varchar(50),
    "DeliveryDate" timestamp with time zone,
    "LastLocationDate" timestamp with time zone,
    "TransmitStatus" varchar(50),
    "MeasuringPoint" varchar(18),
    "MeasuringDocument" varchar(25),
    "ManufacturePartNumber" varchar(100),
    "ManufactureSerialNumber" varchar(100),
    "SystemStatus" varchar(40),
    "UnitStatus" varchar(40),
    "IsAvailable" boolean NOT NULL,
    "KomtraxMeterReading" double precision,
    "KomtraxMeterReadingDate" timestamp with time zone,
    "ContractPackage" varchar(40),
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_Equipments" PRIMARY KEY ("Id")
);

CREATE TABLE "MessageBroker" (
    "Id" uuid NOT NULL,
    "Topic" varchar(50),
    "Message" text,
    "StoredDate" Timestamp,
    "IsSend" bool NOT NULL,
    "Acknowledged" bool NOT NULL,
    CONSTRAINT "PK_MessageBroker" PRIMARY KEY ("Id")
);

CREATE TABLE "MJobs" (
    "Id" uuid NOT NULL,
    "ParentId" uuid,
    "IsParent" boolean NOT NULL,
    "JobType" varchar(20),
    "Desc" varchar(50),
    "Sequence" serial,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_MJobs" PRIMARY KEY ("Id")
);

CREATE TABLE "MSector" (
    "Id" uuid NOT NULL,
    "Sector" varchar(50),
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_MSector" PRIMARY KEY ("Id")
);

CREATE TABLE "ReceivedMessageBroker" (
    "Id" uuid NOT NULL,
    "Topic" varchar(50),
    "Message" text,
    "Error" text,
    "TimeIn" timestamp NOT NULL,
    "Offset" bigint NOT NULL,
    "Partition" int NOT NULL,
    "Status" int,
    "InnerMessage" text,
    "StackTrace" text,
    "TimeProcess" timestamp,
    "TimeFinish" timestamp,
    CONSTRAINT "PK_ReceivedMessageBroker" PRIMARY KEY ("Id")
);

CREATE TABLE "Jobs" (
    "Id" uuid NOT NULL,
    "CustomerId" uuid,
    "Number" varchar(12) NOT NULL,
    "Status" varchar(50),
    "PlantArea" varchar(250),
    "Latitude" char(18),
    "Longitude" char(18),
    "PlanExecutionDate" timestamp with time zone,
    "DownTimeStartDate" timestamp with time zone,
    "DownTimeEndDate" timestamp with time zone,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_Jobs" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Jobs_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE SET NULL
);

CREATE TABLE "AdditionalJobs" (
    "Id" uuid NOT NULL,
    "JobId" uuid,
    "Desc" varchar(50) NOT NULL,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_AdditionalJobs" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AdditionalJobs_Jobs_JobId" FOREIGN KEY ("JobId") REFERENCES "Jobs" ("Id") ON DELETE SET NULL
);

CREATE TABLE "ChecksheetValue" (
    "Id" uuid NOT NULL,
    "JobId" uuid,
    "Sector" varchar(50),
    "MaterialNumber" varchar(100),
    "Parameter" varchar(100),
    "AssessmentArea" varchar(250),
    "UnitApplication" varchar(100),
    "Klausul" varchar(5),
    "Description" varchar(250),
    "OperationStandard" varchar[] NOT NULL DEFAULT ARRAY[]::varchar[],
    "Guidance" varchar[] NOT NULL DEFAULT ARRAY[]::varchar[],
    "Score" integer[] DEFAULT ARRAY[]::integer[],
    "Weight" real NOT NULL,
    "FinalScore" real[] DEFAULT ARRAY[]::real[],
    "Comment" varchar(250),
    "Recommendation" varchar(250),
    "Image" text,
    "LinkVideo" varchar(250),
    "Sequence" integer NOT NULL,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_ChecksheetValue" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ChecksheetValue_Jobs_JobId" FOREIGN KEY ("JobId") REFERENCES "Jobs" ("Id") ON DELETE SET NULL
);

CREATE TABLE "EquipmentIdentities" (
    "Id" uuid NOT NULL,
    "JobId" uuid,
    "EquipmentId" uuid,
    "IsProductUT" boolean NOT NULL,
    "CustomerOperator" varchar(100),
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_EquipmentIdentities" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_EquipmentIdentities_Equipments_EquipmentId" FOREIGN KEY ("EquipmentId") REFERENCES "Equipments" ("Id") ON DELETE SET NULL,
    CONSTRAINT "FK_EquipmentIdentities_Jobs_JobId" FOREIGN KEY ("JobId") REFERENCES "Jobs" ("Id") ON DELETE SET NULL
);

CREATE INDEX "IX_AdditionalJobs_IsActive" ON "AdditionalJobs" ("IsActive");

CREATE INDEX "IX_AdditionalJobs_JobId" ON "AdditionalJobs" ("JobId");

CREATE INDEX "IX_ChecksheetMaster_IsActive" ON "ChecksheetMaster" ("IsActive");

CREATE UNIQUE INDEX "IX_ChecksheetMaster_Sector_Klausul_UnitApplication_Description" ON "ChecksheetMaster" ("Sector", "Klausul", "UnitApplication", "Description");

CREATE INDEX "IX_ChecksheetValue_IsActive" ON "ChecksheetValue" ("IsActive");

CREATE INDEX "IX_ChecksheetValue_JobId" ON "ChecksheetValue" ("JobId");

CREATE UNIQUE INDEX "IX_ChecksheetValue_Sector_Klausul_JobId_UnitApplication_Descri~" ON "ChecksheetValue" ("Sector", "Klausul", "JobId", "UnitApplication", "Description");

CREATE INDEX "IX_Customers_IsActive" ON "Customers" ("IsActive");

CREATE INDEX "IX_EquipmentIdentities_EquipmentId" ON "EquipmentIdentities" ("EquipmentId");

CREATE INDEX "IX_EquipmentIdentities_IsActive" ON "EquipmentIdentities" ("IsActive");

CREATE INDEX "IX_EquipmentIdentities_JobId" ON "EquipmentIdentities" ("JobId");

CREATE INDEX "IX_Equipments_EquipmentNumber" ON "Equipments" ("EquipmentNumber");

CREATE INDEX "IX_Equipments_IsActive" ON "Equipments" ("IsActive");

CREATE INDEX "IX_Equipments_WorkCenterCode" ON "Equipments" ("WorkCenterCode");

CREATE INDEX "IX_Jobs_CustomerId" ON "Jobs" ("CustomerId");

CREATE INDEX "IX_Jobs_IsActive" ON "Jobs" ("IsActive");

CREATE UNIQUE INDEX "IX_Jobs_Number" ON "Jobs" ("Number");

CREATE INDEX "IX_MJobs_IsActive" ON "MJobs" ("IsActive");

CREATE INDEX "IX_MJobs_Sequence" ON "MJobs" ("Sequence");

CREATE INDEX "IX_MSector_IsActive" ON "MSector" ("IsActive");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240801041918_Init', '8.0.5');

COMMIT;

