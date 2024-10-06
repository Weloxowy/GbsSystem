import React from 'react';
import {Button} from "@mantine/core";

interface AddToCalendarProps {
    date: Date;
    title: string;
}

const AddToCalendarOutlook: React.FC<AddToCalendarProps> = ({ date, title }) => {
    const handleAddToCalendar = () => {
        const formattedDate = date.toISOString().replace(/-|:|\.\d{3}/g, "");
        const endDate = new Date(date);
        endDate.setHours(date.getHours() + 1);
        const formattedEndDate = endDate.toISOString().replace(/-|:|\.\d{3}/g, "");
        const outlookUrl = `https://outlook.office.com/calendar/0/deeplink/compose?subject=${encodeURIComponent(title)}&startdt=${formattedDate}&enddt=${formattedEndDate}`;
        window.open(outlookUrl, '_blank');
    };

    return (
        <Button onClick={handleAddToCalendar} radius={"md"} size={"lg"}>
            Dodaj do Outlooka
        </Button>
    );
};

export default AddToCalendarOutlook;
