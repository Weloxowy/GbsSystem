import {Button, Text, Overlay, rem, Space, Title} from "@mantine/core";
import { useNavigate } from "react-router-dom";
import classes from "./MainPage.module.css";
import backgroundImage from "../assets/Zdj_hackaton_1.jpeg";
import Lottie from 'react-lottie';
import animation from '../assets/scroll.json'
import AddToCalendar from "../components/AddToCalendar/AddToCalendar.tsx";
export default function MainPage() {
    const navigation = useNavigate();

    const defaultOptions = {
        loop: true,
        speed: 0.7,
        animationData: animation,
        rendererSettings: {
            preserveAspectRatio: "xMidYMid slice"
        }
    };
    return (
        <div>
            {/* Tło na pełnym ekranie */}
            <div
                className={classes.background}
                style={{ backgroundImage: `url(${backgroundImage})` }}
            >
                <Overlay color="#000" opacity={0.6} zIndex={0} blur={6} />
            </div>


            {/* Zawartość na pierwszym ekranie */}
            <div className={classes.pageContent}>
                <Title order={1} size={rem(128)}>
                    GBS System
                </Title>
                <Space h={"xl"} />
                <Button
                    size={"xl"}
                    radius={"lg"}
                    onClick={async () => {
                        navigation("/Login");
                    }}
                >
                    LOGIN
                </Button>
            </div>

            {/* Przewijalna treść */}
            <div className={classes.scrollableContent}>
                <Lottie
                    options={defaultOptions}
                    height={100}
                    width={100}
                    isClickToPauseDisabled={true}
                />
                <Space h={"md"} />
                <Title order={2}>About the App</Title>
                <Space h={"md"} />
                <Text component={"p"} size={rem(32)}>
                Explore the wonders of the universe with our cutting-edge space exploration app! <br/>
                    Whether you're an amateur astronomer or a seasoned space enthusiast, this app offers a dynamic and immersive way to view the cosmos. <br/>
                    Featuring high-resolution imagery from renowned space agencies, live updates on celestial events, and an interactive 3D model of the solar system, our app lets you navigate the stars like never before.
                Discover distant galaxies, zoom in on planets, track satellites in real time, and learn about space phenomena through detailed articles and educational content. With intuitive controls and regular updates, this app transforms your device into a powerful window to the universe. Start your cosmic journey today!
                </Text>
                <AddToCalendar date={new Date()} title={"Testowe wydarzenie"} />
            </div>
        </div>
    );
}
