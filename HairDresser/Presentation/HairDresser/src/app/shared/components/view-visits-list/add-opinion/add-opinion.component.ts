import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { OpinionCreation } from '../../../../client/models/OpinionCreation';
import * as jwt_decode from 'jwt-decode';
import { Constants } from 'src/app/shared/constants/Constants';
import { OpinionService } from 'src/app/shared/services/opinion.service';
import { MessageService } from 'primeng/primeng';
import { Opinion } from 'src/app/shared/models/Opinion';
import { Functions } from '../../../constants/Functions';

@Component({
  selector: 'app-add-opinion',
  templateUrl: './add-opinion.component.html',
  styleUrls: ['./add-opinion.component.css']
})
export class AddOpinionComponent implements OnInit {

  @Input() workerId: string;
  @Input() visitId: string;
  @Output() addedOpinion = new EventEmitter<Opinion>();
  @Output() closeDialog = new EventEmitter<boolean>();
  userId: string;
  opinionCreation: OpinionCreation;

  constructor(
    private opinionService: OpinionService,
    private toastService: MessageService
  ) { }

  ngOnInit() {
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.opinionCreation = {
      clientId: this.userId,
      workerId: this.workerId,
      visitId: this.visitId,
      description: '',
      rate: 3,
      imageSource: ''
    };
  }

  onImageUpload(imageSource: any) {
    this.opinionCreation.imageSource = imageSource;
  }

  getRateColor(): string {
    return Functions.getOpinionRateColor(this.opinionCreation.rate);
  }

  sendOpinion() {
    if (this.opinionCreation.clientId === null) {
      this.toastService.add({severity: 'error', summary: 'Sending opinion failed', detail: 'Client not specified.'})
      return;
    }
    if (this.opinionCreation.workerId === null) {
      this.toastService.add({severity: 'error', summary: 'Sending opinion failed', detail: 'Worker not specified.'})
      return;
    }
    if (this.opinionCreation.visitId === null) {
      this.toastService.add({severity: 'error', summary: 'Sending opinion failed', detail: 'Visit not specified.'})
      return;
    }
    if (this.opinionCreation.description === null || this.opinionCreation.description.length === 0) {
      this.toastService.add({severity: 'error', summary: 'Sending opinion failed', detail: 'Description is required.'})
      return;
    }
    if (this.opinionCreation.rate === null) {
      this.toastService.add({severity: 'error', summary: 'Sending opinion failed', detail: 'Rate is required.'})
      return;
    }
    if (this.opinionCreation.rate < 0 || this.opinionCreation.rate > 5) {
      this.toastService.add({severity: 'error', summary: 'Sending opinion failed', detail: 'Rate has to be in range from 0 to 5.'})
      return;
    }

    this.opinionService.addOpinion(this.opinionCreation).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Opinion has been sent.'});
        this.addedOpinion.emit(res);
        this.closeDialog.emit(true);
      },
      err => {
        this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
        console.log(err);
      }
    );
  }

  cancel() {
    this.closeDialog.emit(true);
  }

}
