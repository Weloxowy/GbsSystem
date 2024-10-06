import classes from "./NavBarMenu.module.css";
import {Button, Table, Group, Modal, Overlay, rem, ScrollArea, Text, Title} from "@mantine/core";
import { useEffect, useRef, useState } from "react";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import { Canvas } from "@react-three/fiber";
import * as THREE from "three";
import LevelPath from "../components/LevelPath/LevelPath.tsx";
import LearnPath from "../components/LearnPath/LearnPath.tsx";

    export default function NavBarMenu({ name, onClose }: { name: string; onClose: () => void }) {
        const planetData = [
            {
                name: "Mercury",
                type: "Telluric planet",
                distanceFromSun: "57.91 million km",
                diameter: "4,880 km",
                atmosphere: "Thin, mostly oxygen, sodium, hydrogen, helium, and potassium",
                temperature: "Up to 430°C during the day; -180°C at night",
                rotationPeriod: "58.6 days",
                orbitalPeriod: "88 days",
                satellites: "0",
                description: "Mercury is the closest planet to the Sun and has the shortest orbital period. Its surface is heavily cratered and resembles the Moon, with extreme temperature fluctuations due to its thin atmosphere."
            },
            {
                name: "Venus",
                type: "Telluric planet",
                distanceFromSun: "108.2 million km",
                diameter: "12,104 km",
                atmosphere: "Dense, mainly composed of carbon dioxide and nitrogen",
                temperature: "Up to 450°C",
                rotationPeriod: "243 days (retrograde rotation)",
                orbitalPeriod: "225 days",
                satellites: "0",
                description: "Venus is known for its thick atmosphere and extreme greenhouse effect, making it the hottest planet in the Solar System. It has no natural satellites and is often referred to as Earth's 'sister planet' due to its similar size."
            },
            {
                name: "Earth",
                type: "Telluric planet",
                distanceFromSun: "149.6 million km",
                diameter: "12,742 km",
                atmosphere: "Nitrogen (78%), oxygen (21%), and trace gases",
                temperature: "Average of 15°C",
                rotationPeriod: "24 hours",
                orbitalPeriod: "365.25 days",
                satellites: "1 (the Moon)",
                description: "Earth is the only planet known to support life. It has a diverse environment with water covering 71% of its surface and a dynamic atmosphere that sustains various ecosystems."
            },
            {
                name: "Mars",
                type: "Telluric planet",
                distanceFromSun: "227.9 million km",
                diameter: "6,779 km",
                atmosphere: "Thin, mostly carbon dioxide, nitrogen, and argon",
                temperature: "Average of -63°C",
                rotationPeriod: "24.6 hours",
                orbitalPeriod: "687 days",
                satellites: "2 (Phobos and Deimos)",
                description: "Mars is known as the 'Red Planet' due to its iron oxide-rich surface. It has the largest volcano in the solar system (Olympus Mons) and is a target for future human exploration."
            },
            {
                name: "Jupiter",
                type: "Gas giant",
                distanceFromSun: "778.5 million km",
                diameter: "139,822 km",
                atmosphere: "Hydrogen and helium, with traces of methane, water vapor, ammonia, and other compounds",
                temperature: "Average of -145°C",
                rotationPeriod: "9.9 hours",
                orbitalPeriod: "11.86 years",
                satellites: "79 (including Ganymede, the largest moon in the Solar System)",
                description: "Jupiter is the largest planet in the Solar System, known for its Great Red Spot, a giant storm. Its strong magnetic field and many moons make it a fascinating subject of study."
            },
            {
                name: "Saturn",
                type: "Gas giant",
                distanceFromSun: "1.429 billion km",
                diameter: "116,464 km",
                atmosphere: "Hydrogen and helium, with traces of methane and ammonia",
                temperature: "Average of -178°C",
                rotationPeriod: "10.7 hours",
                orbitalPeriod: "29.5 years",
                satellites: "83 (including Titan, which has a dense atmosphere)",
                description: "Saturn is famous for its extensive ring system made of ice and rock particles. It has a complex atmospheric system with strong winds and storms."
            },
            {
                name: "Uranus",
                type: "Ice giant",
                distanceFromSun: "2.871 billion km",
                diameter: "50,724 km",
                atmosphere: "Hydrogen, helium, and methane, giving it a blue color",
                temperature: "Average of -224°C",
                rotationPeriod: "17.2 hours",
                orbitalPeriod: "84 years",
                satellites: "27 (including Titania and Oberon)",
                description: "Uranus is unique for its tilted axis, which causes it to rotate on its side. It has a cold atmosphere and faint rings, and it is one of the least explored planets."
            },
            {
                name: "Neptune",
                type: "Ice giant",
                distanceFromSun: "4.495 billion km",
                diameter: "49,244 km",
                atmosphere: "Hydrogen, helium, and methane",
                temperature: "Average of -214°C",
                rotationPeriod: "16.1 hours",
                orbitalPeriod: "165 years",
                satellites: "14 (including Triton, which has geysers)",
                description: "Neptune is known for its striking blue color and strong winds, the fastest in the Solar System. It has a dynamic atmosphere with storm systems and is the farthest planet from the Sun."
            }
        ];


        const selectedPlanet = planetData.find((planet) => planet.name === name);

        if (!selectedPlanet) {
            return <p>Planet not found</p>;
        }

        const [openedLearn, setOpenedLearn] = useState(false);
        const [openedQuiz, setOpenedQuiz] = useState(false);

        const rows = Object.entries(selectedPlanet).map(([key, value]) => (
            <Table.Tr key={key}>
                <Table.Td>{key}</Table.Td>
                <Table.Td>{value}</Table.Td>
            </Table.Tr>
        ));

        return (
            <>
                <Modal opened={openedLearn} onClose={() => setOpenedLearn(false)} title={<Title order={2}>Learn about {selectedPlanet.name}</Title>} size="100%">
                    <LevelPath selectedPlanet={selectedPlanet.name} />
                </Modal>
                <Modal opened={openedQuiz} onClose={() => setOpenedQuiz(false)} title={<Title order={2}>Quiz mode</Title>} size="100%">
                    <LevelPath selectedPlanet={selectedPlanet.name} />
                </Modal>
                <div className={classes.background}>
                    <Overlay color="#000" opacity={0.6} zIndex={0} blur={6} />
                    <div className={classes.top}>
                        <Canvas style={{ height: "400px", width: "400px" }}>
                            <Planet planet={selectedPlanet} />
                            <Lights />
                        </Canvas>
                    </div>
                    <div className={classes.mid_top}>
                        <Title>{name}</Title>
                        <button
                            onClick={onClose}
                            style={{
                                cursor: "pointer",
                                position: "absolute",
                                top: 10,
                                right: 10,
                                background: "none",
                                border: "none",
                                fontSize: "24px",
                                color: "white",
                            }}
                        >
                            ✕
                        </button>
                    </div>
                    <div className={classes.mid_down}>
                        <ScrollArea h={200} offsetScrollbars>
                            <Text size={rem(24)}>
                                {selectedPlanet.description}
                            </Text>
                            <Table>
                                <Table.Thead>
                                    <Table.Tr>
                                        <Table.Th>Category</Table.Th>
                                        <Table.Th>Information</Table.Th>
                                    </Table.Tr>
                                </Table.Thead>
                                <Table.Tbody>{rows}</Table.Tbody>
                            </Table>
                        </ScrollArea>
                    </div>
                    <Group p={"lg"} className={classes.bottom}>
                        <Button color={"orange"} onClick={() => setOpenedLearn(true)} variant="filled" size="lg" radius="lg">
                            Learn!
                        </Button>
                        <Button color={"gray"} onClick={() => setOpenedQuiz(true)} variant="filled" size="lg" radius="lg">
                            Quiz time!
                        </Button>
                    </Group>
                </div>
            </>
        );
    }

function Lights() {
    return (
        <>
            <ambientLight />
            <pointLight position={[0, 0, 0]} />
        </>
    );
}

function Planet({ planet }: { planet: { file?: string } }) {
    const planetRef = useRef<THREE.Object3D | null>(null);
    const [obj, setObj] = useState<THREE.Object3D | null>(null);

    useEffect(() => {
        if (!planet.file) {
            console.error("Planet file is undefined!");
            return;
        }

        const gltfLoader = new GLTFLoader();
        gltfLoader.load(planet.file, (gltf) => {
            const model = gltf.scene;
            setObj(model);
        });

        return () => {
            setObj(null);
        };
    }, [planet.file]);

    return (
        <group>
            {obj && <primitive ref={planetRef} object={obj} scale={[2.5, 2.5, 2.5]} />}
        </group>
    );
}