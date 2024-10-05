import React from 'react';
import {Button} from "@mantine/core";
import {IconArrowRight} from '@tabler/icons-react';

interface AddToCalendarProps {
    date: Date;
    title: string;
}

const AddToCalendar: React.FC<AddToCalendarProps> = ({ date, title }) => {
    const handleAddToCalendar = () => {
        const formattedDate = date.toISOString().replace(/-|:|\.\d{3}/g, "");
        const endDate = new Date(date);
        endDate.setHours(date.getHours() + 1); // Przykład wydarzenia na 1 godzinę
        const formattedEndDate = endDate.toISOString().replace(/-|:|\.\d{3}/g, "");

        // URL dla tworzenia wydarzenia w Outlook Web
        const outlookUrl = `https://outlook.office.com/calendar/0/deeplink/compose?subject=${encodeURIComponent(title)}&startdt=${formattedDate}&enddt=${formattedEndDate}`;

        // Otwieramy Outlook Web z predefiniowanym wydarzeniem
        window.open(outlookUrl, '_blank');
    };

    return (
        <Button onClick={handleAddToCalendar} rightSection={<IconArrowRight size={14} />} radius={"lg"}>
            Dodaj do Outlooka
        </Button>
    );
};

export default AddToCalendar;
