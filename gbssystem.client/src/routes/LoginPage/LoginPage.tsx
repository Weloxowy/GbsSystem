import { useState, useEffect } from 'react';
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
} from '@mantine/core';

export default function LoginPage(props: PaperProps) {
    const [type, toggle] = useToggle(['login', 'register']);
    const [currentImage, setCurrentImage] = useState(0);
    const [fade, setFade] = useState(true);
    const images = [backgroundImage, backgroundImage1, backgroundImage2];

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
            setFade(false);
            setTimeout(() => {
                setCurrentImage((prevImage) => (prevImage + 1) % images.length);
                setFade(true);
            }, 1000);
        }, 5000);

        return () => clearInterval(interval);
    }, [images.length]);

    return (
        <div className={styles.pageContainer}>

            <div className={`${styles.background} ${fade ? styles['fade-in'] : styles['fade-out']}`} style={{ backgroundImage: `url(${images[currentImage]})` }} />


            <div className={styles.loginContainer}>
                <Paper
                    radius="md"
                    p="xl"
                    withBorder
                    {...props}
                    style={{ width: '30vw', maxWidth: '400px', padding: '40px' }}
                >
                    <Text size="lg" fw={500} style={{textAlign: 'center'}}>
                        Welcome to GbsSystem
                    </Text>
                    <Divider label="Continue with email" labelPosition="center" my="lg" />
                    <form onSubmit={form.onSubmit(() => {})}>
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
