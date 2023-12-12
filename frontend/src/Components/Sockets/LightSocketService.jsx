import * as signalR from "@microsoft/signalr";

const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5090/lampHub",{withCredentials:true})
  .withAutomaticReconnect()
  .build();


export { hubConnection };
