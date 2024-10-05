import React from 'react';
import { createEvent } from 'ics';
import {Button} from "@mantine/core";

interface AddToCalendarProps {
    date: Date;
    title: string;
}

const AddToCalendarIcs: React.FC<AddToCalendarProps> = ({ date, title }) => {
    const handleAddToCalendar = () => {
        const eventDate = [
            date.getFullYear(),
            date.getMonth() + 1,
            date.getDate(),
            date.getHours(),
            date.getMinutes(),
        ];

        const event = {
            start: eventDate as [number, number, number, number, number],
            duration: { hours: 1, minutes: 0 },
            title: title,
            description: '',
            location: '',
            url: 'http://localhost:8080',
            status: 'CONFIRMED',
            busyStatus: 'BUSY',
            organizer: { name: 'Organizer', email: 'organizer@example.com' },
        };

        createEvent(event, (error, value) => {
            if (error) {
                console.error('Error creating event:', error);
                return;
            }
            const icsContent = value;
            const blob = new Blob([icsContent], { type: 'text/calendar;charset=utf-8' });
            const url = URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.target = '_blank';
            a.download = `${title}.ics`;
            a.click();
            URL.revokeObjectURL(url);
        });
    };

    return (
        <Button onClick={handleAddToCalendar} radius={"md"} size={"lg"}>
            Dodaj do kalendarza
        </Button>
    );
};

export default AddToCalendarIcs;
