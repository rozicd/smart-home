import  React, {useEffect, useState} from 'react';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import ListItemText from '@mui/material/ListItemText';
import Select from '@mui/material/Select';
import Checkbox from '@mui/material/Checkbox';
import { getWashingMachineModes } from '../Services/WashingMachineService';

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 200,
    },
  },
};



export default function MultipleSelect({onModeChange}) {
    const [modes, setModes] = useState([]);
    const [personName, setPersonName] = useState([]);
  
    useEffect(() => {
      const fetchModes = async () => {
        try {
          const modesData = await getWashingMachineModes();
          setModes(modesData.washingMachineModes);
        } catch (error) {
          console.error('Error fetching modes:', error);
        }
      };
  
      fetchModes();
    }, []);
  
    const handleChange = (event) => {
      const {
        target: { value },
      } = event;
      setPersonName(
        // On autofill we get a stringified value.
        typeof value === 'string' ? value.split(',') : value,
      );

    };

    useEffect (() =>{
        onModeChange(personName)

    }, [personName])
  
    return (
      <div>
        <FormControl sx={{ m: 1, width: 200, marginTop : "20px" }}>
          <InputLabel id="demo-multiple-checkbox-label">Tag</InputLabel>
          <Select
            labelId="demo-multiple-checkbox-label"
            id="demo-multiple-checkbox"
            multiple
            value={personName}
            onChange={handleChange}
            input={<OutlinedInput label="Modes" />}
            renderValue={(selected) => selected.map((mode) => mode.name).join(', ')}
            MenuProps={MenuProps}
          >
            {modes.map((mode) => (
              <MenuItem key={mode.id} value={mode}>
                <Checkbox checked={personName.indexOf(mode) > -1} />
                <ListItemText primary={mode.name} />
              </MenuItem>
            ))}
          </Select>
        </FormControl>
      </div>
    );
  }
  