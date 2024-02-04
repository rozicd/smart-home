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

const ACHistoryComponent = ({acHistory, setEndDate, setStartDate}) => {

    const [searchTerm, setSearchTerm] = useState("");
    const [fromDate, setFromDate] = useState("");
    const [toDate, setToDate] = useState("");
    const [currentPage, setCurrentPage] = useState(1);
    const actionsPerPage = 4;
  
    const handleStartDateChange = (value) => {
        setFromDate(value);
        setStartDate(value);
      };
      const handleEndDateChange = (value) => {
        setToDate(value);
        setEndDate(value);
      };
    
    const filteredACHistory = acHistory.filter(
            (event) =>
            event.name.toLowerCase().includes(searchTerm.toLowerCase())

        );
    const dateFilteredActions = filteredACHistory.filter(() => true);

    const totalPages = Math.ceil(dateFilteredActions.length / actionsPerPage);

    const handlePageChange = (event, value) => {
        setCurrentPage(value);
      };
    const indexOfLastAction = currentPage * actionsPerPage;
    const indexOfFirstAction = indexOfLastAction - actionsPerPage;
    const currentActions = dateFilteredActions.slice(indexOfFirstAction, indexOfLastAction);
  
  const today = new Date().toISOString().split("T")[0];

    return(
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
          <Typography variant="h6">Action history</Typography>
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
              inputProps={{ max: today }}
            />
            <TextField
              label="To Date"
              type="date"
              value={toDate}
              onChange={(e) => handleEndDateChange(e.target.value)}
              InputLabelProps={{ shrink: true }}
              inputProps={{ max: today }} 
            />
          </div>
          <TableContainer style={{ margin: "2vh", width: "80%", maxHeight: "200px" }}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>User</TableCell>
                  <TableCell>Mode</TableCell>
                  <TableCell>Timestamp</TableCell>
                  <TableCell>Temperature</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {currentActions.map((action) => (
                  <TableRow key={action.id}>
                    <TableCell>{action.name}</TableCell>
                    <TableCell>{action.mode}</TableCell>
                    <TableCell>{new Date(action.timestamp).toLocaleString()}</TableCell>
                    <TableCell>{action.temperature}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
          {/* Pagination component */}
          <Pagination style = {{marginBottom:'10px'}}count={totalPages} page={currentPage} onChange={handlePageChange} color="primary" />
        </CardContent>
      </Card>
    )

}

export default ACHistoryComponent;