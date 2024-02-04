import * as signalR from "@microsoft/signalr";

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/lampHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

const panelHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/panelHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();
const BatteryHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/batteryHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();
const ChargerHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/carChargerHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

const carGateHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/carGateHub", { withCredentials: true })
  .withAutomaticReconnect()
  .build();

const propertyHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/propertyHub", { withCredentials: true })
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
