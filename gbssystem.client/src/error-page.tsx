import { useRouteError } from "react-router-dom";
import {Button} from "@mantine/core";

export default function ErrorPage() {
    const error = useRouteError();
    console.error(error);

    return (
        <div style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            flexDirection: "column",
            height: "100vh",
            width: "100vw"
        }}>
            <h1>Oops!</h1>
            <p>Sorry, an unexpected error has occurred.</p>
            <p>
                <i>{error.statusText || error.message}</i>
            </p>
                <Button>ddd</Button>
        </div>

    );
}