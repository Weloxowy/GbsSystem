import React, { useEffect, useRef, useState } from "react";
import { Canvas, useFrame, useThree, useLoader } from "@react-three/fiber";
import { OrbitControls } from "@react-three/drei";
import * as THREE from "three";
import { OBJLoader } from "three/examples/jsm/loaders/OBJLoader";
import { MTLLoader } from "three/examples/jsm/loaders/MTLLoader";
import planetData from "./planetData";
import backgroundImage from "./../assets/milkyway.jpg";
//@ts-ignore

type PlanetType = {
  id: number;
  color: string;
  xRadius: number;
  zRadius: number;
  size: number;
  speed: number;
  offset: number;
};

export default function Planets() {
  return (
    <>
      <div
        style={{
          backgroundImage: `linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url(${backgroundImage})`,
          backgroundSize: "cover",
          height: "100vh",
          width: "100vw",
        }}
      >
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
          {planetData.map((planet: PlanetType) => (
            <Planet planet={planet} key={planet.id} />
          ))}
          <Lights />
          <OrbitControls />
        </Canvas>
      </div>
    </>
  );
}

function Sun() {
  return (
    <mesh>
      <sphereGeometry args={[2.5, 32, 32]} />
      <meshStandardMaterial color="#E1DC59" />
    </mesh>
  );
}

type PlanetProps = {
  planet: PlanetType;
};

function Planet({
  planet: { color, xRadius, zRadius, size, speed, offset },
}: PlanetProps) {
  // const planetRef = useRef<THREE.Mesh>(null);
  // const obj = useLoader(OBJLoader, '/Mars_planet_in_low_po_1005132338_refine.obj');

  const planetRef = useRef<THREE.Mesh>(null);
  const [obj, setObj] = useState<THREE.Object3D | null>(null);

  useEffect(() => {
    const mtlLoader = new MTLLoader();
    const objLoader = new OBJLoader();

    mtlLoader.load(
      "/Mars_planet_in_low_po_1005132338_refine.mtl",
      (materials) => {
        console.log("Loaded materials:", materials);
        //@ts-ignore
        materials.preload();
        //@ts-ignore
        const materialArray = materials.getAsArray();
        console.log("Material array:", materialArray);

        objLoader.setMaterials(materials);
        //@ts-ignore
        objLoader.load(
          "/Mars_planet_in_low_po_1005132338_refine.obj",
          //@ts-ignore
          (loadedObj) => {
            console.log("Loaded object:", loadedObj);
            setObj(loadedObj);
          }
        );
      }
    );

    return () => {
      setObj(null);
    };
  }, []);

  useFrame(({ clock }) => {
    if (planetRef.current) {
      const t = clock.getElapsedTime() * speed + offset;
      const x = xRadius * 2 * Math.sin(t);
      const z = zRadius * 2 * Math.cos(t);
      planetRef.current.position.x = x;
      planetRef.current.position.z = z;
    }
  });

  return (
    <>
      {/* <primitive ref={planetRef} object={obj} scale={[size, size, size]} />
      <Ecliptic xRadius={xRadius} zRadius={zRadius} /> */}

      {/* <mesh ref={planetRef} scale={[3, 3, 3]}>  */}
      {/* <primitive ref={planetRef} object={obj} scale={[size, size, size]} /> */}
      {obj && (
        <primitive ref={planetRef} object={obj} scale={[size, size, size]} />
      )}

      {/* <sphereGeometry args={[size, 50, 50]} /> */}
      {/* <meshStandardMaterial color={color} /> */}
      {/* </mesh> */}
      <Ecliptic xRadius={xRadius * 2} zRadius={zRadius * 2} />
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

type EclipticProps = {
  xRadius?: number;
  zRadius?: number;
};

function Ecliptic({ xRadius = 3, zRadius = 3 }: EclipticProps) {
  const { scene } = useThree();
  const lineRef = useRef<THREE.Line>();

  useEffect(() => {
    const points: THREE.Vector3[] = [];
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
