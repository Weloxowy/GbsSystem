namespace GbsSystem.Server.Persistence.Migrations;

using FluentMigrator;

[Migration(005)]
public class _005_IndertInto : Migration
{
     public override void Up()
    {
        // Wstawianie danych planet z długimi opisami
        Insert.IntoTable("Planets").Row(new
        {
            Id = "66E99E19-F227-4BB4-9756-E007123325F7",
            Name = "Mercury",
            Diameter = 4879.0,
            Description1 = "Mercury is the smallest planet in the Solar System and the closest to the Sun. It has a diameter of just 4,879 km, making it about 38% the size of Earth. Despite its small size, Mercury has a surprisingly large core composed of iron and nickel, which takes up about 85% of the planet’s radius. Mercury has virtually no atmosphere, as its proximity to the Sun means that any gases are easily stripped away by solar winds. This lack of atmosphere also causes extreme temperature fluctuations. During the day, temperatures can reach a scorching 430°C (800°F), while at night, they can drop to as low as -180°C (-290°F).",
            Description2 = "Mercury’s surface is heavily cratered and similar in appearance to Earth's moon. These craters are the result of impacts from meteoroids and comets over billions of years. One of the most notable features is the Caloris Basin, a massive impact crater that spans 1,550 km in diameter. Mercury also has long cliffs, or scarps, that were likely formed as the planet cooled and contracted over time. The planet has a very slow rotation, taking 59 Earth days to complete one full spin on its axis. However, its orbit around the Sun is much faster, taking only 88 Earth days to complete one revolution.",
            Description3 = "Mercury has no moons or rings. Its proximity to the Sun makes it difficult to observe from Earth without a telescope, and it is often only visible during twilight hours. Despite its small size, Mercury's dense iron core gives it a magnetic field, though much weaker than Earth's. This magnetic field helps shield the planet from some solar radiation, but Mercury still experiences a constant bombardment of solar wind particles. The planet's exploration has been limited, with NASA's Mariner 10 and MESSENGER missions providing the most detailed images and data to date.",
            Type = "Terrestrial"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = "37BA7C78-B676-4F72-A13F-3504FC632470",
            Name = "Venus",
            Diameter = 12104.0,
            Description1 = "Venus, the second planet from the Sun, is often called Earth's 'sister planet' because of their similar size and composition. However, the similarities end there. Venus has a thick, toxic atmosphere composed mainly of carbon dioxide, with clouds of sulfuric acid that trap heat and create a runaway greenhouse effect. As a result, Venus is the hottest planet in the Solar System, with surface temperatures that average around 465°C (869°F). The pressure on Venus’s surface is about 92 times that of Earth, similar to the pressure found a kilometer beneath Earth's oceans. This oppressive atmosphere makes Venus a hostile environment, with no liquid water and extreme volcanic activity.",
            Description2 = "Venus rotates in the opposite direction to most planets, a phenomenon known as retrograde rotation. It takes about 243 Earth days for Venus to complete one full rotation, making a day on Venus longer than its year, which lasts only 225 Earth days. Because of its slow rotation and thick atmosphere, Venus has little variation in temperature between its day and night sides. The planet's surface is relatively young, geologically speaking, with evidence of widespread volcanic activity. Most of Venus’s surface features are named after female figures from mythology, and its largest volcano, Maxwell Montes, is comparable in size to Earth's Mount Everest.",
            Description3 = "Venus has no moons or rings. Its brightness in the sky, often visible just before sunrise or just after sunset, has made it a prominent feature in human culture for millennia. The planet has been explored by numerous spacecraft, including NASA’s Magellan mission, which used radar to map 98% of Venus’s surface. Despite its harsh conditions, Venus continues to intrigue scientists, especially in the context of studying climate change and atmospheric evolution. Future missions may focus on the possibility of life in Venus's upper atmosphere, where conditions are less extreme than on the surface.",
            Type = "Terrestrial"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = "9A5EE023-88B8-4587-A063-22675DF6E30A",
            Name = "Earth",
            Diameter = 12742.0,
            Description1 = "Earth is the third planet from the Sun and the only known planet to support life. Its atmosphere is composed of 78% nitrogen, 21% oxygen, and trace amounts of other gases, including carbon dioxide, which helps regulate the planet's temperature through the greenhouse effect. Earth’s surface is 71% covered by water, and it is the only planet in the Solar System with liquid water at its surface. The planet’s moderate climate and magnetic field, generated by its molten iron core, provide protection from harmful solar radiation and cosmic rays. Earth’s atmosphere also contains an ozone layer that shields the surface from the Sun’s ultraviolet radiation.",
            Description2 = "Earth is divided into several layers: the inner core, outer core, mantle, and crust. The crust is broken into tectonic plates that move over time, causing earthquakes, volcanic activity, and the formation of mountains. Earth's biosphere, a complex and dynamic system, includes diverse ecosystems ranging from polar ice caps to tropical rainforests. It supports millions of species, including humans, who have dramatically altered the planet’s environment through deforestation, pollution, and climate change. Despite its fragility, Earth’s ecosystems have shown remarkable resilience, recovering from mass extinctions and other global catastrophes.",
            Description3 = "Earth has one natural satellite, the Moon, which stabilizes the planet’s axial tilt and contributes to the seasons. The Moon's gravitational pull also causes tides in Earth’s oceans. Humans have been fascinated by the Moon for millennia, and it remains the only celestial body beyond Earth that humans have visited. Earth’s position in the Solar System, within the so-called 'habitable zone,' allows for the right conditions to support life, making it unique among the known planets. As the human population continues to grow, the need for sustainable management of Earth’s resources becomes increasingly important.",
            Type = "Terrestrial"
        });

                Insert.IntoTable("Planets").Row(new
        {
            Id = "55025DC4-8E74-497F-93AB-F2CD877A3D5C",
            Name = "Mars",
            Diameter = 6779.0,
            Description1 = "Mars, known as the Red Planet, is the fourth planet from the Sun and the second smallest in the Solar System. It gets its reddish appearance from iron oxide, or rust, on its surface. Mars has a thin atmosphere composed mostly of carbon dioxide, with trace amounts of nitrogen and argon. Despite its thin atmosphere, Mars experiences weather phenomena, including dust storms, which can cover the entire planet. With surface temperatures ranging from -125°C (-195°F) at the poles to 20°C (68°F) at the equator during the day, Mars is much colder than Earth.",
            Description2 = "Mars has two moons, Phobos and Deimos, which are thought to be captured asteroids. The surface of Mars features the largest volcano in the Solar System, Olympus Mons, which stands about 22 km (13.6 miles) high, as well as a vast canyon system, Valles Marineris, that stretches over 4,000 km. Mars also shows evidence of ancient river valleys, lakes, and possibly oceans, suggesting that liquid water once existed on its surface. Although Mars is dry and barren today, scientists continue to search for signs of past or present microbial life on the planet.",
            Description3 = "Mars has been the target of many space exploration missions, including rovers such as NASA’s Curiosity and Perseverance, which are exploring the planet’s geology and climate. Mars is also a prime candidate for future human exploration, with several agencies and private companies planning missions. The discovery of water ice on Mars has fueled interest in the planet as a potential site for future human colonies. While the planet's environment is harsh, technologies are being developed to make it possible for humans to survive on Mars for extended periods.",
            Type = "Terrestrial"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = "ADD29D0D-A3B8-4A19-9EAF-60F4BA6AB0DF",
            Name = "Jupiter",
            Diameter = 139820.0,
            Description1 = "Jupiter is the largest planet in the Solar System, with a diameter of 139,820 km, more than 11 times that of Earth. Jupiter is a gas giant, composed mainly of hydrogen and helium, with no solid surface. Its most distinctive feature is the Great Red Spot, a massive storm that has been raging for centuries. Jupiter’s atmosphere is marked by bands of clouds and intense storms, and it emits more heat than it receives from the Sun, suggesting it has an internal heat source.",
            Description2 = "Jupiter has a total of 79 known moons, the four largest being the Galilean moons: Io, Europa, Ganymede, and Callisto. Ganymede is the largest moon in the Solar System, even larger than Mercury. Europa, one of the most intriguing moons, is thought to have a subsurface ocean beneath its icy crust, making it a potential candidate for harboring life. Jupiter’s powerful magnetic field is the strongest of any planet in the Solar System and creates massive radiation belts that pose a challenge for spacecraft.",
            Description3 = "Jupiter plays a significant role in protecting the inner planets from asteroid impacts, as its massive gravity often pulls in or deflects space debris. The planet has been explored by numerous spacecraft, including NASA’s Galileo orbiter and the ongoing Juno mission, which is providing new insights into the planet’s atmosphere and magnetosphere. Jupiter also has a faint ring system, composed mainly of dust particles from its moons. As a gas giant, Jupiter lacks a solid surface, but its atmospheric phenomena continue to fascinate scientists.",
            Type = "Gas Giant"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = "5BDE1564-4289-4688-8DCC-F54CE9D038EF",
            Name = "Saturn",
            Diameter = 116460.0,
            Description1 = "Saturn is the sixth planet from the Sun and the second largest in the Solar System, known for its extensive and stunning ring system. Like Jupiter, Saturn is a gas giant, primarily composed of hydrogen and helium, with no solid surface. Saturn's rings are made up of ice particles, rocky debris, and dust, ranging from tiny grains to objects several meters in size. The planet’s low density means that if a large enough body of water existed, Saturn would float.",
            Description2 = "Saturn has 83 confirmed moons, with Titan being the largest. Titan is the second-largest moon in the Solar System and the only moon with a thick atmosphere. Titan's atmosphere is rich in nitrogen and methane, and its surface has lakes of liquid methane and ethane, making it one of the most Earth-like bodies in the Solar System. Another intriguing moon is Enceladus, which has geysers of water vapor, suggesting the presence of a subsurface ocean that could potentially harbor life.",
            Description3 = "Saturn’s magnetic field is slightly weaker than Jupiter’s, but it still creates powerful auroras near the poles. The planet has been explored by several spacecraft, most notably NASA’s Cassini mission, which provided a wealth of information about Saturn, its rings, and moons. Saturn’s rings are believed to be relatively young and could be the remnants of a destroyed moon or comet. Despite its distance from the Sun, Saturn emits more heat than it receives, possibly due to the slow contraction of its atmosphere.",
            Type = "Gas Giant"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = "17F11613-1F4A-4EA6-8A40-578EDB34F85B",
            Name = "Uranus",
            Diameter = 50724.0,
            Description1 = "Uranus is the seventh planet from the Sun and is unique in the Solar System due to its extreme axial tilt, which causes the planet to rotate on its side. This unusual tilt results in extreme seasonal variations, with each pole experiencing 42 years of continuous sunlight followed by 42 years of darkness. Uranus is an ice giant, composed mainly of water, ammonia, and methane ices, along with hydrogen and helium. The methane in its atmosphere gives the planet its characteristic blue-green color.",
            Description2 = "Uranus has 27 known moons, the largest being Titania and Oberon. The planet also has a faint ring system, discovered in 1977, which is much less prominent than Saturn's. Uranus’s magnetic field is tilted at a significant angle to its rotational axis, and it is offset from the planet’s center. The planet’s cold atmosphere, with temperatures dropping as low as -224°C (-371°F), makes it the coldest planet in the Solar System.",
            Description3 = "Uranus has been visited by only one spacecraft, Voyager 2, which provided much of the information we have about the planet. Future missions are being considered to further explore Uranus and its moons, especially since the planet's extreme tilt and unusual magnetic field make it an intriguing object of study. Uranus’s slow orbit around the Sun takes 84 Earth years to complete, meaning that a single Uranian year is longer than a human lifetime.",
            Type = "Ice Giant"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = "C822526A-568A-49C9-A8C7-EDDA143E1D3F",
            Name = "Neptune",
            Diameter = 49244.0,
            Description1 = "Neptune is the eighth and farthest known planet from the Sun. It is similar to Uranus in composition and is classified as an ice giant. Neptune’s atmosphere is rich in hydrogen, helium, and methane, which gives the planet its deep blue color. The planet is known for having the fastest winds in the Solar System, with speeds reaching up to 2,100 km/h (1,300 mph). Neptune has a faint ring system and is located in a region of space populated by icy bodies known as the Kuiper Belt.",
            Description2 = "Neptune has 14 known moons, with Triton being the largest. Triton is unique among large moons in the Solar System because it orbits Neptune in the opposite direction of the planet’s rotation, suggesting that it may have been captured by Neptune’s gravity. Triton is geologically active, with geysers of nitrogen gas, and it has a thin atmosphere. Neptune’s magnetic field, like that of Uranus, is tilted significantly from its rotational axis.",
            Description3 = "Neptune was visited by Voyager 2 in 1989, which remains the only spacecraft to have flown by the planet. Since then, our understanding of Neptune has been limited to telescopic observations. The planet's extreme distance from the Sun means that it receives very little solar energy, yet it radiates more heat than it absorbs, possibly due to internal heating mechanisms. Neptune’s orbit around the Sun takes 165 Earth years, making it the slowest of all the planets.",
            Type = "Ice Giant"
        });

    }

    public override void Down()
    {
        // Usunięcie danych w przypadku rollback
        Delete.FromTable("Planets").Row(new { Name = "Mercury" });
        Delete.FromTable("Planets").Row(new { Name = "Venus" });
        Delete.FromTable("Planets").Row(new { Name = "Earth" });
        Delete.FromTable("Planets").Row(new { Name = "Mars" });
        Delete.FromTable("Planets").Row(new { Name = "Jupiter" });
        Delete.FromTable("Planets").Row(new { Name = "Saturn" });
        Delete.FromTable("Planets").Row(new { Name = "Uranus" });
        Delete.FromTable("Planets").Row(new { Name = "Neptune" });
    }
}
