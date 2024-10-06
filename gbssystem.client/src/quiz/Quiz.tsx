import React, { useEffect, useState } from 'react';
import {Text} from "@mantine/core";
import QuizQuestion from "./QuizQuestion.tsx";

// Define the type for the question
interface Question {
    id: string;
    question: string;
    answers: {
        id: number;
        text: string;
        isCorrect: boolean;
    }[];
}

// Component to fetch planet info and render quiz questions
const Quiz: React.FC<{ onClose: () => void; selectedPlanet: string; level: number }> = ({ onClose, selectedPlanet, level }) => {
    const [questions, setQuestions] = useState<Question[]>([]); // State to hold questions

    // Function to fetch questions from the API
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
                throw new Error('Failed to fetch planet info'); // Error handling
            }
            const data = await response.json(); // Parse the JSON response

            // Map the data to the desired structure
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

            setQuestions(formattedQuestions); // Store the formatted questions in state
        } catch (error) {
            console.error('Failed to fetch planet info:', error);
        }
    };

    // Fetch questions on component mount
    useEffect(() => {
        getPlanetInfo();
    }, [selectedPlanet, level]); // Add dependencies to re-fetch if these change

    // Handle the closing of the quiz (if needed)
    const handleClose = () => {
        onClose(); // Call the onClose function passed from parent
    };

    return (
        <>
            {questions.length > 0 ? (
                <QuizQuestion questions={questions} onClose={handleClose} /> // Pass the questions to QuizQuestion
            ) : (
                <Text>Loading questions...</Text> // Loading state
            )}
        </>
    );
};

export default Quiz;
