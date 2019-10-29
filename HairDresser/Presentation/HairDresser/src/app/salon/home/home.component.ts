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
import { Address } from 'src/app/shared/models/Address';

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
  }

  private loadChildDataModels() {
    this.salonData.name = this.salon.name;
    this.salonData.additionalInfo = this.salon.additionalInfo;
    this.salonData.address.city = this.salon.address.city;
    this.salonData.address.street = this.salon.address.street;
    this.salonData.address.houseNumber = this.salon.address.houseNumber;
    this.salonData.address.zipCode = this.salon.address.zipCode;
    this.salonData.type = this.salon.type;
    this.uploadedImageSource = this.salon.imageSource;
    this.userData.userName = this.salon.admin.userName;
    this.userData.email = this.salon.admin.email;
    this.userData.phoneNumber = this.salon.admin.phoneNumber;
    this.schedule = this.salon.schedule;
  }

  private updateSalonModel() {
    this.salon.name = this.salonData.name;
    this.salon.additionalInfo = this.salonData.additionalInfo;
    this.salon.address.city = this.salonData.address.city;
    this.salon.address.street = this.salonData.address.street;
    this.salon.address.houseNumber = this.salonData.address.houseNumber;
    this.salon.address.zipCode = this.salonData.address.zipCode;
    this.salon.type = this.salonData.type;
    this.salon.imageSource = this.uploadedImageSource;
    this.salon.admin.userName = this.userData.userName;
    this.salon.admin.email = this.userData.email;
    this.salon.admin.phoneNumber = this.userData.phoneNumber;
    this.salon.schedule = this.schedule;
  }

  onImageUpload(imageSource: any) {
    this.uploadedImageSource = imageSource;
  }

 saveImage() {
    const uploadImage: UploadImage = {
      imageSource: this.uploadedImageSource
    };
    this.salonService.uploadSalonImage(this.userId, uploadImage).subscribe(
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
    console.log(updateSchedule);
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

}
