import { Overlay, rem, Title } from "@mantine/core";
import { useState, useEffect } from "react";
import classes from "./UserInformation.module.css";

export default function UserInformation({ onClose }) {
    const [isVisible, setIsVisible] = useState(true); // Kontrolujemy widoczność napisu

    useEffect(() => {
        // Funkcja obsługująca kliknięcia
        const handleClickAnywhere = () => {
            setIsVisible(false); // Po kliknięciu ukryj napis
            onClose(); // Wywołaj funkcję zamykającą w komponencie rodzica
        };

        // Dodanie nasłuchu na kliknięcia w dowolnym miejscu
        window.addEventListener("click", handleClickAnywhere);

        // Sprzątanie po odmontowaniu komponentu
        return () => {
            window.removeEventListener("click", handleClickAnywhere);
        };
    }, []);

    return (
        <div className={classes.container} style={{ pointerEvents: isVisible ? 'auto' : 'none' }}>
            <div className={classes.background}>
                <Overlay color="#000" opacity={0.6} zIndex={0} blur={6} />
                <div className={classes.top}>
                    {isVisible && (
                        <Title order={1} size={rem(32)}>
                            Kliknij na planetę, aby ją zapoznać!
                        </Title>
                    )}
                </div>
            </div>
        </div>
    );
}
