import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-confirmation-modal',
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.css']
})

export class ConfirmationModalComponent {
  @Output() confirmed = new EventEmitter<boolean>();

  message?: string;
  isVisible = false;

  show(message: string) {
    this.message = message;
    this.isVisible = true;
  }

  confirm(confirmed: boolean) {
    this.isVisible = false;
    this.confirmed.emit(confirmed);
  }
}
