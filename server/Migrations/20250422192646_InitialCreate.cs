using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Organization = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.OrganizerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Organization = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPerson = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.SponsorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Organization = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Confirmeds",
                columns: table => new
                {
                    ConfirmationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmeds", x => x.ConfirmationId);
                    table.ForeignKey(
                        name: "FK_Confirmeds_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "OrganizerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ConfirmationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Confirmeds_ConfirmationId",
                        column: x => x.ConfirmationId,
                        principalTable: "Confirmeds",
                        principalColumn: "ConfirmationId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ConferenceId);
                    table.ForeignKey(
                        name: "FK_Conferences_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conferences_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "OrganizerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conferences_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conferences_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "SponsorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "ConferenceId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Spectators",
                columns: table => new
                {
                    SpectatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConferenceId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSpectators = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spectators", x => x.SpectatorId);
                    table.ForeignKey(
                        name: "FK_Spectators_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "ConferenceId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name", "Organization", "Surname" },
                values: new object[,]
                {
                    { 1, "Павел", "Telegram", "Дуров" },
                    { 2, "Марк", "Meta", "Цукерберг" },
                    { 3, "Сатья", "Microsoft", "Наделла" },
                    { 4, "Сундар", "Google", "Пичаи" },
                    { 5, "Тим", "Apple", "Кук" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "ул. Ленина, 1, Минск", "Конференц-зал 'Минск'" },
                    { 2, "пр. Победителей, 7, Минск", "Бизнес-центр 'Виктория'" },
                    { 3, "ул. Притыцкого, 156, Минск", "IT HUB 'Горизонт'" },
                    { 4, "ул. Сторожевская, 15, Минск", "Отель 'Беларусь'" },
                    { 5, "пр. Независимости, 65, Минск", "Технопарк" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "OrganizerId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Александр", "Иванов" },
                    { 2, "Елена", "Петрова" },
                    { 3, "Михаил", "Сидоров" },
                    { 4, "Анна", "Козлова" },
                    { 5, "Дмитрий", "Новиков" }
                });

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "SponsorId", "Amount", "ContactPerson", "Email", "Organization", "Phone" },
                values: new object[,]
                {
                    { 1, 10000m, "Иван Иванов", "microsoft.by@microsoft.com", "Microsoft Belarus", "+375291234567" },
                    { 2, 15000m, "Петр Петров", "epam.by@epam.com", "EPAM Systems", "+375292345678" },
                    { 3, 12000m, "Алексей Алексеев", "iba.by@iba.com", "IBA Group", "+375293456789" },
                    { 4, 20000m, "Сергей Сергеев", "wargaming.by@wargaming.com", "Wargaming", "+375294567890" },
                    { 5, 18000m, "Дмитрий Дмитриев", "itechart.by@itechart.com", "iTechArt Group", "+375295678901" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FirstName", "LastName", "MiddleName", "Organization", "PasswordHash", "PhoneNumber", "Position", "Role" },
                values: new object[,]
                {
                    { 1, "Адрес администратора", new DateTime(2025, 4, 22, 19, 26, 45, 761, DateTimeKind.Utc).AddTicks(6043), "admin@example.com", "Администратор", "Системы", "Администраторович", "Система", "AQAAAAEAACcQAAAAELbGq7cGxQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQ==", "+375291234567", "Администратор", "Admin" },
                    { 2, "Тестовый адрес", new DateTime(2025, 4, 22, 19, 26, 45, 761, DateTimeKind.Utc).AddTicks(6046), "test@example.com", "Тестовый", "Пользователь", "Тестович", "Тестовая организация", "AQAAAAEAACcQAAAAELbGq7cGxQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQZQ==", "+375297654321", "Тестировщик", "User" }
                });

            migrationBuilder.InsertData(
                table: "Confirmeds",
                columns: new[] { "ConfirmationId", "Date", "OrganizerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "AuthorId", "ConfirmationId", "Description" },
                values: new object[,]
                {
                    { 1, 1, 1, "Будущее мессенджеров и приватности" },
                    { 2, 2, 2, "Метавселенная: новая эра интернета" },
                    { 3, 3, 3, "Облачные технологии в 2024" },
                    { 4, 4, 4, "Искусственный интеллект в поиске" },
                    { 5, 5, 5, "Экосистема Apple и приватность" }
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ConferenceId", "LocationId", "Name", "OrganizerId", "ReportId", "SponsorId" },
                values: new object[,]
                {
                    { 1, 1, "Telegram Conference 2024", 1, 1, 1 },
                    { 2, 2, "Meta Connect Belarus", 2, 2, 2 },
                    { 3, 3, "Microsoft Tech Summit", 3, 3, 3 },
                    { 4, 4, "Google Cloud Next", 4, 4, 4 },
                    { 5, 5, "Apple Developer Day", 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "MessageId", "ConferenceId", "Message", "Time", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Когда начнется регистрация?", new DateTime(2024, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, "Будет ли онлайн трансляция?", new DateTime(2024, 3, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, "Где можно получить материалы конференции?", new DateTime(2024, 3, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, "Какие темы будут обсуждаться?", new DateTime(2024, 3, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, "Нужна ли предварительная регистрация?", new DateTime(2024, 3, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Spectators",
                columns: new[] { "SpectatorId", "ConferenceId", "NumberOfSpectators" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 2, 2, 150 },
                    { 3, 3, 200 },
                    { 4, 4, 175 },
                    { 5, 5, 125 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ConferenceId",
                table: "ChatMessages",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_LocationId",
                table: "Conferences",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_OrganizerId",
                table: "Conferences",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_ReportId",
                table: "Conferences",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_SponsorId",
                table: "Conferences",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmeds_OrganizerId",
                table: "Confirmeds",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AuthorId",
                table: "Reports",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ConfirmationId",
                table: "Reports",
                column: "ConfirmationId");

            migrationBuilder.CreateIndex(
                name: "IX_Spectators_ConferenceId",
                table: "Spectators",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Spectators");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Confirmeds");

            migrationBuilder.DropTable(
                name: "Organizers");
        }
    }
}
