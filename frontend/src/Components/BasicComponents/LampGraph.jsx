import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';

// const data = [
//   { timestamp: 'Timestamp1', batteryPercentage: 1 },
//   { timestamp: 'Timestamp2', batteryPercentage: 2 },
//   { timestamp: 'Timestamp3', batteryPercentage: 5 },
//   // ...
// ];
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
const LampGraph = ({ data }) => {
    const convertedData = convertTimestamps(data);

  
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
        <YAxis dataKey="powerStatus" />
        <CartesianGrid stroke="#eee" strokeDasharray="5 5" />
  
        <Line data={convertedData} type="monotone" dataKey="currentLight" stroke="blue" name="Current Light" />
  
        <Line data={convertedData} type="monotone" dataKey="powerStatus" stroke="green" name="Power status" />
  
        <Tooltip />
        <Legend />
      </LineChart>
    );
  };

export default LampGraph;
