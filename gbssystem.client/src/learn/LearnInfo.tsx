import React, { useEffect, useState } from 'react';
import { Text } from "@mantine/core";
import marked from 'marked';

// Komponent LearnInfo
const LearnInfo: React.FC<{ onClose: () => void; selectedPlanet: string; level: number }> = ({ onClose, selectedPlanet, level }) => {
    const [content, setContent] = useState<string | null>(null);

    // Funkcja do załadowania pliku Markdown
    const loadMarkdownFile = async (path: string) => {
        try {
            const response = await fetch(path);
            const text = await response.text();
            setContent(marked(text)); // Konwertujemy Markdown na HTML
        } catch (error) {
            console.error("Błąd podczas ładowania pliku:", error);
        }
    };

    useEffect(() => {
        // Ładujemy plik Markdown przy pierwszym renderowaniu komponentu
        loadMarkdownFile("assets/lessons/"+selectedPlanet+"/"+level+".md");
    }, []);

    const handleClose = () => {
        onClose();
    };

    return (
        <>
            <Text onClick={handleClose}>Zamknij</Text>
            <div dangerouslySetInnerHTML={{ __html: content }} /> {/* Wyświetlamy zawartość HTML */}
        </>
    );
};

export default LearnInfo;
