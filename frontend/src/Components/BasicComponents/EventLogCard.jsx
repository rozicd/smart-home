// Import necessary Material-UI components
import React, { useState } from "react";
import {
  Card,
  CardContent,
  Typography,
  TextField,
  TableContainer,
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  IconButton,
  InputAdornment,
  Button,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";

const eventData = [
  { id: 1, user: "User1", action: "Action1", date: "2023-01-01" },
];

const EventLogCard = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [sortOrder, setSortOrder] = useState("asc");

  const handleSortChange = () => {
    setSortOrder((prevSortOrder) => (prevSortOrder === "asc" ? "desc" : "asc"));
  };

  const filteredEvents = eventData.filter(
    (event) =>
      event.user.toLowerCase().includes(searchTerm.toLowerCase()) ||
      event.action.toLowerCase().includes(searchTerm.toLowerCase()) ||
      event.date.includes(searchTerm)
  );

  const dateFilteredEvents = filteredEvents.filter((event) => {
    if (fromDate && toDate) {
      return event.date >= fromDate && event.date <= toDate;
    } else {
      return true;
    }
  });

  const sortedEvents = dateFilteredEvents.sort((a, b) => {
    if (sortOrder === "asc") {
      return a.date.localeCompare(b.date);
    } else {
      return b.date.localeCompare(a.date);
    }
  });

  return (
    <Card style={{ height: "40vh", width: "85%", margin: "auto" }}>
      <CardContent
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "space-evenly",
          height: "80%",
        }}
      >
        <Typography variant="h6">Event Log</Typography>
        <TextField
          label="Search"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                <SearchIcon />
              </InputAdornment>
            ),
          }}
        />
        <div style={{ display: "flex", justifyContent: "space-between", width: "80%" }}>
          <TextField
            label="From Date"
            type="date"
            value={fromDate}
            onChange={(e) => setFromDate(e.target.value)}
            InputLabelProps={{ shrink: true }}
          />
          <TextField
            label="To Date"
            type="date"
            value={toDate}
            onChange={(e) => setToDate(e.target.value)}
            InputLabelProps={{ shrink: true }}
          />
        </div>
        <TableContainer style={{ margin: "2vh", width: "80%", height: "50%" }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>User</TableCell>
                <TableCell>Action</TableCell>
                <TableCell>Date</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {sortedEvents.map((event) => (
                <TableRow key={event.id}>
                  <TableCell>{event.user}</TableCell>
                  <TableCell>{event.action}</TableCell>
                  <TableCell>{event.date}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <Button variant="outlined" size="large" onClick={handleSortChange}>
          Sort {sortOrder === "asc" ? <ArrowUpwardIcon /> : <ArrowDownwardIcon />}
        </Button>
      </CardContent>
    </Card>
  );
};

export default EventLogCard;
