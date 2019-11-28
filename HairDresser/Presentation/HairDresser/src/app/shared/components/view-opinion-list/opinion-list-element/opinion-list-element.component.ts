import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Opinion } from 'src/app/shared/models/Opinion';
import { Functions } from 'src/app/shared/constants/Functions';
import { OpinionService } from 'src/app/shared/services/opinion.service';
import { MessageService, Inplace } from 'primeng/primeng';

@Component({
  selector: 'app-opinion-list-element',
  templateUrl: './opinion-list-element.component.html',
  styleUrls: ['./opinion-list-element.component.css']
})
export class OpinionListElementComponent implements OnInit {

  @Input() opinion: Opinion;
  @Input() answerEditMode: false;
  @ViewChild('ipAnswer', null) inplaceAnswer: Inplace;
  openedAnswerEdit = false;

  constructor(
    private opinionService: OpinionService,
    private toastService: MessageService
  ) { }

  ngOnInit() {}

  getRateColor(): string {
    return Functions.getOpinionRateColor(this.opinion.rate);
  }

  copyToClipboard(item) {
    let listener = (e: ClipboardEvent) => {
        e.clipboardData.setData('text/plain', (item));
        e.preventDefault();
    };

    document.addEventListener('copy', listener);
    document.execCommand('copy');
    document.removeEventListener('copy', listener);
  }

  updateAnswer() {
    this.opinionService.updateAnswer(this.opinion.id, this.opinion.answer).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded',
         detail: 'Answer to opinion updated.'});
        this.openedAnswerEdit = false;
      },
      err => {this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});}
    );
  }

  closeAnswerEdit() {
    this.inplaceAnswer.deactivate(null);
  }

}
