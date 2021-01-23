import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Message } from '@app/_models';
import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private http: HttpClient) {
  }

  getChatLog(param) {
    return this.http.get<Message[]>(`${environment.apiUrl}/chat/userChat?param=${JSON.stringify(param)}`);
  }

  deleteChat(msgId: number, deleteFor: number) {
    return this.http.delete<boolean>(`${environment.apiUrl}/chat/deletechat?chatId=${msgId}&deleteFor=${deleteFor}`);
  }

}
