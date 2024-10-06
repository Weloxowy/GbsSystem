import React, { useEffect, useRef, useState } from "react";
import { Canvas, useFrame, useThree } from "@react-three/fiber";
import { OrbitControls } from "@react-three/drei";
import * as THREE from "three";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";

import planetData from "./planetData";
import backgroundImage from "./../assets/milkyway.jpg";
import NavBarMenu from "@/NavBarMenu/NavBarMenu.tsx";

export default function Planets() {
    const [selectedPlanet, setSelectedPlanet] = useState(null);
    const handleClick = (planetName) => {
        setSelectedPlanet(planetName);
    };

    return (
        <>
            <div
                style={{
                    backgroundImage: `linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url(${backgroundImage})`,
                    backgroundSize: "cover",
                    height: "100vh",
                    width: "100vw",
                    display: "flex"
                }}
            >
                {selectedPlanet && (
                    <div
                        style={{
                            width: "300px",
                            height: "100vh",
                            position: "fixed",
                            left: 0,
                            zIndex: 1,
                        }}
                    >
                        <NavBarMenu name={selectedPlanet} />
                    </div>
                )}
                <Canvas
                    camera={{ position: [-5, 30, 35], fov: 75, near: 0.1, far: 1000 }}
                    style={{
                        width: "100vw",
                        height: "100vh",
                        position: "fixed",
                        top: "50%",
                        left: "50%",
                        transform: "translate(-50%, -50%)",
                    }}
                >
                    <Sun />
                    {planetData.map((planet) => (
                        <Planet
                            planet={planet}
                            key={planet.id}
                            onPlanetClick={() => handleClick(planet.name)}
                        />
                    ))}
                    <Lights />
                    <OrbitControls />
                </Canvas>
            </div>
        </>
    );
}

function Sun() {
    const planetRef = useRef(null);
    const [obj, setObj] = useState(null);

    useEffect(() => {
        const gltfLoader = new GLTFLoader();
        gltfLoader.load("/planetatest.glb", (gltf) => {
            console.log("Loaded GLB model:", gltf);
            const model = gltf.scene;
            setObj(model);
        });

        return () => {
            setObj(null);
        };
    }, []);

    const size = 2.5;
    return (
        <mesh>
            <sphereGeometry args={[2.5, 32, 32]} />
            <meshStandardMaterial color="#E1DC59" />
        </mesh>
    );
}

function Planet({
                    planet: { file, xRadius, zRadius, size, speed, rotationSpeed, offset },
                    onPlanetClick,
                }) {
    const planetRef = useRef(null);
    const [obj, setObj] = useState(null);

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

    useFrame(({ clock }) => {
        if (planetRef.current) {
            // Ruch planety wokół swojej orbity
            const t = clock.getElapsedTime() * speed + offset;
            const x = xRadius * 2 * Math.sin(t);
            const z = zRadius * 2 * Math.cos(t);
            planetRef.current.position.x = x;
            planetRef.current.position.z = z;
            planetRef.current.rotation.y += rotationSpeed/20;
        }
    });

    const handleClick = () => {
        onPlanetClick();
    };

    return (
        <group onClick={handleClick}>
            {obj && <primitive ref={planetRef} object={obj} scale={[size, size, size]} />}
            <Ecliptic xRadius={xRadius * 2} zRadius={zRadius * 2} />
        </group>
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

function Ecliptic({ xRadius = 3, zRadius = 3 }) {
    const { scene } = useThree();
    const lineRef = useRef();

    useEffect(() => {
        const points = [];
        for (let index = 0; index < 64; index++) {
            const angle = (index / 64) * 2 * Math.PI;
            const x = xRadius * Math.cos(angle);
            const z = zRadius * Math.sin(angle);
            points.push(new THREE.Vector3(x, 0, z));
        }

        points.push(points[0]);

        const lineGeometry = new THREE.BufferGeometry().setFromPoints(points);
        const lineMaterial = new THREE.LineBasicMaterial({
            color: "#ecf4ff",
            linewidth: 100,
        });
        const line = new THREE.Line(lineGeometry, lineMaterial);

        lineRef.current = line;
        scene.add(line);

        return () => {
            if (lineRef.current) {
                scene.remove(lineRef.current);
            }
        };
    }, [xRadius, zRadius, scene]);

    return null;
}
