import React, { useState } from 'react';
import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Button,
  TextField,
} from '@mui/material';

const DescriptionDialog = ({ open, onClose, onOk }) => {
  const [description, setDescription] = useState('');
  const [error, setError] = useState('');

  const handleOk = () => {
    if (!description.trim()) {
      setError('Description cannot be empty.');
      return;
    }

    if (description.length > 255) {
      setError('Description cannot exceed 255 characters.');
      return;
    }

    onOk(description);

    setDescription('');
    setError('');

    onClose();
  };

  const handleCancel = () => {
    setDescription('');
    setError('');

    onClose();
  };

  return (
    <Dialog open={open} onClose={handleCancel}>
      <DialogTitle>Enter Rejection Description</DialogTitle>
      <DialogContent>
        <TextField
          label="Description"
          multiline
          rows={4}
          variant="outlined"
          fullWidth
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          error={Boolean(error)}
          helperText={error}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={handleCancel} color="secondary">
          Cancel
        </Button>
        <Button onClick={handleOk} color="primary">
          OK
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default DescriptionDialog;
