import { Component } from '@angular/core';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
/** message component*/
export class MessagesComponent {
  /** message ctor */
  constructor(public messageService: MessageService) {

  }
}
