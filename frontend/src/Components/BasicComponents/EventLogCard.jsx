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
  Button,
  InputAdornment,
  Pagination,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";

const EventLogCard = ({ eventData, setEndDate, setStartDate }) => {
  const [searchTerm, setSearchTerm] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [sortOrder, setSortOrder] = useState("asc");
  const [currentPage, setCurrentPage] = useState(1);
  const eventsPerPage = 4;

  const handleSortChange = () => {
    setSortOrder((prevSortOrder) => (prevSortOrder === "asc" ? "desc" : "asc"));
  };
  const handleStartDateChange = (value) => {
    setFromDate(value);
    setStartDate(value);
  };
  const handleEndDateChange = (value) => {
    setToDate(value);
    setEndDate(value);
  };

  const filteredEvents = eventData.filter(
    (event) =>
      event.user.toLowerCase().includes(searchTerm.toLowerCase()) ||
      event.action.toLowerCase().includes(searchTerm.toLowerCase()) ||
      event.timestamp.toString().includes(searchTerm)
  );

  const dateFilteredEvents = filteredEvents.filter(() => true);

  const sortedEvents = dateFilteredEvents.sort((a, b) => {
    const timestampA = new Date(a.timestamp).getTime();
    const timestampB = new Date(b.timestamp).getTime();

    if (sortOrder === "asc") {
      return timestampA - timestampB;
    } else {
      return timestampB - timestampA;
    }
  });

  // Calculate total number of pages
  const totalPages = Math.ceil(sortedEvents.length / eventsPerPage);

  const handlePageChange = (event, value) => {
    setCurrentPage(value);
  };

  const indexOfLastEvent = currentPage * eventsPerPage;
  const indexOfFirstEvent = indexOfLastEvent - eventsPerPage;
  const currentEvents = sortedEvents.slice(indexOfFirstEvent, indexOfLastEvent);

  return (
    <Card style={{ height: "auto", width: "85%", margin: "auto" }}>
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
        <div style={{ display: "flex", justifyContent: "space-between", width: "80%",marginTop:"20px" }}>
          <TextField
            label="From Date"
            type="date"
            value={fromDate}
            onChange={(e) => handleStartDateChange(e.target.value)}
            InputLabelProps={{ shrink: true }}
          />
          <TextField
            label="To Date"
            type="date"
            value={toDate}
            onChange={(e) => handleEndDateChange(e.target.value)}
            InputLabelProps={{ shrink: true }}
          />
        </div>
        <TableContainer style={{ margin: "2vh", width: "80%", maxHeight: "200px" }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>User</TableCell>
                <TableCell>Action</TableCell>
                <TableCell>Timestamp</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {currentEvents.map((event) => (
                <TableRow key={event.id}>
                  <TableCell>{event.user}</TableCell>
                  <TableCell>{event.action}</TableCell>
                  <TableCell>{new Date(event.timestamp).toLocaleString()}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        {/* Pagination component */}
        <Pagination style = {{marginBottom:'10px'}}count={totalPages} page={currentPage} onChange={handlePageChange} color="primary" />
        <Button variant="outlined" size="large" onClick={handleSortChange}>
          Sort {sortOrder === "asc" ? <ArrowUpwardIcon /> : <ArrowDownwardIcon />}
        </Button>
      </CardContent>
    </Card>
  );
};

export default EventLogCard;
