import React, { useEffect, useState } from 'react';
import {Text} from "@mantine/core";
import QuizQuestion from "./QuizQuestion.tsx";

interface Question {
    id: string;
    question: string;
    answers: {
        id: number;
        text: string;
        isCorrect: boolean;
    }[];
}

const Quiz: React.FC<{ onClose: () => void; selectedPlanet: string; level: number }> = ({ onClose, selectedPlanet, level }) => {
    const [questions, setQuestions] = useState<Question[]>([]);

    const getPlanetInfo = async () => {
        try {
            const response = await fetch(`https://localhost:7098/api/Questions/QuestionsByPlanetAndLevel?name=${selectedPlanet}&level=${level}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    accept: 'text/plain',
                }
            });
            if (!response.ok) {
                throw new Error('Failed to fetch planet info');
            }
            const data = await response.json();
            const formattedQuestions: Question[] = data.map((item: any) => ({
                id: item.id,
                question: item.question,
                answers: [
                    { id: 1, text: item.answerBad1, isCorrect: false },
                    { id: 2, text: item.answerBad2, isCorrect: false },
                    { id: 3, text: item.answerBad3, isCorrect: false },
                    { id: 4, text: item.goodAnswer, isCorrect: true },
                ],
            }));

            setQuestions(formattedQuestions);
        } catch (error) {
            console.error('Failed to fetch planet info:', error);
        }
    };

    useEffect(() => {
        getPlanetInfo();
    }, [selectedPlanet, level]);
    const handleClose = () => {
        onClose();
    };

    return (
        <>
            {questions.length > 0 ? (
                <QuizQuestion questions={questions} onClose={handleClose} />
            ) : (
                <Text>Loading questions...</Text>
            )}
        </>
    );
};

export default Quiz;
