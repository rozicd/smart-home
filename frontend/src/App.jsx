import "./App.css";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import { themeOptions } from "./themeOptions";
import BasicSelect from "./Components/BasicComponents/BasicSelect";
import { React, UseState, useState } from "react";
import BasicRadioButton from "./Components/BasicComponents/BasicRadioButtons";
import BasicInput from "./Components/BasicComponents/BasicInput";
import BasicForm from "./Components/BasicComponents/BasicForm";


const testform =
  [
    {
      item: "BasicInput",
      label: "Test",
      itemValue :"password"

    },
    {
      item: "BasicInput",
      label: "Test",
      itemValue :"test1"

    },
    {
      item: "BasicInput",
      label: "Test",
      itemValue :"test2"

    },
    {
      item: "BasicSelect",
      label: "Test",
      collection: [{ id: 1, name: "pera" }, { id: 2, name: "mika" }],
      valueParam: "id",
      nameParam: "name",
      itemValue :"lol",
      def:"Please select lol"

    },
    {
      item: "BasicRadio",
      label: "Test",
      choices: ["Male", "Female"],
      itemValue :"gender",
      identificator:"ASDSDAASD"

    },
    {
      item: "BasicRadio",
      label: "Test",
      choices: ["Male", "Female"],
      itemValue :"BENDER",
      identificator:"ASDASDAAAAASD"


    },
  ]
function App() {
  const [value, setValue] = useState(0)
  return (
    <ThemeProvider theme={themeOptions}>
      <BasicForm template={testform}/>
    </ThemeProvider>
  );
}

export default App;
