using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSCoip.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Changelogs",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Method = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                TableName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                KeyValues = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                NewValues = table.Column<string>(type: "text", nullable: true),
                OldValues = table.Column<string>(type: "text", nullable: true),
                ChangeBy = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                ChangeDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Changelogs", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MessageBroker",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Topic = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                Message = table.Column<string>(type: "text", nullable: true),
                StoredDate = table.Column<DateTime>(type: "Timestamp", nullable: true),
                IsSend = table.Column<bool>(type: "bool", nullable: false),
                Acknowledged = table.Column<bool>(type: "bool", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MessageBroker", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ReceivedMessageBroker",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Topic = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                Message = table.Column<string>(type: "text", nullable: true),
                Error = table.Column<string>(type: "text", nullable: true),
                TimeIn = table.Column<DateTime>(type: "timestamp", nullable: false),
                Offset = table.Column<long>(type: "bigint", nullable: false),
                Partition = table.Column<int>(type: "int", nullable: false),
                Status = table.Column<int>(type: "int", nullable: true),
                InnerMessage = table.Column<string>(type: "text", nullable: true),
                StackTrace = table.Column<string>(type: "text", nullable: true),
                TimeProcess = table.Column<DateTime>(type: "timestamp", nullable: true),
                TimeFinish = table.Column<DateTime>(type: "timestamp", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReceivedMessageBroker", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Changelogs");

        migrationBuilder.DropTable(
            name: "MessageBroker");

        migrationBuilder.DropTable(
            name: "ReceivedMessageBroker");
    }
}
