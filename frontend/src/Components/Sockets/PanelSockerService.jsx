import * as signalR from "@microsoft/signalr";

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:8080/api/lampHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();


export { hubConnection };
