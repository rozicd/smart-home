import "./App.css";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import { themeOptions } from "./themeOptions";
import BasicSelect from "./Components/BasicComponents/BasicSelect";
import { React, UseState, useEffect, useState } from "react";
import BasicRadioButton from "./Components/BasicComponents/BasicRadioButtons";
import BasicInput from "./Components/BasicComponents/BasicInput";
import BasicForm from "./Components/BasicComponents/BasicForm";
import { signIn } from "./Components/Services/UserService";
import UserPropertiesPage from "./Pages/UserPropertiesPage";
import RegisterComponent from "./Components/BasicComponents/RegisterComponent";


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
  const [userId,setUserId] = useState('')

  useEffect(() => {
    const signInAndFetchUserId = async () => {
      try {
        const credentials = { email: 'user@example.com', password: 'stringst' };
        const userData = await signIn(credentials);
        const id = userData.id;
        setUserId(id);
      } catch (error) {
        console.error('Error signing in:', error);
      }
    };

    signInAndFetchUserId();
  }, []);


  return (
    <ThemeProvider theme={themeOptions}>
      {/* "<RegisterComponent></RegisterComponent>
      <BasicForm template={testform}/>" */}
      {/* <BasicRadioButton label={"test"} choices={["Male", "Female","Other"]} value={value} identificator={"test"} callback={(e)=>setValue(e.target.value)}/> */}
      { <UserPropertiesPage userId={userId}/> }
    </ThemeProvider>
  );
}

export default App;
