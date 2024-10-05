import React from 'react';
import {Button} from "@mantine/core";

interface AddToCalendarProps {
    date: Date;
    title: string;
    description?: string;
}

const AddToCalendarGoogle: React.FC<AddToCalendarProps> = ({ date, title, description = ''}) => {
    const handleAddToCalendar = () => {
        const formattedDate = date.toISOString().replace(/-|:|\.\d{3}/g, "").slice(0, 15) + 'Z';
        const endDate = new Date(date);
        endDate.setHours(date.getHours() + 1);
        const formattedEndDate = endDate.toISOString().replace(/-|:|\.\d{3}/g, "").slice(0, 15) + 'Z';
        const googleCalendarUrl = `https://calendar.google.com/calendar/render?action=TEMPLATE&text=${encodeURIComponent(title)}&dates=${formattedDate}/${formattedEndDate}&details=${encodeURIComponent(description)}`;
        window.open(googleCalendarUrl, '_blank');
    };

    return (
        <Button onClick={handleAddToCalendar} radius={"md"} size={"lg"}>
            Dodaj do Google Calendar
        </Button>
    );
};

export default AddToCalendarGoogle;
