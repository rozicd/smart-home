// DeviceCharts.js
import React, { useEffect, useState } from "react";
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend, PieChart, Pie, Cell, Label } from "recharts";

// BarChartComponent
const BarChartComponent = ({ data, timeRange }) => {
  const [maxBar, setMaxBar] = useState(100);
  const [dedupedData,setDedupedData] = useState([{}]);

  useEffect(() => {
    console.log(data)
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
    deduplicatedData.sort((a, b) => {
      if (isHours) {
        return new Date(a.timestamp) - new Date(b.timestamp);
      } else {
        return new Date(a.timestamp) - new Date(b.timestamp);
      }
    });

    deduplicatedData.reverse().forEach(entry => {
      console.log(entry)
      if (isHours) {
        entry.timestamp = `-${lastHr}`;
        lastHr+=1
      } else {
        entry.timestamp = new Date(entry.timestamp).toISOString().split('T')[0];
      }
    });
    deduplicatedData.reverse()
  
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

  const renderCustomizedLabel = ({ cx, cy, innerRadius, outerRadius, percent, index }) => {
    const topRightX = cx + outerRadius+70; // Adjust the x-coordinate for top right label
    const topRightY = cy - outerRadius-25; // Adjust the y-coordinate for top right label
  
    const bottomLeftX = cx - outerRadius-70; // Adjust the x-coordinate for bottom left label
    const bottomLeftY = cy + outerRadius+25; // Adjust the y-coordinate for bottom left label
  
    const labelValue = index === 0 ? totalOnline : totalOffline;
    const labelText = timeRange && timeRange[0] === 'days' ? `${labelValue} hours` : `${labelValue} minutes`;
  
    return (
      <g>
        {index === 0 && (
          <text
            x={topRightX}
            y={topRightY}
            fill={pieData[0].color}
            textAnchor="end"
            dominantBaseline="hanging"
          >
            {`${labelText} (${(percent * 100).toFixed(2)}%)`}
          </text>
        )}
  
        {index === 1 && (
          <text
            x={bottomLeftX}
            y={bottomLeftY}
            fill={pieData[1].color}
            textAnchor="start"
            dominantBaseline="baseline"
          >
            {`${labelText} (${(percent * 100).toFixed(2)}%)`}
          </text>
        )}
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
