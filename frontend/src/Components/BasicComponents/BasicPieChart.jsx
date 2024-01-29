import React from "react";
import { PieChart, Pie, Tooltip, Legend, Cell, Label } from "recharts";

const BasicPieChart = ({ data }) => {
  const COLORS = ["orange", "#00C49F"]; // Define colors for each value

  return (

    <PieChart width={400} height={400}>
      <Pie
        data={data}
        cx={200}
        cy={200}
        innerRadius={60}
        outerRadius={80}
        fill="#8884d8"
        dataKey="value"
        label={(entry) => (entry.value).toFixed(2)+" kWh"} // Display names as labels
      >
        {data.map((entry, index) => (
          <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
        ))}
       
      </Pie>
      <Tooltip />
      <Legend />
    </PieChart>
  );
};

export default BasicPieChart;
