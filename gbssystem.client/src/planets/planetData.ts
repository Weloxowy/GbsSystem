const random = (a: number, b: number): number => a + Math.random() * b;
const randomInt = (a: number, b: number): number => Math.floor(random(a, b));
const randomColor = (): string =>
  `rgb(${randomInt(80, 50)}, ${randomInt(80, 50)}, ${randomInt(80, 50)})`;

type PlanetType = {
  id: number;
  color: string;
  xRadius: number;
  zRadius: number;
  size: number;
  speed: number;
  offset: number;
};

const planetData: PlanetType[] = [];
const totalPlanets = 6;

for (let index = 0; index < totalPlanets; index++) {
  planetData.push({
    id: index,
    color: randomColor(),
    xRadius: (index + 1.5) * 4,
    zRadius: (index + 1.5) * 2,
    size: random(0.5, 1),
    speed: random(0.1, 0.6),
    offset: random(0, Math.PI * 2),
  });
}

export default planetData;
