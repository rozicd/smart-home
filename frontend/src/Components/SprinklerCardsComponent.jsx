import React, { useEffect, useRef, useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  Switch,
  FormControlLabel,
  Grid,
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableBody,
  TableCell,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
} from "@mui/material";
import EventLogCard from "./BasicComponents/EventLogCard";
import { turnOnSprinkler, turnOffSprinkler, addSchedule, removeSprinklerSchedule, addSprinklerSchedule, getSprinklerActions } from './Services/SprinklerService';
import { sprinklerHubConnection} from "./Sockets/SocketService"

const SprinklerCardsComponent = ({ deviceData }) => {
  const [isSwitchDisabled, setSwitchDisabled] = useState(false);
  const [eventLog, setEventLog] = useState([]);
  const [sprinklerData, setSprinklerData] = useState({power:deviceData.power,schedules:[...deviceData.schedules]});
  const [isDialogOpen, setDialogOpen] = useState(false);
  const [newScheduleData, setNewScheduleData] = useState({
    dateTime: new Date(),
    duration: 0,
  });
  const isSubscribedToActions = useRef(false);
  const [toDate,setToDate] = useState(null);
  const [fromDate,setFromDate] = useState(null);
  const handleSwitchChange = async () => {
    const newPower = !sprinklerData.power;

    setSprinklerData((prevSprinklerData) => ({ ...prevSprinklerData, power: newPower }));

    try {
      if (newPower) {
        await turnOnSprinkler(deviceData.id);
      } else {
        await turnOffSprinkler(deviceData.id);
      }
    } catch (error) {
      console.log(error);
    }
  };
  useEffect(() => {
    async function connect() {
      if (sprinklerHubConnection.state === "Disconnected") {
        await sprinklerHubConnection.start();
      }

      sprinklerHubConnection.on(deviceData.connection+"/power", (powerV) => {
        setSprinklerData({power:powerV,schedules:sprinklerData.schedules})
      });
      sprinklerHubConnection.on(
        deviceData.connection + "/schedule",
        (scheduleId) => {
          console.log(scheduleId)
          console.log(prevSprinklerData)
          setSprinklerData((prevSprinklerData) => ({
            ...prevSprinklerData,
            schedules: prevSprinklerData.schedules.filter(
              (schedule) => schedule.id !== scheduleId
            ),
          }));
        }
      );
      if (!isSubscribedToActions.current) {
        console.log("SUBSCRIBE ACTIONS");
        sprinklerHubConnection.on(
          deviceData.connection + "/action",
          (didAction, action) => {
            if (toDate === null || toDate === "") {
              console.log("CAO");
              const newAction = {
                user: didAction,
                action,
                timestamp: new Date().toISOString(),
              };
              setEventLog((prevHistory) => [...prevHistory, newAction]);
            }
          }
        );
        isSubscribedToActions.current = true;
      }
  
    }
    connect();
  }, []);
  const handleAddSchedule = async () => {
    try {
        const sprinklerResponse = await addSprinklerSchedule(deviceData.id, {
            startTime: newScheduleData.dateTime,
            durationMinutes: newScheduleData.duration,
        });

        setSprinklerData((prevSprinklerData) => ({
            ...prevSprinklerData,
            schedules: [...prevSprinklerData.schedules, sprinklerResponse],
        }));

        setDialogOpen(false);
    } catch (error) {
      console.log(error);
    }
  };

  const handleRemoveSchedule = async (scheduleId) => {
    try {
      await removeSprinklerSchedule(deviceData.id, scheduleId);
      setSprinklerData((prevSprinklerData) => ({
        ...prevSprinklerData,
        schedules: prevSprinklerData.schedules.filter((schedule) => schedule.id !== scheduleId),
      }));
    } catch (error) {
      console.log(error);
    }
  };
  useEffect(() => {

    const fetchData = async () => {
      try {
        let data = await getSprinklerActions(deviceData.id,fromDate,toDate)
        setEventLog(data)

      } catch (error) {
        console.log(error)
      } 
    };

    fetchData();
  }, [toDate,fromDate]);
  const handleDialogOpen = () => {
    setDialogOpen(true);
  };

  const handleDialogClose = () => {
    setDialogOpen(false);
  };

  const renderSchedulesTable = () => (
    <TableContainer style={{ margin: '2vh', width: '80%', height: '50%' }}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Start Time</TableCell>
            <TableCell>Duration (minutes)</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {sprinklerData.schedules.map((schedule) => (
            <TableRow key={schedule.id}>
              <TableCell>{schedule.startTime}</TableCell>
              <TableCell>{schedule.durationMinutes}</TableCell>
              <TableCell align="right">
                <Button variant="outlined" onClick={() => handleRemoveSchedule(schedule.id)}>
                  Remove
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );

  return (
    <Grid container spacing={2} style={{ width: "100%", margin: 0 }}>
      <Grid item xs={12} md={6}>
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
            <Typography variant="h6">Power</Typography>
            <Typography variant="h4">{sprinklerData.power ? "On" : "Off"}</Typography>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={12} md={6}>
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
            <Typography variant="h6">Sprinkler Switch</Typography>
            <FormControlLabel
              style={{ width: "80%", height: "20%" }}
              control={
                <Switch
                  checked={sprinklerData.power}
                  onChange={handleSwitchChange}
                  size="medium"
                />
              }
              label={sprinklerData.power ? "On" : "Off"}
              disabled={isSwitchDisabled}
            />
          </CardContent>
        </Card>
      </Grid>
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
            <Typography variant="h6">Schedules</Typography>
            {renderSchedulesTable()}
            <Button variant="outlined" onClick={handleDialogOpen}>
              Add Schedule
            </Button>
          </CardContent>
        </Card>
      </Grid>
      <Grid item xs={12} md={12}>
        <EventLogCard eventData={eventLog} setEndDate={setToDate} setStartDate={setFromDate} />
      </Grid>

      <Dialog open={isDialogOpen} onClose={handleDialogClose} fullWidth maxWidth="xs">
  <DialogTitle>Add Schedule</DialogTitle>
  <DialogContent>
    <div style={{ marginBottom: '16px', marginTop:'16px' }}>
      <TextField
        label="Start Time"
        type="datetime-local"
        value={newScheduleData.dateTime.toISOString().substring(0, 16)}
        onChange={(e) =>
          setNewScheduleData((prevData) => ({
            ...prevData,
            dateTime: new Date(e.target.value),
          }))
        }
        InputLabelProps={{
          shrink: true,
        }}
        fullWidth
      />
    </div>
    <div>
      <TextField
        label="Duration (minutes)"
        type="number"
        value={newScheduleData.duration}
        onChange={(e) =>
          setNewScheduleData((prevData) => ({
            ...prevData,
            duration: parseInt(e.target.value, 10),
          }))
        }
        fullWidth
      />
    </div>
  </DialogContent>
  <DialogActions>
    <Button onClick={handleDialogClose} color="primary">
      Cancel
    </Button>
    <Button onClick={handleAddSchedule} color="primary">
      Add
    </Button>
  </DialogActions>
</Dialog>

    </Grid>
  );
};

export default SprinklerCardsComponent;
