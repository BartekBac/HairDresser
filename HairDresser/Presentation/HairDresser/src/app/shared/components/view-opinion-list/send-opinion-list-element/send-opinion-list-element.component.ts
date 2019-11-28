import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Opinion } from 'src/app/shared/models/Opinion';
import { OpinionService } from 'src/app/shared/services/opinion.service';
import { MessageService, ConfirmationService } from 'primeng/primeng';
import { Functions } from 'src/app/shared/constants/Functions';

@Component({
  selector: 'app-send-opinion-list-element',
  templateUrl: './send-opinion-list-element.component.html',
  styleUrls: ['./send-opinion-list-element.component.css']
})
export class SendOpinionListElementComponent implements OnInit {

  @Input() opinion: Opinion;
  @Output() deletedOpinion = new EventEmitter<Opinion>();

  constructor(
    private opinionService: OpinionService,
    private toastService: MessageService,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit() {}

  deleteOpinion() {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to delete your opinion about: '
       + this.opinion.workerFirstName + ' ' + this.opinion.workerLastName + '?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      blockScroll: false,
      accept: () => {
        this.opinionService.deleteOpinion(this.opinion.id).subscribe(
          res => {
            this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Opinion deleted.'});
            this.deletedOpinion.emit(this.opinion);
          },
          err => {this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});}
        );
      }
    });
  }

  getRateColor() {
    return Functions.getOpinionRateColor(this.opinion.rate);
  }

}
