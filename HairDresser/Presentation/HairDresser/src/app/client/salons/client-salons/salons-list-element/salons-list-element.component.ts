import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import * as jwt_decode from 'jwt-decode';
import { ClientService } from 'src/app/shared/services/client.service';
import { MessageService, ConfirmationService } from 'primeng/primeng';
import { Constants } from 'src/app/shared/constants/Constants';
import { Visit } from 'src/app/shared/models/Visit';

@Component({
  selector: 'app-client-salons-list-element',
  templateUrl: './salons-list-element.component.html',
  styleUrls: ['./salons-list-element.component.css']
})
export class ClientSalonsListElementComponent implements OnInit {

  @Input() salon: Salon;
  @Input() favSalons: Salon[];
  @Input() isSelected = false;
  @Input() onlySelectMode = false;
  @Output() removedSalon = new EventEmitter<Salon>();
  @Output() addedVisit = new EventEmitter<Visit>();
  userId: string;
  displayAppointmentDialog = false;

  constructor(
    private clientService: ClientService,
    private toastService: MessageService,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit() {
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
  }

  removeFromFavourites() {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to remove ' + this.salon.name + ' from favourites list?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        blockScroll: false,
        accept: () => {
          this.clientService.removeFavouriteSalon(this.userId, this.salon.id).subscribe(
            res => {
              this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Salon removed from favourites list.'});
              this.removedSalon.emit(this.salon);
            },
            err => {this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});}
          );
        }
    });
  }

  showAppointmentDialog() {
    this.displayAppointmentDialog = true;
  }

  onDialogClose(close: boolean) {
    this.displayAppointmentDialog = !close;
  }

  onAddedVisit(visit: Visit) {
    this.addedVisit.emit(visit);
  }

}
