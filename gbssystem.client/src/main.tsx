import '@mantine/core/styles.css';
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import Root from "./routes/root";
import ErrorPage from "./error-page.tsx";
import {MantineProvider} from "@mantine/core";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Root />,
        errorElement: <ErrorPage />,
    },
]);


createRoot(document.getElementById('root')!).render(
    <MantineProvider defaultColorScheme={"auto"}>
  <StrictMode>
      <RouterProvider router={router} />
  </StrictMode>
    </MantineProvider>,
)
