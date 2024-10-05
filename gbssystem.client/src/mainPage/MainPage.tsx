import { Button } from "@mantine/core";
import { useNavigate } from "react-router-dom";

export default function MainPage() {
  const navigation = useNavigate();
  return (
    <>
      <h1>STRONA GŁÓWNA</h1>
      <Button
        onClick={async () => {
          navigation("/Login");
        }}
      >
        LOGIN
      </Button>
      <Button
        onClick={async () => {
          navigation("/Register");
        }}
      >
        REJESTRACJA
      </Button>
      <Button
        onClick={async () => {
          navigation("/Planets");
        }}
      >
        Planets
      </Button>
    </>
  );
}
