import React from 'react';
import Button from '@mui/material/Button';
import { AddCircle } from '@mui/icons-material';

const AddButton = ({ onClick, className }) => {
  return (
    <AddCircle
      className={className}
      color="primary"
      onClick={onClick}
      style={{ position: 'fixed', bottom: 16, right: 16,  cursor: 'pointer',
      fontSize:'xx-large'}}
    >
      +
    </AddCircle>
  );
};

export default AddButton;
