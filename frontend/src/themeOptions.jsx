import { ThemeOptions } from '@mui/material/styles';
import {createTheme} from "@mui/material/styles";

export const themeOptions = createTheme({
  palette: {
    primary: {
      main: '#00AEAE',
      contrastText :'white'
    },
    secondary: {
      main: '#ffffff',

    },
    negative :
    {
      main:"#cf142b",
      contrastText :'white'

    }
  },
  typography: {
    button : 
    {
      fontSize:18,
    },
    fontFamily: 'sans-serif', 
    fontSize:12
  },
});