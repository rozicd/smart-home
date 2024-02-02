import * as signalR from "@microsoft/signalr";

const lampHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/lampHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();

  const sprinklerHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/sprinklerHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();
const ecsHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/ECSHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();

const ACHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/ACHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();
  const WMHubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/WMHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();


export { lampHubConnection, ecsHubConnection, ACHubConnection,sprinklerHubConnection, WMHubConnection };
