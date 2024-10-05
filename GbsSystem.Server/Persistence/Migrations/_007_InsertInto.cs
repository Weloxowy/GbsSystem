using FluentMigrator;

namespace GbsSystem.Server.Persistence.Migrations;
[Migration(007)]
public class _007_InsertInto : Migration
{
    public override void Up()
    {
        // Insert Questions for Mercury
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego temperatura na Merkurym tak bardzo różni się między dniem a nocą?",
    AnswerBad1 = "Merkury ma bardzo grubą atmosferę, która absorbuje energię słoneczną w ciągu dnia i uwalnia ją w nocy.",
    AnswerBad2 = "Merkury znajduje się bardzo daleko od Słońca, co powoduje ekstremalne spadki temperatury w nocy.",
    AnswerBad3 = "Merkury posiada gęstą atmosferę, która utrzymuje ciepło.",
    GoodAnswer = "Merkury nie posiada prawie żadnej atmosfery, która mogłaby utrzymywać ciepło, stąd duże różnice temperatur.",
    Points = 5,
    Level = 1,
    PlanetId = new Guid("66E99E19-F227-4BB4-9756-E007123325F7") // Mercury
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jakie cechy powierzchni Merkurego przypominają Księżyc?",
    AnswerBad1 = "Merkury ma duże oceany ciekłej wody, jak Księżyc.",
    AnswerBad2 = "Merkury jest pokryty grubą warstwą lodu, co jest cechą wspólną z Księżycem.",
    AnswerBad3 = "Merkury ma atmosferę podobną do Księżyca.",
    GoodAnswer = "Powierzchnia Merkurego jest gęsto usiana kraterami, podobnie jak Księżyc.",
    Points = 3,
    Level = 1,
    PlanetId = new Guid("66E99E19-F227-4BB4-9756-E007123325F7") // Mercury
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Co jest głównym składnikiem jądra Merkurego, które sprawia, że planeta jest tak gęsta?",
    AnswerBad1 = "Jądro Merkurego składa się głównie z wodoru i helu.",
    AnswerBad2 = "Jądro Merkurego zbudowane jest głównie z tlenu i azotu.",
    AnswerBad3 = "Jądro Merkurego zbudowane jest głównie z krzemu i siarki.",
    GoodAnswer = "Jądro Merkurego składa się głównie z żelaza i niklu.",
    Points = 4,
    Level = 1,
    PlanetId = new Guid("66E99E19-F227-4BB4-9756-E007123325F7") // Mercury
});

// Insert Questions for Venus
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Co sprawia, że Wenus jest najgorętszą planetą w Układzie Słonecznym?",
    AnswerBad1 = "Wenus znajduje się najbliżej Słońca, co czyni ją najgorętszą planetą.",
    AnswerBad2 = "Wenus ma najcieplejsze jądro spośród wszystkich planet, które ogrzewa jej atmosferę.",
    AnswerBad3 = "Wenus ma bardzo cienką atmosferę, która nie zatrzymuje ciepła.",
    GoodAnswer = "Wenus ma gęstą atmosferę złożoną głównie z dwutlenku węgla, co powoduje silny efekt cieplarniany.",
    Points = 5,
    Level = 2,
    PlanetId = new Guid("37BA7C78-B676-4F72-A13F-3504FC632470") // Venus
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego Wenus ma tak długi dzień, który trwa dłużej niż jej rok?",
    AnswerBad1 = "Wenus porusza się po swojej orbicie bardzo szybko, co skraca jej rok.",
    AnswerBad2 = "Wenus ma dodatkowy ruch obrotowy wsteczny, który spowalnia jej obieg wokół Słońca.",
    AnswerBad3 = "Wenus rotuje bardzo szybko, co skraca jej dzień.",
    GoodAnswer = "Wenus obraca się wokół własnej osi bardzo wolno, co wydłuża jej dzień.",
    Points = 3,
    Level = 2,
    PlanetId = new Guid("37BA7C78-B676-4F72-A13F-3504FC632470") // Venus
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jakie misje kosmiczne przyczyniły się do poznania powierzchni Wenus?",
    AnswerBad1 = "Apollo 11 była pierwszą misją, która wylądowała na Wenus.",
    AnswerBad2 = "Voyager 1 zbadał powierzchnię Wenus przy pomocy radarów.",
    AnswerBad3 = "Hubble dostarczył pierwsze obrazy Wenus.",
    GoodAnswer = "Misja Magellan oraz radzieckie misje Venera dostarczyły szczegółowych danych o Wenus.",
    Points = 5,
    Level = 2,
    PlanetId = new Guid("37BA7C78-B676-4F72-A13F-3504FC632470") // Venus
});

// Insert Questions for Earth
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "W jaki sposób warstwa ozonowa chroni życie na Ziemi?",
    AnswerBad1 = "Warstwa ozonowa pochłania promieniowanie podczerwone, co zapobiega zamarzaniu atmosfery Ziemi.",
    AnswerBad2 = "Warstwa ozonowa tworzy barierę chroniącą przed wiatrem słonecznym.",
    AnswerBad3 = "Warstwa ozonowa przyciąga promieniowanie z kosmosu, które ogrzewa Ziemię.",
    GoodAnswer = "Warstwa ozonowa pochłania szkodliwe promieniowanie ultrafioletowe (UV) ze Słońca.",
    Points = 4,
    Level = 1,
    PlanetId = new Guid("9A5EE023-88B8-4587-A063-22675DF6E30A") // Earth
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jak ruchy płyt tektonicznych wpływają na krajobraz Ziemi?",
    AnswerBad1 = "Płyty tektoniczne poruszają się tylko na oceanach, powodując powstawanie głębokich rowów.",
    AnswerBad2 = "Ruchy płyt tektonicznych są bezpośrednią przyczyną zanikania atmosfery Ziemi.",
    AnswerBad3 = "Ruchy płyt tektonicznych nie mają wpływu na krajobraz Ziemi.",
    GoodAnswer = "Ruchy płyt tektonicznych powodują powstawanie gór, trzęsienia ziemi i erupcje wulkanów.",
    Points = 5,
    Level = 2,
    PlanetId = new Guid("9A5EE023-88B8-4587-A063-22675DF6E30A") // Earth
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jakie znaczenie ma Księżyc dla stabilności osi obrotu Ziemi i powstawania pór roku?",
    AnswerBad1 = "Księżyc nie ma wpływu na oś obrotu Ziemi; pory roku są wynikiem wiatru słonecznego.",
    AnswerBad2 = "Księżyc przyciąga Ziemię, co powoduje sezonowe zmiany klimatu.",
    AnswerBad3 = "Księżyc przyspiesza rotację Ziemi, co wpływa na długość dnia.",
    GoodAnswer = "Księżyc stabilizuje oś obrotu Ziemi, co zapobiega dużym wahaniom i zapewnia stabilne pory roku.",
    Points = 4,
    Level = 2,
    PlanetId = new Guid("9A5EE023-88B8-4587-A063-22675DF6E30A") // Earth
});

// Insert Questions for Mars
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Co sprawia, że Mars jest nazywany Czerwoną Planetą?",
    AnswerBad1 = "Mars ma bogatą atmosferę tlenową, która powoduje rozproszenie czerwonego światła.",
    AnswerBad2 = "Mars posiada rozległe pola lawy, która jest widoczna jako czerwona powierzchnia.",
    AnswerBad3 = "Mars posiada czerwony księżyc, który nadaje planecie jej nazwę.",
    GoodAnswer = "Tlenki żelaza na powierzchni Marsa nadają mu charakterystyczny czerwony kolor.",
    Points = 3,
    Level = 1,
    PlanetId = new Guid("55025DC4-8E74-497F-93AB-F2CD877A3D5C") // Mars
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jakie dowody sugerują, że na Marsie mogła istnieć woda w stanie ciekłym?",
    AnswerBad1 = "Mars posiada atmosferę bogatą w parę wodną, która w przeszłości mogła tworzyć rzeki.",
    AnswerBad2 = "Mars posiada podziemne jeziora lawy, które mogły stopić lód na powierzchni.",
    AnswerBad3 = "Mars ma gęstą atmosferę, która podtrzymuje wodę w stanie ciekłym.",
    GoodAnswer = "Istnieją ślady starożytnych koryt rzek, delt i minerałów, które formują się w obecności wody.",
    Points = 5,
    Level = 2,
    PlanetId = new Guid("55025DC4-8E74-497F-93AB-F2CD877A3D5C") // Mars
});
// Insert Questions for Jupiter
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Co sprawia, że Wielka Czerwona Plama na Jowiszu jest tak niezwykła?",
    AnswerBad1 = "Jest to aktywny wulkan, który wyrzuca lawę.",
    AnswerBad2 = "Jest to ogromne jezioro ciekłego metanu.",
    AnswerBad3 = "To zamarznięte pole lodowe na biegunie Jowisza.",
    GoodAnswer = "Wielka Czerwona Plama to ogromna burza, która trwa od setek lat.",
    Points = 5,
    Level = 3,
    PlanetId = new Guid("ADD29D0D-A3B8-4A19-9EAF-60F4BA6AB0DF") // Jupiter
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego Jowisz emituje więcej ciepła niż otrzymuje od Słońca?",
    AnswerBad1 = "Jowisz posiada wewnętrzny silnik jądrowy, który generuje ciepło.",
    AnswerBad2 = "Jowisz absorbuje promieniowanie kosmiczne, które ogrzewa jego atmosferę.",
    AnswerBad3 = "Jowisz ma wiele aktywnych wulkanów, które podgrzewają planetę.",
    GoodAnswer = "Jowisz emituje ciepło z powodu kurczenia się pod własnym ciężarem, co generuje energię cieplną.",
    Points = 4,
    Level = 3,
    PlanetId = new Guid("ADD29D0D-A3B8-4A19-9EAF-60F4BA6AB0DF") // Jupiter
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Ile księżyców posiada Jowisz?",
    AnswerBad1 = "5",
    AnswerBad2 = "12",
    AnswerBad3 = "31",
    GoodAnswer = "Jowisz ma ponad 79 znanych księżyców.",
    Points = 3,
    Level = 3,
    PlanetId = new Guid("ADD29D0D-A3B8-4A19-9EAF-60F4BA6AB0DF") // Jupiter
});

// Insert Questions for Saturn
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Z czego składają się pierścienie Saturna?",
    AnswerBad1 = "Pierścienie Saturna to ogromne pola magnetyczne.",
    AnswerBad2 = "Pierścienie Saturna składają się z płynnej lawy krążącej wokół planety.",
    AnswerBad3 = "Pierścienie są zbudowane z metanu i wodoru.",
    GoodAnswer = "Pierścienie Saturna są zbudowane z lodu, skał i pyłu.",
    Points = 4,
    Level = 3,
    PlanetId = new Guid("5BDE1564-4289-4688-8DCC-F54CE9D038EF") // Saturn
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego Tytan, księżyc Saturna, jest wyjątkowy?",
    AnswerBad1 = "Tytan jest największym księżycem w Układzie Słonecznym.",
    AnswerBad2 = "Tytan jest najjaśniejszym obiektem w Układzie Słonecznym.",
    AnswerBad3 = "Tytan ma aktywne wulkany, które wyrzucają lawę złożoną z ciekłego metanu.",
    GoodAnswer = "Tytan ma gęstą atmosferę i jeziora ciekłego metanu na powierzchni.",
    Points = 5,
    Level = 3,
    PlanetId = new Guid("5BDE1564-4289-4688-8DCC-F54CE9D038EF") // Saturn
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jakie zjawisko powoduje powstawanie heksagonalnego wzoru na biegunie północnym Saturna?",
    AnswerBad1 = "To formacja kraterów lodowych uformowanych przez meteoryty.",
    AnswerBad2 = "To struktura uformowana przez silne wiatry słoneczne.",
    AnswerBad3 = "To wyładowania atmosferyczne generujące spiralny wzór.",
    GoodAnswer = "To wynik fal stojących w atmosferze Saturna, które tworzą sześciokątny wir na biegunie.",
    Points = 4,
    Level = 3,
    PlanetId = new Guid("5BDE1564-4289-4688-8DCC-F54CE9D038EF") // Saturn
});

// Insert Questions for Uranus
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego Uran obraca się na boku w porównaniu do innych planet?",
    AnswerBad1 = "Uran jest przyciągany przez Jowisza, co powoduje, że przewrócił się na bok.",
    AnswerBad2 = "Uran jest znacznie cięższy od innych planet, co powoduje jego odmienną rotację.",
    AnswerBad3 = "Uran posiada gigantyczne księżyce, które destabilizują jego oś obrotu.",
    GoodAnswer = "Przypuszcza się, że Uran został uderzony przez duży obiekt, co przewróciło jego oś obrotu.",
    Points = 5,
    Level = 4,
    PlanetId = new Guid("17F11613-1F4A-4EA6-8A40-578EDB34F85B") // Uranus
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Z czego składają się głównie chmury na Uranie?",
    AnswerBad1 = "Chmury Urana składają się głównie z tlenku węgla i helu.",
    AnswerBad2 = "Chmury Urana są zbudowane z azotu i pary wodnej.",
    AnswerBad3 = "Chmury Urana są zbudowane z tlenu i pyłu kosmicznego.",
    GoodAnswer = "Chmury Urana składają się głównie z metanu, który nadaje planecie niebieskawy kolor.",
    Points = 3,
    Level = 4,
    PlanetId = new Guid("17F11613-1F4A-4EA6-8A40-578EDB34F85B") // Uranus
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego Uran ma tak zimną atmosferę, mimo że nie jest najdalszą planetą od Słońca?",
    AnswerBad1 = "Jest najcięższą planetą, co powoduje utratę ciepła.",
    AnswerBad2 = "Ma najcieńszą atmosferę, która nie zatrzymuje ciepła.",
    AnswerBad3 = "Jego pierścienie odbijają większość promieniowania słonecznego.",
    GoodAnswer = "Uran ma bardzo słabe źródło wewnętrznego ciepła, co czyni jego atmosferę wyjątkowo zimną.",
    Points = 4,
    Level = 4,
    PlanetId = new Guid("17F11613-1F4A-4EA6-8A40-578EDB34F85B") // Uranus
});

// Insert Questions for Neptune
Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Jakie jest najbardziej charakterystyczne zjawisko pogodowe na Neptunie?",
    AnswerBad1 = "Neptun ma ogromne wybuchy wulkaniczne, które dominują na powierzchni planety.",
    AnswerBad2 = "Neptun ma wiatry, które wieją z prędkością zaledwie kilku kilometrów na godzinę.",
    AnswerBad3 = "Neptun ma wiecznie spokojne i stabilne warunki pogodowe.",
    GoodAnswer = "Neptun ma najsilniejsze wiatry w Układzie Słonecznym, które mogą przekraczać 2000 km/h.",
    Points = 5,
    Level = 4,
    PlanetId = new Guid("C822526A-568A-49C9-A8C7-EDDA143E1D3F") // Neptune
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Dlaczego Neptun ma intensywnie niebieski kolor?",
    AnswerBad1 = "Neptun jest pokryty dużymi ilościami wody, co nadaje mu niebieski kolor.",
    AnswerBad2 = "Neptun ma atmosferę bogatą w tlen, co nadaje planecie niebieską barwę.",
    AnswerBad3 = "Neptun posiada ogromne morza złożone z ciekłego azotu.",
    GoodAnswer = "Metan w atmosferze Neptuna absorbuje czerwone światło, odbijając niebieskie.",
    Points = 4,
    Level = 4,
    PlanetId = new Guid("C822526A-568A-49C9-A8C7-EDDA143E1D3F") // Neptune
});

Insert.IntoTable("Questions").Row(new
{
    Id = Guid.NewGuid(),
    Question = "Który księżyc Neptuna jest najbardziej znany i dlaczego?",
    AnswerBad1 = "Nereida, ponieważ jest największym księżycem w Układzie Słonecznym.",
    AnswerBad2 = "Proteusz, ponieważ ma najszybszą rotację spośród wszystkich księżyców.",
    AnswerBad3 = "Galatea, ponieważ posiada własną atmosferę.",
    GoodAnswer = "Tryton, ponieważ krąży w kierunku przeciwnym do rotacji Neptuna i może być przechwyconym obiektem z Pasa Kuipera.",
    Points = 5,
    Level = 4,
    PlanetId = new Guid("C822526A-568A-49C9-A8C7-EDDA143E1D3F") // Neptune
});

    }

    public override void Down()
{
    // Delete Questions for Mercury
    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego temperatura na Merkurym tak bardzo różni się między dniem a nocą?"
    });
    
    Delete.FromTable("Questions").Row(new
    {
        Question = "Jakie cechy powierzchni Merkurego przypominają Księżyc?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Co jest głównym składnikiem jądra Merkurego, które sprawia, że planeta jest tak gęsta?"
    });

    // Delete Questions for Venus
    Delete.FromTable("Questions").Row(new
    {
        Question = "Co sprawia, że Wenus jest najgorętszą planetą w Układzie Słonecznym?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego Wenus ma tak długi dzień, który trwa dłużej niż jej rok?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Jakie misje kosmiczne przyczyniły się do poznania powierzchni Wenus?"
    });

    // Delete Questions for Earth
    Delete.FromTable("Questions").Row(new
    {
        Question = "W jaki sposób warstwa ozonowa chroni życie na Ziemi?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Jak ruchy płyt tektonicznych wpływają na krajobraz Ziemi?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Jakie znaczenie ma Księżyc dla stabilności osi obrotu Ziemi i powstawania pór roku?"
    });

    // Delete Questions for Mars
    Delete.FromTable("Questions").Row(new
    {
        Question = "Co sprawia, że Mars jest nazywany Czerwoną Planetą?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Jakie dowody sugerują, że na Marsie mogła istnieć woda w stanie ciekłym?"
    });

    // Delete Questions for Jupiter
    Delete.FromTable("Questions").Row(new
    {
        Question = "Co sprawia, że Wielka Czerwona Plama na Jowiszu jest tak niezwykła?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego Jowisz emituje więcej ciepła niż otrzymuje od Słońca?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Ile księżyców posiada Jowisz?"
    });

    // Delete Questions for Saturn
    Delete.FromTable("Questions").Row(new
    {
        Question = "Z czego składają się pierścienie Saturna?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego Tytan, księżyc Saturna, jest wyjątkowy?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Jakie zjawisko powoduje powstawanie heksagonalnego wzoru na biegunie północnym Saturna?"
    });

    // Delete Questions for Uranus
    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego Uran obraca się na boku w porównaniu do innych planet?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Z czego składają się głównie chmury na Uranie?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego Uran ma tak zimną atmosferę, mimo że nie jest najdalszą planetą od Słońca?"
    });

    // Delete Questions for Neptune
    Delete.FromTable("Questions").Row(new
    {
        Question = "Jakie jest najbardziej charakterystyczne zjawisko pogodowe na Neptunie?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Dlaczego Neptun ma intensywnie niebieski kolor?"
    });

    Delete.FromTable("Questions").Row(new
    {
        Question = "Który księżyc Neptuna jest najbardziej znany i dlaczego?"
    });
}

}