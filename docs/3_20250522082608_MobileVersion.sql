START TRANSACTION;

CREATE TABLE "MobileVersion" (
    "Id" uuid NOT NULL,
    "Version" varchar(100) NOT NULL,
    "Environment" varchar(100) NOT NULL,
    "Sequence" integer NOT NULL,
    "CreatedBy" varchar(150),
    "CreatedDate" timestamp with time zone DEFAULT (now()),
    "UpdatedBy" varchar(150),
    "UpdatedDate" timestamp with time zone DEFAULT (now()),
    "IsActive" bool DEFAULT TRUE,
    CONSTRAINT "PK_MobileVersion" PRIMARY KEY ("Id")
);

CREATE INDEX "IX_MobileVersion_IsActive" ON "MobileVersion" ("IsActive");

CREATE INDEX "IX_MobileVersion_Sequence" ON "MobileVersion" ("Sequence");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250507042028_NewTableMobileVersion', '8.0.5');

COMMIT;

START TRANSACTION;

ALTER TABLE "MobileVersion" ALTER COLUMN "Environment" DROP NOT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250515035528_RemoveIsRequiredFromEnvironmentMobileVersion', '8.0.5');

COMMIT;

