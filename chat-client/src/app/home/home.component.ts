import { Component, OnInit, OnDestroy } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { User, Message } from '@app/_models';
import { AccountService, ChatService } from '@app/_services';
import { map } from 'rxjs/operators';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit, OnDestroy {
    user: User;
    public _hubConnection: HubConnection;
    public onlineUser: User[] = [];
    public chattingWithUser: User;
    public chatMessages: Message[] = [];

    constructor(private accountService: AccountService, private chatService: ChatService) {
        this.user = this.accountService.userValue;
    }

    ngOnInit() {
        this.signalrConn();
    }

    signalrConn() {
        //Init Connection
        this._hubConnection = new HubConnectionBuilder().withUrl("http://localhost:63742/chatHub?userId=" + this.user.id).build();

        //Call client methods from hub to update User
        this._hubConnection.on('UpdateUserList', (onlineuser) => {
            var list: User[] = [];
            list = JSON.parse(onlineuser);
            this.onlineUser = list.filter(x=>x.id != this.user.id);
        });

        //Call client methods from hub to update User
        this._hubConnection.on('ReceiveMessage', (message: Message) => {
            this.chattingWithUser = this.onlineUser.find(x => x.id == message.senderid);
            this.chatLog();
        });

        //Start Connection
        this._hubConnection
            .start()
            .then(function () {
                console.log("Connected");
            }).catch(function (err) {
                return console.error(err.toString());
            });
        }

        chatLog() {
            var param = { Senderid: this.user.id, Receiverid: this.chattingWithUser.id };
            this.chatService.getChatLog(param)
            .pipe(map(response => response.map(message => { 
                message.senderName = message.senderid == this.user.id ? this.user.firstName : this.chattingWithUser.firstName;
                message.receiverName = message.receiverid == this.user.id ? this.user.firstName : this.chattingWithUser.firstName;
                message.messagestatus = message.senderid == this.user.id ? "sent" : "received";
                return message; 
              })))
            .subscribe(messages => this.chatMessages = messages);
        }

        sendMessage(message) {
            //Send Message
            if (message != '') {
                var chatMessage = new Message();
                chatMessage.senderid = this.user.id;
                chatMessage.senderName = this.user.firstName;
                chatMessage.receiverid = this.chattingWithUser.id;
                chatMessage.receiverName = this.chattingWithUser.firstName;
                chatMessage.message = message;
                chatMessage.messagestatus = "sent";
                let dateTime = new Date();
                chatMessage.messagedate = dateTime;
                
                this._hubConnection.invoke('SendMessage', chatMessage).then((chatId: number) => {
                    chatMessage.chatid = chatId;
                    this.chatMessages.push(chatMessage);
                  }).catch(error => {
                  });
                }
            }

        deleteMessage(msgId: number, deleteActionType: number) {
            var deleteSuccess = false;
            var deleteFor = deleteActionType == 1 ? this.user.id : -1;
            this.chatService.deleteChat(msgId, deleteFor)
            .subscribe(result => {
                if (result) {
                    var index = this.chatMessages.findIndex(x=>x.chatid == msgId);
                    this.chatMessages.splice(index, 1);
                }

            });
        }

        chooseUser(user) {
            this.chattingWithUser = user;
            this.chatLog();
        }

        ngOnDestroy() {
            //Stop Connection
            this._hubConnection
                .stop()
                .then(function () {
                    console.log("Stopped");
                }).catch(function (err) {
                    return console.error(err.toString());
                });
        }
}