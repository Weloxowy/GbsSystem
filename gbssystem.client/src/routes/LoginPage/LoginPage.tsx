import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom'; // Import React Router for navigation
import styles from './LoginPage.module.css'; // importuj plik CSS
import backgroundImage from '../../assets/Zdj_hackaton_1.jpeg';
import backgroundImage1 from '../../assets/Zdj_hackaton_2.jpeg';
import backgroundImage2 from '../../assets/Zdj_hackaton_3.jpeg';

import { useToggle, upperFirst } from '@mantine/hooks';
import { useForm } from '@mantine/form';
import {
    TextInput,
    PasswordInput,
    Text,
    Paper,
    Group,
    Button,
    Divider,
    Checkbox,
    Anchor,
    Stack,
    PaperProps,
    Notification,
} from '@mantine/core';

export default function LoginPage(props: PaperProps) {
    const [type, toggle] = useToggle(['login', 'register']);
    const [currentImage, setCurrentImage] = useState(0); // stan dla aktualnego zdjęcia
    const [fade, setFade] = useState(true); // stan dla klasy fade-in/fade-out
    const [errorMessage, setErrorMessage] = useState(''); // stan dla błędów rejestracji/logowania
    const navigate = useNavigate(); // Hook do nawigacji
    const images = [backgroundImage, backgroundImage1, backgroundImage2]; // tablica ze zdjęciami

    const form = useForm({
        initialValues: {
            email: '',
            name: '',
            password: '',
            terms: true,
        },

        validate: {
            email: (val) => (/^\S+@\S+$/.test(val) ? null : 'Invalid email'),
            password: (val) => (val.length <= 6 ? 'Password should include at least 6 characters' : null),
        },
    });

    useEffect(() => {
        const interval = setInterval(() => {
            setFade(false); // uruchomienie fade-out
            setTimeout(() => {
                setCurrentImage((prevImage) => (prevImage + 1) % images.length); // zmiana obrazu
                setFade(true); // uruchomienie fade-in po zmianie
            }, 1000); // czas trwania fade-out to 1 sekunda
        }, 5000); // zmiana tła co 5 sekund

        return () => clearInterval(interval); // czyszczenie interwału po unmount
    }, [images.length]);

    // Funkcja do obsługi rejestracji
    const handleRegister = async () => {
        const registrationData = {
            password: form.values.password,
            email: form.values.email,
            firstName: form.values.name.split(' ')[0], // Zakładając, że imię to pierwszy człon pola "name"
            lastName: form.values.name.split(' ')[1] || '', // Zakładając, że nazwisko to drugi człon
            birthday: new Date().toISOString(), // Przykładowa data urodzenia (możesz zastąpić innym źródłem danych)
        };

        try {
            const response = await fetch('https://localhost:7098/api/AspNetUsers/registerCustom', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    accept: 'text/plain',
                },
                body: JSON.stringify(registrationData),
            });

            if (!response.ok) {
                throw new Error('Registration failed'); // Obsługa błędów
            }

            // Pomyślna rejestracja - automatyczne logowanie
            await handleLogin(); // Wywołanie funkcji logowania po udanej rejestracji
        } catch (error) {
            setErrorMessage('Registration failed. Please try again.');
        }
    };


    // Funkcja do obsługi logowania
    const handleLogin = async () => {
        const loginData = {
            email: form.values.email,
            password: form.values.password,
            twoFactorCode: '', // Jeśli nie używasz kodów dwuetapowych, zostaw puste
            twoFactorRecoveryCode: '', // Jeśli nie używasz kodów odzyskiwania, zostaw puste
        };

        try {
            const response = await fetch('https://localhost:7098/login?useSessionCookies=true', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    accept: 'application/json',
                },
                body: JSON.stringify(loginData),
                credentials: 'include', // Dodaj to, aby ciasteczka były uwzględnione
            });

            if (!response.ok) {
                throw new Error('Login failed'); // Obsługa błędów
            }

            // Pomyślne logowanie - przekierowanie użytkownika do /Menu

            navigate('/Menu');
        } catch (error) {
            setErrorMessage('Login failed. Please check your credentials.');
        }
    };


    return (
        <div className={styles.pageContainer}>
            {/* Kontener dla tła */}
            <div className={`${styles.background} ${fade ? styles['fade-in'] : styles['fade-out']}`} style={{ backgroundImage: `url(${images[currentImage]})` }} />

            {/* Statyczny komponent logowania */}
            <div className={styles.loginContainer}>
                <Paper
                    radius="md"
                    p="xl"
                    withBorder
                    {...props}
                    style={{ width: '30vw', maxWidth: '400px', padding: '40px' }} // Ustalona szerokość w proporcji do ekranu
                >
                    <Text size="lg" fw={500}>
                        Welcome to GbsSystem, {type} with
                    </Text>
                    <Divider label="Or continue with email" labelPosition="center" my="lg" />
                    {errorMessage && (
                        <Notification color="red" title="Error" onClose={() => setErrorMessage('')}>
                            {errorMessage}
                        </Notification>
                    )}
                    <form onSubmit={form.onSubmit(() => {
                        if (type === 'register') {
                            handleRegister(); // Wywołanie rejestracji
                        } else if (type === 'login') {
                            handleLogin(); // Wywołanie logowania
                        }
                    })}>
                        <Stack>
                            {type === 'register' && (
                                <TextInput
                                    label="Name"
                                    placeholder="Your name"
                                    value={form.values.name}
                                    onChange={(event) => form.setFieldValue('name', event.currentTarget.value)}
                                    radius="md"
                                />
                            )}

                            <TextInput
                                required
                                label="Email"
                                placeholder="hello@mantine.dev"
                                value={form.values.email}
                                onChange={(event) => form.setFieldValue('email', event.currentTarget.value)}
                                error={form.errors.email && 'Invalid email'}
                                radius="md"
                            />

                            <PasswordInput
                                required
                                label="Password"
                                placeholder="Your password"
                                value={form.values.password}
                                onChange={(event) => form.setFieldValue('password', event.currentTarget.value)}
                                error={form.errors.password && 'Password should include at least 6 characters'}
                                radius="md"
                            />

                            {type === 'register' && (
                                <Checkbox
                                    label="I accept terms and conditions"
                                    checked={form.values.terms}
                                    onChange={(event) => form.setFieldValue('terms', event.currentTarget.checked)}
                                />
                            )}
                        </Stack>

                        <Group justify="space-between" mt="xl">
                            <Anchor component="button" type="button" c="dimmed" onClick={() => toggle()} size="xs">
                                {type === 'register'
                                    ? 'Already have an account? Login'
                                    : "Don't have an account? Register"}
                            </Anchor>
                            <Button type="submit" radius="xl">
                                {upperFirst(type)}
                            </Button>
                        </Group>
                    </form>
                </Paper>
            </div>
        </div>
    );
}
