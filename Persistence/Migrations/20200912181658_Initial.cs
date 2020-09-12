using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AppUsers",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					UserName = table.Column<string>(nullable: true),
					NormalizedUserName = table.Column<string>(nullable: true),
					Email = table.Column<string>(nullable: true),
					NormalizedEmail = table.Column<string>(nullable: true),
					EmailConfirmed = table.Column<bool>(nullable: false),
					PasswordHash = table.Column<string>(nullable: true),
					SecurityStamp = table.Column<string>(nullable: true),
					ConcurrencyStamp = table.Column<string>(nullable: true),
					PhoneNumber = table.Column<string>(nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(nullable: false),
					TwoFactorEnabled = table.Column<bool>(nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
					LockoutEnabled = table.Column<bool>(nullable: false),
					AccessFailedCount = table.Column<int>(nullable: false),
					DisplayName = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AppUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Leagues",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true),
					Country = table.Column<string>(nullable: true),
					CountryCode = table.Column<string>(nullable: true),
					SeasonStart = table.Column<DateTime>(nullable: false),
					SeasonEnd = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Leagues", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "UserLeagues",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					AppUserId = table.Column<string>(nullable: true),
					LeagueId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserLeagues", x => x.Id);
					table.ForeignKey(
						name: "FK_UserLeagues_AppUsers_AppUserId",
						column: x => x.AppUserId,
						principalTable: "AppUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_UserLeagues_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_UserLeagues_AppUserId",
				table: "UserLeagues",
				column: "AppUserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserLeagues_LeagueId",
				table: "UserLeagues",
				column: "LeagueId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "UserLeagues");

			migrationBuilder.DropTable(
				name: "AppUsers");

			migrationBuilder.DropTable(
				name: "Leagues");
		}
	}
}