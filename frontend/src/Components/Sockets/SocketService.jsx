import * as signalR from "@microsoft/signalr";

const lampHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/lampHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();


const ecsHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/ECSHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();

export { lampHubConnection, ecsHubConnection };