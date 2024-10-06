const random = (a: number, b: number): number => a + Math.random() * b;
const randomInt = (a: number, b: number): number => Math.floor(random(a, b));
const randomColor = (): string =>
  `rgb(${randomInt(80, 50)}, ${randomInt(80, 50)}, ${randomInt(80, 50)})`;

type PlanetType = {
  id: number;
  name: string;
  file: string;
  color: string;
  xRadius: number;
  zRadius: number;
  size: number;
  speed: number;
  rotationSpeed: number;
  offset: number;
};
const baseSpeed = 100; // Bazowa prędkość

const planetNamesAndFiles = [
  { name: "Mercury", file: "/1_merkury.glb", size: 0.38 * 5, speed: (47.87 / baseSpeed), rotationSpeed: 1 / 58.6 },
  { name: "Venus", file: "/2_wenus.glb", size: 0.95 * 3, speed: (35.02 / baseSpeed), rotationSpeed: 1 / 243 },
  { name: "Earth", file: "/3_ziemia.glb", size: 1.0 * 3, speed: (29.78 / baseSpeed), rotationSpeed: 1 }, // 1 obrót dziennie
  { name: "Mars", file: "/4_mars.glb", size: 0.53 * 4, speed: (24.07 / baseSpeed), rotationSpeed: 1 / 1.03 },
  { name: "Jupiter", file: "/5_jowisz.glb", size: 11.21 / 5, speed: (13.07 / baseSpeed), rotationSpeed: 2.4 }, // obraca się szybciej
  { name: "Saturn", file: "/6_saturn.glb", size: 9.45 / 5, speed: (9.69 / baseSpeed), rotationSpeed: 2.3 },
  { name: "Uranus", file: "/7_uran.glb", size: 4.01, speed: (6.81 / baseSpeed), rotationSpeed: 1 / 17.2 },
  { name: "Neptune", file: "/8_neptun.glb", size: 3.88, speed: (5.43 / baseSpeed), rotationSpeed: 1 / 16.1 },
];

const planetData: PlanetType[] = [];
const totalPlanets = 8;

for (let index = 0; index < totalPlanets; index++) {
  const { name, file, size, speed, rotationSpeed } = planetNamesAndFiles[index];
  planetData.push({
    id: index + 1,
    name,
    file,
    color: randomColor(),
    xRadius: (index + 1.5) * 4,
    zRadius: (index + 1.5) * 2,
    size,
    speed,
    rotationSpeed,
    offset: random(0, Math.PI * 2),
  });
}

export default planetData;
