import "./App.css";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import { themeOptions } from "./themeOptions";
import BasicSelect from "./Components/BasicComponents/BasicSelect";
import { React, UseState, useState } from "react";
import BasicRadioButton from "./Components/BasicComponents/BasicRadioButtons";

function App() {
  const [value, setValue] = useState(0)
  return (
    <ThemeProvider theme={themeOptions}>
      <BasicRadioButton label={"test"} choices={["Male", "Female","Other"]} value={value} identificator={"test"} callback={(e)=>setValue(e.target.value)}/>
    </ThemeProvider>
  );
}

export default App;
