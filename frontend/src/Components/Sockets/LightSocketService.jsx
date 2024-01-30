import * as signalR from "@microsoft/signalr";

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/lampHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

const panelHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/panelHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();
const BatteryHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/batteryHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();
const ChargerHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/carChargerHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

const carGateHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/carGateHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

const propertyHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/propertyHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

export {
  propertyHubConnection,
  hubConnection,
  panelHubConnection,
  BatteryHubConnection,
  carGateHubConnection,
  ChargerHubConnection
};
