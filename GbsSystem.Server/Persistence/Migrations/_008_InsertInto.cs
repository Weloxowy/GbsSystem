using FluentMigrator;

namespace GbsSystem.Server.Persistence.Migrations;
[Migration(008)] 
public class _008_InsertInto : Migration
{
    public override void Up()
        {
            // Wstawianie 10 rekordów do tabeli Questions
            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Jaka planeta jest druga od Słońca?",
                AnswerBad1 = "Mars",
                AnswerBad2 = "Jowisz",
                AnswerBad3 = "Ziemia",
                GoodAnswer = "Wenus",
                Points = 1,
                Level = 1,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Co pokrywa powierzchnię Wenus?",
                AnswerBad1 = "Woda",
                AnswerBad2 = "Piasek",
                AnswerBad3 = "Lód",
                GoodAnswer = "Grube chmury z kwasu siarkowego",
                Points = 1,
                Level = 1,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Jakie ciśnienie panuje na Wenus w porównaniu z Ziemią?",
                AnswerBad1 = "Jest takie samo",
                AnswerBad2 = "Jest mniejsze",
                AnswerBad3 = "Nie ma tam ciśnienia",
                GoodAnswer = "Jest 90 razy większe",
                Points = 1,
                Level = 1,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Dlaczego Wenus jest nazywana 'Gwiazdą Poranną' lub 'Gwiazdą Wieczorną'?",
                AnswerBad1 = "Ma dużo wulkanów",
                AnswerBad2 = "Ma grubą atmosferę",
                AnswerBad3 = "Krąży wokół Księżyca",
                GoodAnswer = "Jest bardzo jasna i często widoczna na niebie",
                Points = 1,
                Level = 1,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Z czego składają się chmury na Wenus?",
                AnswerBad1 = "Z wody",
                AnswerBad2 = "Z lodu",
                AnswerBad3 = "Z pyłu kosmicznego",
                GoodAnswer = "Z kwasu siarkowego",
                Points = 1,
                Level = 2,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Jakie są warunki na powierzchni Wenus?",
                AnswerBad1 = "Bardzo zimne i ciemne",
                AnswerBad2 = "Łagodne, jak na Ziemi",
                AnswerBad3 = "Wilgotne i deszczowe",
                GoodAnswer = "Gorące z ogromnym ciśnieniem",
                Points = 1,
                Level = 2,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Co znajduje się na powierzchni Wenus?",
                AnswerBad1 = "Morza i oceany",
                AnswerBad2 = "Trawy i lasy",
                AnswerBad3 = "Lodowe pustynie",
                GoodAnswer = "Wulkany, góry i skały",
                Points = 1,
                Level = 3,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Dlaczego ludzie nie mogą żyć na Wenus?",
                AnswerBad1 = "Brakuje tam wody",
                AnswerBad2 = "Planeta jest zbyt daleko od Ziemi",
                AnswerBad3 = "Ma za dużo księżyców",
                GoodAnswer = "Panuje tam zbyt wysokie ciśnienie i temperatura",
                Points = 1,
                Level = 4,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Jaką planetę można porównać rozmiarami do Wenus?",
                AnswerBad1 = "Jowisz",
                AnswerBad2 = "Mars",
                AnswerBad3 = "Saturn",
                GoodAnswer = "Ziemia",
                Points = 1,
                Level = 5,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });

            Insert.IntoTable("Questions").Row(new
            {
                Id = Guid.NewGuid(),
                Question = "Jakiego rodzaju aktywność występuje na Wenus?",
                AnswerBad1 = "Częste trzęsienia ziemi",
                AnswerBad2 = "Burze piaskowe",
                AnswerBad3 = "Opady śniegu",
                GoodAnswer = "Aktywność wulkaniczna",
                Points = 1,
                Level = 6,
                PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470")
            });
        }

        public override void Down()
        {
            // Usuwanie rekordów, jeśli migracja zostanie cofnięta
            Delete.FromTable("Questions").Row(new { PlanetId = Guid.Parse("37BA7C78-B676-4F72-A13F-3504FC632470") });
        }
}