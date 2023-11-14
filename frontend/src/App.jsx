import "./App.css";
import BasicButton from "./Components/BasicComponents/BasicButton";
import {ThemeProvider,createTheme} from "@mui/material/styles";
import { themeOptions } from "./themeOptions";


function App() {
  return (
    <ThemeProvider theme ={themeOptions}>
      <BasicButton text={"xd"} color={"negative"}/>
      </ThemeProvider>
  );
}

export default App;
