// DeviceCharts.js
import React, { useEffect, useState } from "react";
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend, PieChart, Pie, Cell, Label } from "recharts";

// BarChartComponent
const BarChartComponent = ({ data, timeRange }) => {
  const [maxBar, setMaxBar] = useState(100);
  const [dedupedData,setDedupedData] = useState([{}]);
  useEffect(() => {
    if (timeRange && timeRange[0] === 'hours') {
      setMaxBar(100);
      setDedupedData([{}])
      setDedupedData(fillEmptyTimeRange(data,timeRange))
    } else if (timeRange && timeRange[0] === 'days') {
      setMaxBar(100);
      setDedupedData([{}])

      setDedupedData(fillEmptyTimeRange(data,timeRange))
    }
  },[data]);
  const fillEmptyTimeRange = (data, timeRange) => {
    let currentTime = new Date().getTime();
    if (timeRange[2]){
      currentTime = timeRange[2]
    }
    const isHours = timeRange[0] === 'hours';
    let timeThreshold = isHours ? 59 * 60 * 1000 : 23 * 60 * 60 * 1000;
  
    const existingTimestamps = new Map();
  
    data.forEach(entry => {
      const timestamp = new Date(entry.timestamp).getTime();
      const existingEntry = existingTimestamps.get(timestamp);
  
      if (!existingEntry || parseInt(existingEntry.percentage) < parseInt(entry.percentage)) {
        existingTimestamps.set(timestamp, entry);
      }
    });
  
    const allTimestamps = [];
    for (let i = 0; i < timeRange[1]; i++) {
      const timestamp = new Date(
        currentTime - (i * (isHours ? 60 * 60 * 1000 : 24 * 60 * 60 * 1000))
      ).getTime();
      allTimestamps.push(timestamp);
    }
  
    const emptyEntries = allTimestamps
      .filter(timestamp => {
        for (const [existingTimestamp, _] of existingTimestamps) {
          if (Math.abs(existingTimestamp - timestamp) <= timeThreshold) {
            return false; 
          }
        }
        return true; 
      })
      .map(timestamp => ({
        percentage: '0',
        duration: '0',
        units: isHours ? 'h' : 'd',
        timestamp: new Date(timestamp).toLocaleString(), 
      }));
  
    const deduplicatedData = [...existingTimestamps.values(), ...emptyEntries];
      
    let lastHr = 0
    deduplicatedData.forEach(entry => {
      if (isHours) {
        entry.timestamp = `-${lastHr}`;
        lastHr+=1
      } else {
        entry.timestamp = new Date(entry.timestamp).toISOString().split('T')[0];
      }
    });
  
    deduplicatedData.sort((a, b) => {
      if (isHours) {
        return parseInt(a.timestamp) - parseInt(b.timestamp);
      } else {
        return new Date(a.timestamp) - new Date(b.timestamp);
      }
    });
  
    return deduplicatedData;
  };
  

  const CustomTooltip = ({ active, payload, label }) => {
    if (active && payload && payload.length) {
      const data = payload[0].payload; // Assuming the first payload contains the data
  
      let timestampLabel;
      if (timeRange && timeRange[0] === 'hours') {
        timestampLabel = 'Hours from now';
      } else if (timeRange && timeRange[0] === 'days') {
        timestampLabel = 'Date';
      }
  
      const durationLabel = timeRange && timeRange[0] === 'hours' ? 'Minutes' : 'Hours';
  
      return (
        <div style={{ background: '#fff', border: '1px solid #ccc', padding: '10px', borderRadius: '5px' }}>
          <p>{`${timestampLabel}: ${data.timestamp}`}</p>
          <p>{`Duration: ${data.duration} ${durationLabel}`}</p>
          <p>{`Percentage: ${data.percentage}%`}</p>
        </div>
      );
    }
  
    return null;
  };

  return (
    <BarChart width={600} height={300} data={dedupedData}>
      <CartesianGrid stroke="#eee" strokeDasharray="5 5" />
      <XAxis dataKey="timestamp" />
      <YAxis domain={[0, maxBar]} />
      <Legend payload={[{ value: 'Online', type: 'rect', id: 'ID01', color: '#82ca9d' }]} />
      <Tooltip content={<CustomTooltip />} />
      <Bar dataKey="percentage" fill="#82ca9d" stackId="a" />
    </BarChart>
  );
};


const PieChartComponent = ({ data, timeRange }) => {
  let totalOnline;
  let totalOffline;
  let totalPercentage; // Corrected variable name
  let max = 0;
  let OnlinePercentage;
  let OfflinePercentage;
  if (timeRange && timeRange[0] === 'days') {
    max = timeRange[1] * 24;
  } else if (timeRange && timeRange[0] === 'hours') {
    max = timeRange[1] * 60;
  }

  console.log(max);

  if (data) {
    totalOnline = data.reduce((sum, entry) => sum + parseInt(entry.duration), 0);
    totalOffline = max - totalOnline;
    OnlinePercentage = totalOnline*100/max
    OfflinePercentage = max - OnlinePercentage
  } else {
    totalOnline = 0;
    totalOffline = max;
    OfflinePercentage = 100;
    OnlinePercentage = 0;
  }

  const pieData = [
    { name: "Online", value: totalOnline, value2: OnlinePercentage, color: "#82ca9d" },
    { name: "Offline", value: totalOffline, value2: OfflinePercentage,color: "#8884d8" },
  ];
  console.log(pieData);

  const units = timeRange && timeRange[0] === 'days' ? 'hours' : 'minutes';

  const renderCustomizedLabel = ({ cx, cy, midAngle, innerRadius, outerRadius, percent, index }) => {
    const radius = innerRadius + (outerRadius - innerRadius) * 0.5;
    const x = cx + radius * Math.cos(-midAngle * (Math.PI / 180));
    const y = cy + radius * Math.sin(-midAngle * (Math.PI / 180));
  
    const labelValue = index === 0 ? totalOnline : totalOffline; // Choose the appropriate value based on the slice
    const labelText = timeRange && timeRange[0] === 'days' ? `${labelValue} hours` : `${labelValue} minutes`;
  
    const isLeftSide = x > cx; // Check if the label is on the left side
    const distance = 70; // Adjust the distance based on your preference
    const textDistance = 20; // Adjust the distance of the text from the end of the line
  
    let textX, textY;
  
    if (index === 0) {
      // Position "Online" label at the top right
      textX = cx + outerRadius - textDistance;
      textY = cy - outerRadius + textDistance;
    } else {
      // Position "Offline" label at the bottom left
      textX = cx - outerRadius + textDistance;
      textY = cy + outerRadius - textDistance;
    }
  
    return (
      <g>
        {/* Label text */}
        <text
          x={textX}
          y={textY}
          fill={pieData[index].color}
          textAnchor={isLeftSide ? 'start' : 'end'} // Dynamically set textAnchor based on the side
          dominantBaseline="middle"
        >
          {`${labelText} (${(percent * 100).toFixed(2)}%)`}
        </text>
      </g>
    );
  };
  
  return (
    <PieChart width={600} height={300}>
      <Pie data={pieData} dataKey="value" nameKey="name" cx="50%" cy="50%" outerRadius={80} label={renderCustomizedLabel} labelLine={null}>
        {pieData.map((entry, index) => (
          <Cell key={`cell-${index}`} fill={entry.color} />
        ))}
        <Tooltip formatter={(value, name) => [`${value} ${units}`, `${value2}%`, name]} />
      </Pie>
      <Legend />
    </PieChart>
  );
}


export { BarChartComponent, PieChartComponent };
