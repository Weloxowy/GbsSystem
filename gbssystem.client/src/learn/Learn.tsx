import React from 'react';
import { Text } from "@mantine/core";
import QuizQuestion from "./QuizQuestion.tsx";
import LearnInfo from "./LearnInfo.tsx";

const Learn: React.FC<{ onClose: () => void; selectedPlanet: string; level: number }> = ({ onClose, selectedPlanet, level }) => {
    const handleClose = () => {
        onClose();
    };

    return (
        <>
            <Text onClick={handleClose}>Zamknij</Text>
            <LearnInfo selectedPlanet={selectedPlanet} level={level} onClose={onClose} />
        </>
    );
};

export default Learn;
