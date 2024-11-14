import React, { useState, useEffect } from 'react';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField,
  Chip,
  Box,
  Typography,
} from '@mui/material';

import { addDeviceUserPermission, removeDeviceUserPermission } from '../Services/SmartDeviceService';

const DevicePermisionDialog = ({ open, onClose, users: sharedUsers, deviceId, updateUsers }) => {
  const [tagInput, setTagInput] = useState('');
  const [tags, setTags] = useState([]);
  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {

    console.log("TAGS:::");
    console.log(tags);
    if(sharedUsers){
      setTags(sharedUsers)
    }
  }, [sharedUsers]);

  const handleTagInputChange = (event) => {
    setTagInput(event.target.value);
  };

  const handleAddTag = async() => {
    if (tagInput.trim() !== '') {
      console.log(tagInput.trim())
      try{
        const response = await addDeviceUserPermission(deviceId, tagInput.trim())
        if(response.status && response.status === 200){
          setTags([...tags, response.data]);
          setTagInput('');
          updateUsers(tags);
          setErrorMessage("")
        }
        else{
          console.log(response);
        }
      
    }catch(error){
      setErrorMessage("User not found")
    }
      
      
    }
  };

  const handleRemoveTag = async (tagToRemove) => {
    try{
      console.log(tagToRemove);
      const response = await removeDeviceUserPermission(deviceId, tagToRemove.email)
      if(response.status && response.status === 200){
        const updatedTags = tags.filter((tag) => tag !== tagToRemove);
        console.log(updatedTags)
        setTags(updatedTags);
        updateUsers(tags);
      }
      else{
        
        console.log(response);
      }
    }catch(error)
    {
      console.log(error);
    }

  };

  const handleClose = () => {
    setTagInput('');
    onClose();
  };

  return (
    <Dialog  open={open} onClose={handleClose}>
      <DialogTitle>Permissions</DialogTitle>
      <DialogContent>
        <Box display="flex" alignItems="center">
          <TextField
            sx={{marginTop:"10px"}}
            label="Tag"
            value={tagInput}
            onChange={handleTagInputChange}
            fullWidth
          />
          <Button onClick={handleAddTag} color="primary" variant="contained" style={{ marginLeft: '8px' }}>
            Add
          </Button>
        </Box>
        {errorMessage !== "" && <Typography sx={{color:"red"}}>{errorMessage}</Typography>}
        <div style={{ marginTop: '10px' }}>
          {tags.map((tag, index) => (
            <Chip
              key={index}
              label={tag.name}
              onDelete={() => handleRemoveTag(tag)}
              style={{ margin: '4px' }}
            />
          ))}
        </div>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose} color="primary">
          Close
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default DevicePermisionDialog;
