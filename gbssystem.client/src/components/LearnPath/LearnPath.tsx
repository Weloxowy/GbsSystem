import { useState } from "react";
import { Modal, Button } from "@mantine/core";
import classes from './LearnPath.module.css';
import LearnInfo from "../../learn/LearnInfo.tsx";

interface LevelPathProps {
    selectedPlanet: string;
}

export default function LearnPath({ selectedPlanet }: LevelPathProps) {
    const [selectedLevel, setSelectedLevel] = useState<number | null>(null);
    const [quizOpened, setQuizOpened] = useState(false);

    const handleClick = (level: number) => {
        setSelectedLevel(level);
        setQuizOpened(true);
    };
    const levelsRow1 = [1, 2, 3, 4];
    const levelsRow2 = [8, 7, 6, 5];

    return (
        <div className={classes.App}>
            <h1>Wybierz poziom</h1>
            <div className={classes.pathContainer}>
                <div className={classes.row}>
                    {levelsRow1.map((level) => (
                        <Button
                            key={level}
                            radius="xl"
                            size="md"
                            className={classes.levelBtn}
                            onClick={() => handleClick(level)}
                        >
                            {level}
                        </Button>
                    ))}
                </div>
                <div className={classes.row}>
                    {levelsRow2.map((level) => (
                        <Button
                            key={level}
                            radius="xl"
                            size="md"
                            className={classes.levelBtn}
                            onClick={() => handleClick(level)}
                        >
                            {level}
                        </Button>
                    ))}
                </div>
            </div>
            <Modal
                size={"70vw"}
                opened={quizOpened}
                onClose={() => setQuizOpened(false)}
                title={`Poziom ${selectedLevel}`}
            >
                {selectedLevel && <LearnInfo level={selectedLevel} selectedPlanet={selectedPlanet} />}
            </Modal>
        </div>
    );
}
