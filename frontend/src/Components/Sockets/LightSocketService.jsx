import * as signalR from "@microsoft/signalr";

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/lampHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();

const panelHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/panelHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();
  const BatteryHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/batteryHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();


export { hubConnection,panelHubConnection,BatteryHubConnection };
