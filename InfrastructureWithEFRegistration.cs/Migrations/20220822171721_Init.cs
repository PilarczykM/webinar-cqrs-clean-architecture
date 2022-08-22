using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureWithEFRegistration.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Webinars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookEventUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlidesUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchFacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WatchYoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlreadyHappend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webinars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "DisplayName", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#", null, null, "CSharp" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET", null, null, "aspnet" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Triki z Windows", null, null, "triki-z-windows" },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Docker", null, null, "docker" },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filozofia", null, null, "filozofia" }
                });

            migrationBuilder.InsertData(
                table: "Webinars",
                columns: new[] { "Id", "AlreadyHappend", "Date", "Description", "FacebookEventUrl", "ImageUrl", "SlidesUrl", "Title", "WatchFacebookLink", "WatchYoutubeLink" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2022, 9, 1, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7520), "Ustalenie architektury nie jest prostym zadaniem. Każda decyzja może mieć wielkie komplikacje potem.", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg", "", "Aplikacja C# od Zera Architektura, CQRS, Dobre praktyki", "", "" },
                    { 2, false, new DateTime(2022, 7, 13, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7527), "Kontenery są tutaj. Kubernetes jest de facto platformą do ich uruchamiania i zarządzania.", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg", "https://panniebieski.github.io/webinar-Kubernetes-Docker-Wytlumacz-mi-i-pokaz/", "Kubernetes i Docker : Wytłumacz mi i pokaż", "https://www.facebook.com/watch/live/?v=2775230679405348&ref=watch_permalink", "https://www.youtube.com/watch?v=7g00wOg9Jto" },
                    { 3, false, new DateTime(2022, 6, 23, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7530), "Jak utworzyć projekt w .NET 5?", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/15_csharpirekordy.jpg", "https://panniebieski.github.io/webinar_CSharp9-Rekordy-i-duze-zamiany-w-net-5/", "C# 9, Rekordy i duże zmiany w .NET 5", "https://www.facebook.com/watch/live/?v=2835303250091399&ref=watch_permalink", "https://www.youtube.com/watch?v=ATbLEyd_1Kg" },
                    { 4, false, new DateTime(2022, 6, 13, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7533), "Czasami jedyne czego potrzebujemy to dobrego przykładu.", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/15_csharpirekordy.jpg", "https://panniebieski.github.io/webinar_CSharp9-Rekordy-i-duze-zamiany-w-net-5/", "Szybki Trening Sql Server 2", "https://www.facebook.com/watch/live/?v=2835303250091399&ref=watch_permalink", "https://www.youtube.com/watch?v=ATbLEyd_1Kg" },
                    { 5, false, new DateTime(2022, 5, 24, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7537), "Jak wygląda szukanie pracy jako programista w 2020 roku? Czy jest lepiej, czy jest gorzej?", "https://www.facebook.com/events/407358067213893/", "https://cezarywalenciuk.pl/posts/fileswebinars/15_csharpirekordy.jpg", "https://panniebieski.github.io/webinar_CSharp9-Rekordy-i-duze-zamiany-w-net-5/", "Pytania rekrutacyjne czyli dalsza kariera", "https://www.facebook.com/watch/live/?v=2835303250091399&ref=watch_permalink", "https://www.youtube.com/watch?v=ATbLEyd_1Kg" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Date", "Description", "ImageUrl", "Rate", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Damian", 2, new DateTime(2022, 2, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7378), "Nasze aplikacje ASP.NET CORE coraz częściej są tylko aplikacją REST. To oczywiście wymaga Walidacji po stronie klienta i po stronie serwera\r\nJak taką walidację jak najszybciej zrobić.Może przecież sam napisać takie warunki,\r\n                ale przy dużej ilości klas,\r\n                które występują jako parametry mija się to z celem.\r\nMożesz też skorzystać z atrybutów i oznaczyć reguły do każdej właściwości.", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 8, "Walidacja z FluentValidation w ASP.NET Core + Swagger", "https://cezarywalenciuk.pl/blog/programing/walidacja-z-fluentvalidation-waspnet-core--swagger" },
                    { 2, "Damian", 2, new DateTime(2022, 2, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7420), "Programiści codziennie tworzą jakąś aplikację sieciową typu REST. Teraz nastaje pytanie, jak najlepiej zrozumieć jak dane API działa. Do tego mamy dokumentacje, ale jeśli pracujesz w szybkich, zamkniętych projektach to takiej dokumentacji może nie być.", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 7, "Swagger UI : Dokumentowanie API w ASP.NET CORE", "https://cezarywalenciuk.pl/blog/programing/swagger-ui--dokumentowanie-api-w-aspnet-core" },
                    { 3, "Stefan", 5, new DateTime(2021, 8, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7422), "W pod koniec roku 2017 zacząłem ćwiczyć. Proste ćwiczenia rzeczywiście robią różnice, gdy masz siedzący tryb życia. A co z bieganiem ?\r\nPamiętam jak pierwszy raz na bieżni nie byłem w stanie wytrzymać 5 minut normalnego spaceru. Powoli z tygodnia na dzień zacząłem sobie stawiać wyższe progi i tak odkryłem, że o ile jest to na początku bolesne to jak twoje ciało da Ci te endorfiny to już...aż chce się biegać więcej. ", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 5, "Bieganie jak się do tego zmotywować : Zdrowie Programisty", "https://cezarywalenciuk.pl/blog/programing/bieganie-jak-sie-do-tego-zmotywowac--zdrowie-programisty" },
                    { 4, "Damian", 2, new DateTime(2021, 8, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7425), "Logowanie działania aplikacji. Jak wiedzieć w końcu, gdy coś nie działa. Mój blog jest napisany w C# i działa po ASP.NET CORE. Jak to jednak bywa z napisaną przez siebie aplikacją pojawiają się błędy więc do bloga dodałem mechanizm logowania błędów. W taki sposób znalazłem wiele dziwnych przypadków uszkodzonych wpisów w formacie XML, które rozwalały Parser. Znalazłem też złe zbudowane przez ze mnie lista kursów. ", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 5, "NLog z ASP.NET Core : Logowanie błędów w aplikacji", "https://cezarywalenciuk.pl/blog/programing/nlog-z-aspnet-core--logowanie-b%C5%82edow-w-aplikacji" },
                    { 5, "Damian", 2, new DateTime(2021, 8, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7428), "Logowanie działania aplikacji. Jak wiedzieć w końcu, gdy coś nie działa. Mój blog jest napisany w C# i działa po ASP.NET CORE. Jak to jednak bywa z napisaną przez siebie aplikacją pojawiają się błędy więc do bloga dodałem mechanizm logowania błędów. W taki sposób znalazłem wiele dziwnych przypadków uszkodzonych wpisów w formacie XML, które rozwalały Parser. Znalazłem też złe zbudowane przez ze mnie lista kursów. ", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 5, "NLog z ASP.NET Core : Logowanie błędów w aplikacji", "https://cezarywalenciuk.pl/blog/programing/nlog-z-aspnet-core--logowanie-b%C5%82edow-w-aplikacji" },
                    { 6, "Damian", 2, new DateTime(2021, 12, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7431), "W tym  artykule zobaczymy jak zintegrować AutoMapper  z ASP.NET CORE dla .NET 5, chociaż bądźmy szczerzy możesz skorzystać z tej biblioteki w każdym projekcie w C#.", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 9, "AutoMapper z ASP.NET CORE czyli mapowanie klas", "https://cezarywalenciuk.pl/blog/programing/automapper-z-aspnet-core" },
                    { 7, "Adrian", 3, new DateTime(2021, 6, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7434), "Nagrywanie Gif - ów ? Robienie obrazków na bloga ? Jak to robić jeszcze szybciej ? ", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 4, "ShareX : Lepszy PrintScreen oraz robienie Gif-ów twojego pulpitu?", "https://cezarywalenciuk.pl/blog/programing/sharex-lepszy-printscreen-oraz-robienie-gif-ow" },
                    { 8, "Adrian", 3, new DateTime(2021, 5, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7436), "Jak jeszcze lepiej ulepszyć system operacyjny Windows.\r\nCzy być może programy tobie, które za chwilę to śmieci, które nie będą ci potrzebne?\r\nZazwyczaj w tym cyklu pokazuje programy, z które moim bardzo zmieniają przepływ mojej pracy.", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 5, "QuickLook, TeraCopy, ProcessExplorer czy to potrzebne jest ?", "https://cezarywalenciuk.pl/blog/programing/sharex-lepszy-printscreen-oraz-robienie-gif-ow" },
                    { 9, "Adrian", 4, new DateTime(2021, 5, 22, 19, 17, 21, 501, DateTimeKind.Local).AddTicks(7439), "Jak jeszcze lepiej ulepszyć system operacyjny Windows.\r\nCzy być może programy tobie, które za chwilę to śmieci, które nie będą ci potrzebne?\r\nZazwyczaj w tym cyklu pokazuje programy, z które moim bardzo zmieniają przepływ mojej pracy.", "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png", 9, "Docker File dla Go, ASP.NET Core, .NET 5, Java Spring, NodeJS, Python", "https://cezarywalenciuk.pl/blog/programing/docker-file-dla-go-aspnet-core-net-5-java-spring-nodejs-python" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Webinars");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
