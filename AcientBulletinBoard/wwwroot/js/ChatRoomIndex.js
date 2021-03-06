"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var signalR = require("@microsoft/signalr");
$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    document.getElementById("sendButton").disabled = true;
    connection.on("ReceiveMessage", function (user, message) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    });
    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").nodeValue;
        var message = document.getElementById("messageInput").nodeValue;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
});
//# sourceMappingURL=ChatRoomIndex.js.map