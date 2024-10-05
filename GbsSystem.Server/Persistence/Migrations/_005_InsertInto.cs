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
            Id = Guid.NewGuid(),
            Name = "Mercury",
            Diameter = 4879.0,
            Description1 = "Mercury is the smallest planet in the Solar System and the closest to the Sun. It has a diameter of just 4,879 km, making it about 38% the size of Earth. Despite its small size, Mercury has a surprisingly large core composed of iron and nickel, which takes up about 85% of the planet’s radius. Mercury has virtually no atmosphere, as its proximity to the Sun means that any gases are easily stripped away by solar winds. This lack of atmosphere also causes extreme temperature fluctuations. During the day, temperatures can reach a scorching 430°C (800°F), while at night, they can drop to as low as -180°C (-290°F).",
            Description2 = "Mercury’s surface is heavily cratered and similar in appearance to Earth's moon. These craters are the result of impacts from meteoroids and comets over billions of years. One of the most notable features is the Caloris Basin, a massive impact crater that spans 1,550 km in diameter. Mercury also has long cliffs, or scarps, that were likely formed as the planet cooled and contracted over time. The planet has a very slow rotation, taking 59 Earth days to complete one full spin on its axis. However, its orbit around the Sun is much faster, taking only 88 Earth days to complete one revolution.",
            Description3 = "Mercury has no moons or rings. Its proximity to the Sun makes it difficult to observe from Earth without a telescope, and it is often only visible during twilight hours. Despite its small size, Mercury's dense iron core gives it a magnetic field, though much weaker than Earth's. This magnetic field helps shield the planet from some solar radiation, but Mercury still experiences a constant bombardment of solar wind particles. The planet's exploration has been limited, with NASA's Mariner 10 and MESSENGER missions providing the most detailed images and data to date.",
            Type = "Terrestrial"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = Guid.NewGuid(),
            Name = "Venus",
            Diameter = 12104.0,
            Description1 = "Venus, the second planet from the Sun, is often called Earth's 'sister planet' because of their similar size and composition. However, the similarities end there. Venus has a thick, toxic atmosphere composed mainly of carbon dioxide, with clouds of sulfuric acid that trap heat and create a runaway greenhouse effect. As a result, Venus is the hottest planet in the Solar System, with surface temperatures that average around 465°C (869°F). The pressure on Venus’s surface is about 92 times that of Earth, similar to the pressure found a kilometer beneath Earth's oceans. This oppressive atmosphere makes Venus a hostile environment, with no liquid water and extreme volcanic activity.",
            Description2 = "Venus rotates in the opposite direction to most planets, a phenomenon known as retrograde rotation. It takes about 243 Earth days for Venus to complete one full rotation, making a day on Venus longer than its year, which lasts only 225 Earth days. Because of its slow rotation and thick atmosphere, Venus has little variation in temperature between its day and night sides. The planet's surface is relatively young, geologically speaking, with evidence of widespread volcanic activity. Most of Venus’s surface features are named after female figures from mythology, and its largest volcano, Maxwell Montes, is comparable in size to Earth's Mount Everest.",
            Description3 = "Venus has no moons or rings. Its brightness in the sky, often visible just before sunrise or just after sunset, has made it a prominent feature in human culture for millennia. The planet has been explored by numerous spacecraft, including NASA’s Magellan mission, which used radar to map 98% of Venus’s surface. Despite its harsh conditions, Venus continues to intrigue scientists, especially in the context of studying climate change and atmospheric evolution. Future missions may focus on the possibility of life in Venus's upper atmosphere, where conditions are less extreme than on the surface.",
            Type = "Terrestrial"
        });

        Insert.IntoTable("Planets").Row(new
        {
            Id = Guid.NewGuid(),
            Name = "Earth",
            Diameter = 12742.0,
            Description1 = "Earth is the third planet from the Sun and the only known planet to support life. Its atmosphere is composed of 78% nitrogen, 21% oxygen, and trace amounts of other gases, including carbon dioxide, which helps regulate the planet's temperature through the greenhouse effect. Earth’s surface is 71% covered by water, and it is the only planet in the Solar System with liquid water at its surface. The planet’s moderate climate and magnetic field, generated by its molten iron core, provide protection from harmful solar radiation and cosmic rays. Earth’s atmosphere also contains an ozone layer that shields the surface from the Sun’s ultraviolet radiation.",
            Description2 = "Earth is divided into several layers: the inner core, outer core, mantle, and crust. The crust is broken into tectonic plates that move over time, causing earthquakes, volcanic activity, and the formation of mountains. Earth's biosphere, a complex and dynamic system, includes diverse ecosystems ranging from polar ice caps to tropical rainforests. It supports millions of species, including humans, who have dramatically altered the planet’s environment through deforestation, pollution, and climate change. Despite its fragility, Earth’s ecosystems have shown remarkable resilience, recovering from mass extinctions and other global catastrophes.",
            Description3 = "Earth has one natural satellite, the Moon, which stabilizes the planet’s axial tilt and contributes to the seasons. The Moon's gravitational pull also causes tides in Earth’s oceans. Humans have been fascinated by the Moon for millennia, and it remains the only celestial body beyond Earth that humans have visited. Earth’s position in the Solar System, within the so-called 'habitable zone,' allows for the right conditions to support life, making it unique among the known planets. As the human population continues to grow, the need for sustainable management of Earth’s resources becomes increasingly important.",
            Type = "Terrestrial"
        });

        // Analogiczne inserty dla pozostałych planet
        // Mars, Jupiter, Saturn, Uranus, Neptune
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
