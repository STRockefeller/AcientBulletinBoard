import * as signalR from "../../node_modules/@microsoft/signalr"

$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    //Disable send button until connection is established
    (<HTMLButtonElement>document.getElementById("sendButton")).disabled=false;
    
    connection.on("ReceiveMessage", function (user, message) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    });
    
    connection.start().then(function () {
        (<HTMLButtonElement>document.getElementById("sendButton")).disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });
    
    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = (<HTMLInputElement>document.getElementById("userInput")).value;
        var message = (<HTMLInputElement>document.getElementById("messageInput")).value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
})