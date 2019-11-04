import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { WorkerCreation } from '../../models/WorkerCreation';
import { ValidationMessage } from 'src/app/shared/models/ValidationMessage';
import { Schedule } from 'src/app/shared/models/Schedule';
import { Functions } from 'src/app/shared/constants/Functions';
import { WorkerService } from 'src/app/shared/services/worker.service';
import { MessageService } from 'primeng/primeng';
import { Worker } from 'src/app/shared/models/Worker';

@Component({
  selector: 'app-add-worker',
  templateUrl: './add-worker.component.html',
  styleUrls: ['./add-worker.component.css']
})
export class AddWorkerComponent implements OnInit {

  @Input() salonId: string;
  @Input() salonSchedule: Schedule;
  @Input() editMode = false;
  @Input() editWorker: Worker;
  @Output() addedWorker = new EventEmitter<Worker>();

  worker: WorkerCreation = {
    firstName: '',
    lastName: '',
    salonId: '',
    schedule: {
      monday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: true,
      },
      tuesday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: true,
      },
      wednesday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: true,
      },
      thursday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: true,
      },
      friday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: true,
      },
      saturday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: false,
      },
      sunday: {
        begin: { hour: 8, minute: 0, },
        end: { hour: 16, minute: 0, },
        isActive: false,
      }
    },
    userData: {
      userName: '',
      password: '',
      confirmPassword: '',
      email: '',
      phoneNumber: '',
      role: 'worker'
    },
    imageData: ''
  };

  protected validationMessage: ValidationMessage = null;

  constructor(
    private workerService: WorkerService,
    private toastService: MessageService) { }

  ngOnInit() {
    if (this.editMode) {
      this.worker.firstName = this.editWorker.firstName;
      this.worker.lastName = this.editWorker.lastName;
      this.worker.imageData = this.editWorker.imageSource;
      this.worker.userData.email = this.editWorker.userEmail;
      this.worker.userData.phoneNumber = this.editWorker.userPhoneNumber;
      this.worker.userData.userName = this.editWorker.userName;
      this.worker.schedule = Functions.copyObject(this.editWorker.schedule);
    } else {
      this.worker.salonId = this.salonId;
      this.worker.schedule = Functions.copyObject(this.salonSchedule);
    }
  }

  dataValid(): ValidationMessage {
    let toReturn = new ValidationMessage(true, 'Data valid');
    if (this.worker.userData.userName === '') {
      toReturn.update(false, "User name cannot by empty.");
    } else if (!this.editMode && this.worker.userData.password === '') {
      toReturn.update(false, "Password cannot by empty.");
    } else if (this.worker.userData.email === '') {
      toReturn.update(false, "Email cannot by empty.");
    } else if (this.worker.userData.phoneNumber === '') {
      toReturn.update(false, "Phone number cannot by empty.");
    } else if (!this.editMode && this.worker.userData.password !== this.worker.userData.confirmPassword) {
      toReturn.update(false, "Confirm password don't match");
    } else if (!this.worker.userData.email.includes('@')) {
      toReturn.update(false, "E-mail don't include @");
    } else if (this.worker.firstName === '') {
      toReturn.update(false, "Worker first name cannot by empty.");
    } else if (this.worker.lastName === '') {
      toReturn.update(false, "Worker last name cannot by empty.");
    }
    return toReturn;
  }

  onImageUpload(imageSource: any) {
    this.worker.imageData = imageSource;
  }

  private copyValuesToEditWorker() {
    this.editWorker.firstName = this.worker.firstName;
    this.editWorker.lastName = this.worker.lastName;
    this.editWorker.imageSource = this.worker.imageData;
    this.editWorker.userEmail = this.worker.userData.email;
    this.editWorker.userPhoneNumber = this.worker.userData.phoneNumber;
    this.editWorker.userName = this.worker.userData.userName;
    this.editWorker.schedule = Functions.copyObject(this.worker.schedule);
  }

  submit() {
    this.validationMessage = this.dataValid();
    if (this.validationMessage.isValid) {
      if (!this.editMode) {
        this.editWorker = new Worker ();
        this.copyValuesToEditWorker();
        this.workerService.addWorker(this.worker).subscribe(
          res => {
            this.toastService.add({severity: 'success', summary: 'Register succeeded', detail: 'Worker account created'});
            this.addedWorker.emit(this.editWorker);
          },
          err => this.toastService.add({severity: 'error', summary: 'Register failed', detail: err.error})
        );
      } else {
        this.copyValuesToEditWorker();
        this.workerService.editWorker(this.editWorker).subscribe(
          res => {
            this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Worker data changed'});
          },
          err => this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error})
        );
      }
    }
  }
}
