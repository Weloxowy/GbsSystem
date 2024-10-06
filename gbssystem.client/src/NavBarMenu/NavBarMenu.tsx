import classes from "./NavBarMenu.module.css";
import {Button, Table, Group, Modal, Overlay, rem, ScrollArea, Text, Title} from "@mantine/core";
import planetData from "../planets/planetData.ts";
import { useEffect, useRef, useState } from "react";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import { Canvas } from "@react-three/fiber";
import * as THREE from "three";
import LevelPath from "../components/LevelPath/LevelPath.tsx";

export default function NavBarMenu({ name }: { name: string }) {
    const elements = [
        { name: "Type of planet", value: "telluric planet" },
        { name: "Distance from Sun", value: "108 million km" },
        { name: "Diameter", value: "12,104 km" },
        { name: "Atmosphere", value: "Dense, mainly CO₂" },
        { name: "Temperature", value: "Up to 450°C" },
        { name: "Rotation period", value: "243 days (longer than a year)" },
        { name: "Orbital period", value: "225 days" },
        { name: "Number of satellites", value: "0" },
    ];

    const rows = elements.map((element) => (
        <Table.Tr key={element.name}>
            <Table.Td>{element.name}</Table.Td>
            <Table.Td>{element.value}</Table.Td>
        </Table.Tr>
    ));

    const getPlanetInfo = async () => {
        try {
            const response = await fetch('https://localhost:7098/api/Planets', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    accept: 'text/plain',
                }
            });
            if (!response.ok) {
                throw new Error('Registration failed'); // Obsługa błędów
            }

        } catch (error) {
            console.error('Registration failed. Please try again.');
        }
    };

    const selectedPlanet = planetData.find((planet) => planet.name === name);

    if (!selectedPlanet) {
        return <p>Planet not found</p>;
    }
    const [opened,setOpened] = useState(false);

    return (
        <>
            <Modal opened={opened} onClose={()=>setOpened(false)} size="100%">
                <LevelPath selectedPlanet={selectedPlanet.name}/>
            </Modal>
            <div className={classes.background}>
                <Overlay color="#000" opacity={0.6} zIndex={0} blur={6} />
                <div className={classes.top}>
                    <Canvas style={{ height: "400px", width: "400px" }}>
                        <Planet planet={selectedPlanet}/>
                        <Lights/>
                    </Canvas>
                </div>
                <div className={classes.mid_top}>
                    <Title>{name}</Title>
                </div>
                <div className={classes.mid_down}>
                    <ScrollArea h={200} offsetScrollbars>
                    <Text size={rem(24)}>
                        Venus is the second planet from the Sun and the closest to Earth.
                        It is known for its dense atmosphere, which is mainly composed of carbon dioxide, and extreme temperature conditions that can exceed 450°C.
                        The planet has a very bright surface, making it visible from Earth as the "morning star" or "evening star." Venus has no natural satellites or rings.
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
                    <Button disabled={false} color={"orange"} onClick={()=>setOpened(true)} variant="filled" size="lg" radius="lg">
                        Learn!
                    </Button>
                    <Button disabled={false} color={"gray"} onClick={()=>setOpened(true)} variant="filled" size="lg" radius="lg">
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
// Komponent Planety
function Planet({
                    planet: { file },
                }: {
    planet: {
        file: string;
        size: number;
    };
}) {
    const planetRef = useRef<THREE.Object3D | null>(null);
    const [obj, setObj] = useState<THREE.Object3D | null>(null);

    useEffect(() => {
        const gltfLoader = new GLTFLoader();
        gltfLoader.load(file, (gltf) => {
            const model = gltf.scene;
            setObj(model);
        });

        return () => {
            setObj(null);
        };
    }, [file]);

    return (
        <group>
            {obj && <primitive ref={planetRef} object={obj} scale={[2.5,2.5,2.5]} />}
        </group>
    );
}
