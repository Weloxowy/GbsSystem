import React from 'react';
import QuizQuestion from "./QuizQuestion.tsx";

const questions = [
    {
        id: 1,
        question: 'What are the primary colors?',
        answers: [
            { id: 1, text: 'Red', isCorrect: true },
            { id: 2, text: 'Green', isCorrect: false },
            { id: 3, text: 'Blue', isCorrect: true },
            { id: 4, text: 'Yellow', isCorrect: true },
        ],
    },
    {
        id: 2,
        question: 'Which are programming languages?',
        answers: [
            { id: 1, text: 'Python', isCorrect: true },
            { id: 2, text: 'HTML', isCorrect: false },
            { id: 3, text: 'JavaScript', isCorrect: true },
            { id: 4, text: 'CSS', isCorrect: false },
        ],
    },
];

const Quiz: React.FC<{ onClose: () => void }> = ({ onClose }) => {
    return (
        <QuizQuestion questions={questions} onClose={onClose} />
    );
};

export default Quiz;
