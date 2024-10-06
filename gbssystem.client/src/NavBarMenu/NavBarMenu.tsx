import classes from "./NavBarMenu.module.css";
import {Button, Modal, Overlay, ScrollArea, Text, Title} from "@mantine/core";
import planetData from "../planets/planetData.ts";
import { useEffect, useRef, useState } from "react";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import { Canvas } from "@react-three/fiber";
import * as THREE from "three";
import LevelPath from "../components/LevelPath/LevelPath.tsx";

export default function NavBarMenu({ name }: { name: string }) {
    const selectedPlanet = planetData.find((planet) => planet.name === name);

    if (!selectedPlanet) {
        return <p>Planet not found</p>;
    }
    const [opened,setOpened] = useState(false);

    return (
        <>
            <Modal opened={opened} onClose={()=>setOpened(false)} size="100%">
                <LevelPath />
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
                    <Text>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque vitae urna erat. Etiam malesuada tincidunt lacus, vel blandit turpis faucibus nec. Morbi a egestas erat. In hac habitasse platea dictumst. Morbi venenatis pellentesque libero et tempor. Pellentesque vel lacinia augue. Donec eu eros nec justo dapibus congue. Nulla facilisi. Vestibulum at tempor nunc, in tempus leo. Sed quis libero in lorem dictum blandit ac eu augue. Ut non risus eget turpis feugiat malesuada quis vulputate diam. Vestibulum consectetur leo et metus tincidunt, vitae finibus augue euismod. Fusce augue est, varius eget dignissim vel, porttitor quis neque. Proin elementum aliquet tortor eget molestie. Praesent maximus nunc vel varius egestas.

                        Nam pellentesque augue vehicula massa tristique, pharetra mollis odio varius. Etiam porta molestie volutpat. Vestibulum nec orci eu dolor imperdiet tempus. Nunc est turpis, imperdiet sed consectetur sed, interdum non elit. Fusce rhoncus volutpat ante, et sodales purus auctor sed. Duis suscipit nunc quis mi semper, id venenatis metus mattis. Cras eget mattis nunc. Suspendisse diam velit, molestie vitae quam eu, aliquam auctor quam. Curabitur id rhoncus mi, non tristique ante. Vivamus nunc urna, hendrerit ac augue vel, feugiat ullamcorper mi. Praesent maximus blandit cursus. Vestibulum nec blandit lacus. Proin viverra nunc lorem, ac mattis mauris aliquam vel. Quisque eros neque, venenatis sit amet dapibus sit amet, ultricies nec dolor. Maecenas pellentesque, libero sit amet mollis egestas, libero nibh porta nunc, ut consectetur velit quam eu nisl.

                        Nullam pharetra vehicula tortor, eu congue dui egestas eget. Etiam sed nisi augue. In efficitur nunc ornare ante feugiat, eget aliquet libero sagittis. Sed in risus vel ex mollis facilisis. Duis facilisis porttitor nibh, at posuere nisl maximus nec. In velit massa, accumsan vel diam ut, ultrices ullamcorper felis. Nam porttitor urna diam, ut accumsan tortor tristique eu. Aenean sit amet rutrum magna. Nam eu tortor luctus, ultrices tortor a, imperdiet magna. Duis eget dui convallis, mattis purus eget, pulvinar est. Donec malesuada diam magna. Suspendisse erat augue, viverra vitae varius sed, sodales nec enim.

                        Morbi efficitur felis sed odio ultrices luctus. Fusce vitae placerat turpis, sit amet tristique eros. Etiam ornare nulla a tortor condimentum, quis blandit odio malesuada. In sit amet dolor enim. Duis efficitur dolor eu massa dapibus ullamcorper. Nunc id tempor sem. Suspendisse eleifend elit non imperdiet cursus. Aliquam id rhoncus ex, ut tincidunt nunc. Nulla facilisis risus a justo hendrerit, eu eleifend odio tempor. Aenean sit amet elit sem. Sed eu lacinia orci. Ut ornare leo et leo suscipit suscipit. Suspendisse interdum quam et vestibulum condimentum. Quisque eget eros sit amet nibh sagittis cursus eu vel leo. Vestibulum blandit, ipsum a rhoncus suscipit, risus turpis blandit erat, sed posuere tortor dolor at nibh. Nunc quis pharetra elit.

                        Nunc vitae erat varius, dictum risus id, luctus nunc. Suspendisse imperdiet ac erat eget cursus. Donec commodo auctor ante, bibendum pharetra purus volutpat vitae. Duis sem purus, pharetra ut varius a, finibus id nisi. Duis quis mauris posuere dolor hendrerit hendrerit. Aenean a nisi scelerisque, fringilla sem vitae, sollicitudin orci. Nullam eu dignissim urna. Aenean imperdiet lorem lacus, at convallis nisl lobortis sit amet. Nam vitae aliquet mauris.</Text>
                    </ScrollArea>
                    </div>
                <div className={classes.bottom}>
                    <Button disabled={false} color={"orange"} onClick={()=>setOpened(true)} variant="filled" size="lg" radius="lg">
                        Learn!
                    </Button>

                </div>
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
