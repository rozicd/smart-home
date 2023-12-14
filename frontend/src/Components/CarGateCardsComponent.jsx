import React, { useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  Switch,
  FormControlLabel,
  Grid,
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Chip,
  Select,
  MenuItem,
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableBody,
  TableCell,
  IconButton,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";

const CarGateCardsComponent = ({ deviceData }) => {
  const [gateData, setGateData] = useState({
    mode: "PRIVATE",
    status: "CLOSED",
    allowedLicensePlates: [...deviceData.allowedLicensePlates],
  });
  const [isSwitchDisabled, setSwitchDisabled] = useState(false);
  const [isDialogOpen, setDialogOpen] = useState(false);
  const [newLicensePlate, setNewLicensePlate] = useState("");

  const handleSwitchChange = () => {
    // Implement switch change logic when services are available
  };

  const handleModeChange = (event) => {
    const newMode = event.target.value;
    setGateData((prevGateData) => ({ ...prevGateData, mode: newMode }));
  };

  const handleAddLicensePlate = () => {
    if (newLicensePlate.trim() !== "") {
      setGateData((prevGateData) => ({
        ...prevGateData,
        allowedLicensePlates: [...prevGateData.allowedLicensePlates, newLicensePlate],
      }));
      setNewLicensePlate("");
    }
  };

  const handleRemoveLicensePlate = (index) => {
    setGateData((prevGateData) => ({
      ...prevGateData,
      allowedLicensePlates: prevGateData.allowedLicensePlates.filter((_, i) => i !== index),
    }));
  };

  const handleDialogOpen = () => {
    setDialogOpen(true);
  };

  const handleDialogClose = () => {
    setDialogOpen(false);
    setNewLicensePlate("");
  };

  const handleSaveAllowedLicensePlates = () => {
    // Implement save logic when services are available
    setDialogOpen(false);
  };

  const renderLicensePlatesTable = () => (
    <TableContainer style={{ margin: '2vh', width: '80%' }}>
      <Table>
        <TableBody>
          {gateData.allowedLicensePlates.map((plate, index) => (
            <TableRow key={index} style={{ maxWidth: '80%' }}>
              <TableCell style={{ width: '50%', fontSize: '1.2em', whiteSpace: 'nowrap', overflow: 'hidden', textOverflow: 'ellipsis' }}>
                {plate}
              </TableCell>
              <TableCell align="right">
                <IconButton onClick={() => handleRemoveLicensePlate(index)}>
                  <CloseIcon />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );


  return (
    <Grid container spacing = {2} style={{ width: "100%", margin: 0 }}>
      {/* Card for displaying gate status without the switch */}
      <Grid item xs={12} md={5}>
        <Card style={{ height: "30vh", width: "90%", margin: "auto" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%",
            }}
          >
            <Typography variant="h6">Gate Status</Typography>
            <Typography variant="h4">{gateData.status}</Typography>
          </CardContent>
        </Card>
      </Grid>
      <Grid container item xs={12} md={7} display={"flex"} flexDirection={"row"}>
        <Card style={{ height: "30vh", width: "45%", margin: "auto" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%",
            }}
          >
            <Typography variant="h6">Change Mode</Typography>
            <Select
              value={gateData.mode}
              onChange={handleModeChange}
              style={{ width: "80%", height: "20%",justifyContent: "center"}}
            >
              <MenuItem value="PRIVATE">Private</MenuItem>
              <MenuItem value="PUBLIC">Public</MenuItem>
            </Select>
          </CardContent>
        </Card>

        <Card style={{ height: "30vh", width: "45%", margin: "auto" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%",
            }}
          >
            <Typography variant="h6">Gate Switch</Typography>
            <FormControlLabel
              style={{ width: "80%", height: "20%" }}
              control={<Switch checked={!isSwitchDisabled} onChange={handleSwitchChange} size="medium" />}
              label={isSwitchDisabled ? "Close" : "Open"}
              disabled={isSwitchDisabled}
            />
          </CardContent>
        </Card>
      </Grid>
      {/* Card for displaying and interacting with allowed license plates */}
      <Grid item xs={12} md={12}>
        <Card style={{ height: "30vh", width: "90%", margin: "auto" }}>
          <CardContent
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
              justifyContent: "space-evenly",
              height: "80%",


            }}
          >
            <Typography variant="h6">Allowed License Plates</Typography>
            {renderLicensePlatesTable()}
            <Button variant="outlined" size="large" onClick={handleDialogOpen}>
              Add License Plate
            </Button>
          </CardContent>
        </Card>
      </Grid>


     

      {/* Dialog for adding/removing allowed license plates */}
      <Dialog open={isDialogOpen} onClose={handleDialogClose} >
        <DialogTitle>Add Allowed License Plates</DialogTitle>
        <DialogContent>
          <TextField
            label="New License Plate"
            value={newLicensePlate}
            onChange={(e) => setNewLicensePlate(e.target.value)}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleDialogClose}>Close</Button>
          <Button onClick={handleAddLicensePlate}>Add</Button>
        </DialogActions>
      </Dialog>
    </Grid>
  );
};

export default CarGateCardsComponent;
