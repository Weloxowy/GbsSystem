import React, { useEffect, useRef, useState } from "react";
import { Canvas, useFrame, useThree } from "@react-three/fiber";
import { OrbitControls } from "@react-three/drei";
import * as THREE from "three";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import planetData from "./planetData";
import backgroundImage from "./../assets/milkyway.jpg";
import NavBarMenu from "@/NavBarMenu/NavBarMenu.tsx";
import UserInformation from "@/RightTopInformation/UserInformation.tsx"; // Importujemy komponent UserInformation

function SpeedSlider({ onSpeedChange }) {
    const [speed, setSpeed] = useState(1); // Domyślna prędkość: suwak na środku (1x)

    // Funkcja do zmiany prędkości, która upewnia się, że prędkość jest w zakresie 0.1 - 10
    const updateSpeed = (newSpeed) => {
        const clampedSpeed = Math.max(0.1, Math.min(newSpeed, 10)); // Ograniczamy prędkość między 0.1 a 10
        setSpeed(clampedSpeed);
        onSpeedChange(clampedSpeed); // Przekazujemy nową prędkość do rodzica
    };

    // Obsługa kliknięcia na minus (zmniejszenie prędkości o 0.1)
    const handleMinusClick = () => {
        updateSpeed(speed - 0.1);
    };

    // Obsługa kliknięcia na plus (zwiększenie prędkości o 0.1)
    const handlePlusClick = () => {
        updateSpeed(speed + 0.1);
    };

    const handleChange = (event) => {
        const newSpeed = parseFloat(event.target.value);
        updateSpeed(newSpeed);
    };

    return (
        <div
            style={{
                position: "absolute",
                right: 10,
                top: "50%",
                transform: "translateY(-50%)",
                width: "60px",
                height: "350px",
                zIndex: 1000,
                display: "flex",
                flexDirection: "column",
                justifyContent: "space-between",
                alignItems: "center",
                background: "rgba(255, 255, 255, 0.1)",
                borderRadius: "10px",
                padding: "10px",
            }}
        >
            {/* Wyświetlanie aktualnej prędkości nad komponentem */}
            <div
                style={{
                    color: "white",
                    position: "absolute",
                    top: "-40px", // Przesuwamy nad cały komponent
                    fontSize: "18px",
                    fontWeight: "bold",
                }}
            >
                {speed.toFixed(1)}x
            </div>

            {/* Klikalny plus */}
            <button
                onClick={handlePlusClick}
                style={{
                    background: "transparent",
                    border: "none",
                    color: "white",
                    fontSize: "20px",
                    cursor: "pointer",
                }}
            >
                +
            </button>

            {/* Suwak */}
            <input
                type="range"
                min="0.1"
                max="10"
                step="0.1"
                value={speed}
                onChange={handleChange}
                style={{
                    writingMode: "bt-lr",
                    transform: "rotate(270deg)",
                    width: "200px",
                    background: "white",
                }}
            />

            {/* Klikalny minus */}
            <button
                onClick={handleMinusClick}
                style={{
                    background: "transparent",
                    border: "none",
                    color: "white",
                    fontSize: "20px",
                    cursor: "pointer",
                }}
            >
                -
            </button>
        </div>
    );
}




export default function Planets() {
    const [selectedPlanet, setSelectedPlanet] = useState(null);
    const [orbitSpeedMultiplier, setOrbitSpeedMultiplier] = useState(1);
    const [showUserInfo, setShowUserInfo] = useState(true); // Nowy stan do kontrolowania widoczności UserInformation

    const handleClick = (planetName) => {
        setSelectedPlanet(planetName);
        setShowUserInfo(false); // Ukryj UserInformation po kliknięciu w planetę
    };

    const handleSpeedChange = (newSpeed) => {
        // Mnożnik prędkości będzie odpowiadał wartości suwaka (od 0.1x do 10x)
        setOrbitSpeedMultiplier(newSpeed);
    };

    const handleClose = () => {
        setSelectedPlanet(null);
    };
    return (
        <>
            <div
                style={{
                    backgroundImage: `linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url(${backgroundImage})`,
                    backgroundSize: "cover",
                    height: "100vh",
                    width: "100vw",
                    display: "flex",
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
                        <NavBarMenu name={selectedPlanet} onClose={handleClose} /> {/* Pass handleClose to NavBarMenu */}
                    </div>
                )}

                {/* Suwak prędkości */}
                <SpeedSlider onSpeedChange={handleSpeedChange} />

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
                            orbitSpeedMultiplier={orbitSpeedMultiplier}
                        />
                    ))}
                    <Lights />
                    <OrbitControls />
                </Canvas>

                {/* Użycie UserInformation z onClose */}
                {showUserInfo && <UserInformation onClose={() => setShowUserInfo(false)} />}
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
                    orbitSpeedMultiplier, // Odbieramy mnożnik prędkości orbit
                }) {
    const planetRef = useRef(null);
    const [obj, setObj] = useState(null);
    const customElapsedTime = useRef(0); // Przechowujemy niestandardowy czas

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

    useFrame(({ clock }, delta) => {
        if (planetRef.current) {
            // Zwiększamy customElapsedTime o czas delta * mnożnik prędkości
            customElapsedTime.current += delta * orbitSpeedMultiplier;

            // Zmienna prędkość orbity w zależności od suwaka, ale bez resetu pozycji
            const t = customElapsedTime.current * speed + offset;
            const x = xRadius * 2 * Math.sin(t);
            const z = zRadius * 2 * Math.cos(t);
            planetRef.current.position.x = x;
            planetRef.current.position.z = z;

            // Rotacja wokół osi
            planetRef.current.rotation.y += rotationSpeed / 20;
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
