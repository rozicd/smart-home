import "./App.css";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import { themeOptions } from "./themeOptions";
import BasicSelect from "./Components/BasicComponents/BasicSelect";
import { React, UseState, useState } from "react";

function App() {

  return (
    <ThemeProvider theme={themeOptions}>
    </ThemeProvider>
  );
}

export default App;
