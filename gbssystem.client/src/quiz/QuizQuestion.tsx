// QuizQuestion.tsx
import React, { useState } from 'react';
import { Stepper, Button, Checkbox, Group } from '@mantine/core';

interface Answer {
    id: number;
    text: string;
    isCorrect: boolean;
}

interface Question{
    id: number;
    question: string;
    answers: Answer[];
}

interface QuizProps {
    questions: Question[];
    onClose: () => void;
}

const QuizQuestion: React.FC<QuizProps> = ({ questions, onClose }) => {
    const [activeStep, setActiveStep] = useState(0);
    const [selectedAnswers, setSelectedAnswers] = useState<{ [key: number]: number[] }>({});
    const [score, setScore] = useState<number | null>(null);

    const handleCheckboxChange = (questionId: number, answerId: number) => {
        setSelectedAnswers((prev) => {
            const currentAnswers = prev[questionId] || [];
            if (currentAnswers.includes(answerId)) {
                return { ...prev, [questionId]: currentAnswers.filter((id) => id !== answerId) };
            } else {
                return { ...prev, [questionId]: [...currentAnswers, answerId] };
            }
        });
    };

    const handleNextStep = () => {
        if (activeStep < questions.length - 1) {
            setActiveStep((current) => current + 1);
        } else {
            setScore(calculateScore());
            setActiveStep((current) => current + 1);
        }
    };

    const handleBackToFirstStep = () => {
        setActiveStep(0);
        setScore(null);
        setSelectedAnswers({});
    };

    const calculateScore = () => {
        return questions.reduce((score, question) => {
            const correctAnswers = question.answers
                .filter((answer) => answer.isCorrect)
                .map((answer) => answer.id);
            const userAnswers = selectedAnswers[question.id] || [];

            if (JSON.stringify(correctAnswers.sort()) === JSON.stringify(userAnswers.sort())) {
                return score + 1;
            }
            return score;
        }, 0);
    };

    return (
        <div style={{ maxWidth: 500, margin: '0 auto' }}>
            <Stepper active={activeStep}>
                {questions.map((question, index) => (
                    <Stepper.Step key={question.id} label={`Question ${index + 1}`}>
                        <div>
                            <h3>{question.question}</h3>
                            {question.answers.map((answer) => (
                                <Checkbox
                                    key={answer.id}
                                    label={answer.text}
                                    checked={(selectedAnswers[question.id] || []).includes(answer.id)}
                                    onChange={() => handleCheckboxChange(question.id, answer.id)}
                                />
                            ))}
                        </div>
                    </Stepper.Step>
                ))}

                <Stepper.Completed>
                    <h3>Quiz Completed!</h3>
                    {score !== null && (
                        <p>Your score: {score} / {questions.length}</p>
                    )}
                </Stepper.Completed>
            </Stepper>

            <Group mt="xl">
                {activeStep !== questions.length && (
                    <Button
                        variant="default"
                        onClick={handleBackToFirstStep}
                        disabled={activeStep === 0}
                    >
                        Back
                    </Button>
                )}

                {activeStep === questions.length && score !== null && score !== questions.length && (
                    <Button onClick={handleBackToFirstStep}>
                        Repeat quiz
                    </Button>
                )}
                {activeStep === questions.length && score !== null && score === questions.length && (
                    <Button onClick={() => {
                        onClose();
                    }}>
                        End quiz
                    </Button>
                )}

                {activeStep < questions.length && (
                    <Button onClick={handleNextStep}>
                        Next
                    </Button>
                )}
            </Group>
        </div>
    );
};

export default QuizQuestion;
