import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';

// const data = [
//   { timestamp: 'Timestamp1', batteryPercentage: 1 },
//   { timestamp: 'Timestamp2', batteryPercentage: 2 },
//   { timestamp: 'Timestamp3', batteryPercentage: 5 },
//   // ...
// ];

const BasicGraph = ({data,datakey = "energy",width=600,height=300}) => (
  <LineChart width={width} height={height} data={data}>
    <XAxis dataKey="timestamp" />
    <YAxis dataKey={datakey}/>
    <CartesianGrid stroke="#eee" strokeDasharray="5 5" />
    <Line type="monotone" dataKey={datakey} stroke="#8884d8" />
    {ah && (<Line type="monotone" dataKey="airHumidity" stroke="#8884d8" />)}
    <Tooltip />
    <Legend />
  </LineChart>
);

export default BasicGraph;
