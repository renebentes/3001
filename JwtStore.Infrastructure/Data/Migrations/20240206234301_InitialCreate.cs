using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtStore.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "User",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Email_Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                Email_Verification_Code = table.Column<string>(type: "CHAR(6)", maxLength: 6, nullable: false),
                Email_Verification_ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                Email_Verification_VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                Image = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                Name = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                Password_Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Password_ResetCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_User", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "User");
    }
}
