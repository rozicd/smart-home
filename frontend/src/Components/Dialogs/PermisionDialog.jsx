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

import { addUserPermission, removeUserPermission } from '../Services/PropertiesService';
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';

const PermisionDialog = ({ open, onClose, property, updatePermissions}) => {
  const [tagInput, setTagInput] = useState('');
  const [tags, setTags] = useState([]);
  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {

    console.log("TAGS:::");
    console.log(tags);
    if(property.sharedUsers){
      setTags(property.sharedUsers)
    }
  }, [property.sharedUsers]);

  const handleTagInputChange = (event) => {
    setTagInput(event.target.value);
  };

  const handleAddTag = async() => {
    if (tagInput.trim() !== '') {
      console.log(tagInput.trim())
      try{
        const response = await addUserPermission(property.id, tagInput.trim())
        if(response.status && response.status === 200){
          setTags([...tags, response.data]);
          setTagInput('');
          updatePermissions(tags);
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
      const response = await removeUserPermission(property.id, tagToRemove.id)
      if(response.status && response.status === 200){
        const updatedTags = tags.filter((tag) => tag !== tagToRemove);
        console.log(updatedTags)
        setTags(updatedTags);
        updatePermissions(tags);
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

export default PermisionDialog;
