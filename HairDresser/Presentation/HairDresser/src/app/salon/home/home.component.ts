import { Component, OnInit } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import { SalonService } from 'src/app/shared/services/salon.service';
import { ActivatedRoute } from '@angular/router';
import { UploadImage } from 'src/app/shared/models/UploadImage';
import { Constants } from 'src/app/shared/constants/Constants';
import * as jwt_decode from 'jwt-decode';
import { MessageService } from 'primeng/primeng';
import { AuthService } from 'src/app/authentication/services/auth.service';
import { SalonData } from 'src/app/shared/models/SalonData';
import { UserData } from 'src/app/shared/models/UserData';
import { Schedule } from 'src/app/shared/models/Schedule';
import { UpdateUserData } from 'src/app/shared/models/UpdateUserData';
import { UpdateSchedule } from 'src/app/shared/models/UpdateSchedule';
import { Functions } from 'src/app/shared/constants/Functions';
import { Worker } from 'src/app/shared/models/Worker';
import { Service } from 'src/app/shared/models/Service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  salon: Salon = null;
  userId: string = null;

  displayEditImage = false;
  displayEditSalonData = false;
  displayEditUserData = false;
  displayEditSchedule = false;
  displayAddWorker = false;
  displayAddService = false;

  protected uploadedImageSource = '';
  protected salonData: SalonData = {
    name: '',
    additionalInfo: '',
    type: 0,
    address: {
      city: '',
      zipCode: '',
      street: '',
      houseNumber: '',
    },
    location: {
      latitude: 0,
      longitude: 0
    }
  };
  protected userData: UserData = {
    userName: '',
    password: '',
    confirmPassword: '',
    email: '',
    phoneNumber: '',
    role: 'salon'
  };
  protected schedule: Schedule = null;

  constructor(
    private salonService: SalonService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private toastService: MessageService) { }

  ngOnInit() {
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.authService.showNavbar();
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.salon = this.route.snapshot.data.salon;
    console.log(this.salon);
    this.loadChildDataModels();

    if (this.salon.location.latitude === 0 && this.salon.location.longitude === 0) {
      this.toastService.add({severity: 'warn', sticky: true, summary: 'No salon location defined',
        detail: 'To set the salon location, open the "Address" tab, click the edit icon and select "Edit location".'});
    }
  }

  private loadChildDataModels() {
    this.salonData = Functions.copyObject(this.salon);
    this.uploadedImageSource = this.salon.imageSource;
    this.userData = Functions.copyObject(this.salon.admin);
    this.schedule = Functions.copyObject(this.salon.schedule);
  }

  private updateSalonModel() {
    this.salon.additionalInfo = this.salonData.additionalInfo;
    this.salon.name = this.salonData.name;
    this.salon.type = this.salonData.type;
    this.salon.address = Functions.copyObject(this.salonData.address);
    this.salon.location = Functions.copyObject(this.salonData.location);
    // this.salon = Functions.copyObject(this.salonData);
    this.salon.imageSource = this.uploadedImageSource;
    this.salon.admin = Functions.copyObject(this.userData);
    this.salon.schedule = Functions.copyObject(this.schedule);
  }

  onImageUpload(imageSource: any) {
    this.uploadedImageSource = imageSource;
  }

 saveImage() {
    const uploadImage: UploadImage = {
      imageSource: this.uploadedImageSource
    };
    this.salonService.uploadImage(this.userId, uploadImage).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Image saved to database', detail: ''});
        this.updateSalonModel();
      },
      err => this.toastService.add({severity: 'error', summary: 'Cannot save image to database', detail: err.error})
    );
  }

  saveSalonData() {
    this.salonService.updateSalonData(this.userId, this.salonData).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Changes saved to database', detail: ''});
        this.updateSalonModel();
      },
      err => this.toastService.add({severity: 'error', summary: 'Cannot save changes into database', detail: err.error})
    );
  }

  saveUserData() {
    const updateUserData: UpdateUserData = {
      email: this.userData.email,
      phoneNumber: this.userData.phoneNumber
    };
    this.salonService.updateUserData(this.userId, updateUserData).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Changes saved to database', detail: ''});
        this.updateSalonModel();
      },
      err => this.toastService.add({severity: 'error', summary: 'Cannot save changes into database', detail: err.error})
    );
  }

  saveSchedule() {
    const updateSchedule: UpdateSchedule = {
      schedule: this.schedule
    };
    this.salonService.updateSchedule(this.userId, updateSchedule).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Changes saved to database', detail: ''});
        this.updateSalonModel();
      },
      err => this.toastService.add({severity: 'error', summary: 'Cannot save changes into database', detail: err.error})
    );
  }

  showAddWorkerDialog() {
    this.displayAddWorker = true;
  }

  onAddedWorker(addedWorker: Worker) {
    this.salon.workers.push(addedWorker);
    this.salonService.getSalon(this.userId).subscribe(
      res => this.salon = res
    );
  }

  showAddServiceDialog() {
    this.displayAddService = true;
  }

  onAddedService(addedService: Service) {
    this.salon.services.push(addedService);
    this.salonService.getSalon(this.userId).subscribe(
      res => this.salon = res
    );
  }

  onDeleteService(deletedService: Service) {
    this.salon.services = this.salon.services.filter(s => s.id !== deletedService.id);
    this.salon.workers.forEach(
      w => {
        w.services = w.services.filter(s => s.id !== deletedService.id);
    });
  }

  onDeleteWorker(deletedWorker: Worker) {
    this.salon.workers = this.salon.workers.filter(s => s.id !== deletedWorker.id);
    this.salonService.getSalon(this.userId).subscribe(
      res => this.salon = res
    );
  }

}
