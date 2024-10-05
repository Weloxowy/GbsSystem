import classes from "./NavBarMenu.module.css";
import React from "react";
import {Button, Overlay, Text, Title, Image } from "@mantine/core";

export default function NavBarMenu() {

    return (
        <>
            <div className={classes.background}>
                <Overlay color="#000" opacity={0.6} zIndex={0} blur={6}/>
                <div className={classes.top}>
                    <Image
                        style={{zIndex: 2}}
                        radius="md"
                        h={200}
                        w="auto"
                        fit="contain"
                        src="https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/images/bg-9.png"
                    />

                </div>
                <div className={classes.mid_top}>
                    <Title>Pobierany tytuł z bazy</Title>

                </div>
                <div className={classes.mid_down}>
                    <Text>Pobierany opis z bazy </Text>

                </div>
                <div className={classes.bottom}>
                    <Button variant="filled" color="green" size="lg" radius={"lg"}>Quiz</Button>
                </div>
            </div>
        </>
    );
}
