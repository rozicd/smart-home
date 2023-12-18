import React from 'react';
import { LineChart, XAxis, YAxis, CartesianGrid, Line, Tooltip, Legend } from 'recharts';

const convertTimestamps = data => {
  return data.map(item => ({
    ...item,
    timestamp: new Date(item.timestamp).getTime(),
  }));
};

const formatDate = timestamp => {
  const date = new Date(timestamp);
  return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()} ${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;
};

const BasicPowerGraph = ({ data }) => {
  const convertedData = convertTimestamps(data);

  const batteryData = convertedData.filter(item => item.target === 'Battery');
  const gridData = convertedData.filter(item => item.target === 'Grid');

  const minTimestamp = Math.min(...convertedData.map(item => item.timestamp));
  const maxTimestamp = Math.max(...convertedData.map(item => item.timestamp));

  return (
    <LineChart data={convertedData} width={600} height={300}>
      <XAxis
        dataKey="timestamp"
        type="number"
        domain={[minTimestamp, maxTimestamp]}
        tickFormatter={formatDate}
      />
      <YAxis dataKey="energy" />
      <CartesianGrid stroke="#eee" strokeDasharray="5 5" />

      {batteryData.length > 0 && (
        <Line data={batteryData} type="monotone" dataKey="energy" stroke="blue" name="Battery" />
      )}

      {gridData.length > 0 && (
        <Line data={gridData} type="monotone" dataKey="energy" stroke="red" name="Grid" />
      )}

      <Tooltip />
      <Legend />
    </LineChart>
  );
};

export default BasicPowerGraph;
