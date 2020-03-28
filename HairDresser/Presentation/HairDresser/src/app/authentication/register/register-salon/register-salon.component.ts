import { Component, OnInit, Output, EventEmitter} from '@angular/core';
import { RegisterSalonCredentials } from '../../models/RegisterSalonCredentials';
import { SelectItem, MessageService, MenuItem } from 'primeng/primeng';
import { AuthService } from '../../services/auth.service';
import { ValidationMessage } from 'src/app/shared/models/ValidationMessage';
import { SalonData } from 'src/app/shared/models/SalonData';
import * as $ from 'jquery';

@Component({
  selector: 'app-register-salon',
  templateUrl: './register-salon.component.html',
  styleUrls: ['./register-salon.component.css']
})
export class RegisterSalonComponent implements OnInit {

  @Output() closeDialog = new EventEmitter<boolean>();
  protected userDataBookmarkId = 'userDataBookmark';
  protected salonDataBookmarkId = 'salonDataBookmark';
  protected scheduleBookmarkId = 'scheduleBookmark';
  protected imageBookmarkId = 'imageBookmark';

  registerSteps: MenuItem[] = [
    {label: 'User data'},
    {label: 'Salon data'},
    {label: 'Schedule'},
    {label: 'Image'},
  ];
  registerStepsIndex = 0;

  salonTypes: SelectItem[] = [
    {label: 'Unisex', value: 0},
    {label: 'Female', value: 1},
    {label: 'Male', value: 2}
  ];

  protected registerCredentials: RegisterSalonCredentials = {
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
    },
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
      role: 'salon'
    },
    imageData: ''
  };

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

  protected validationMessage: ValidationMessage = null;

  constructor(
    private authService: AuthService,
    private toastService: MessageService) { }

  ngOnInit() {
    const self = this;
    document.getElementsByClassName('ui-scrollpanel-content')[1]
      .addEventListener('scroll', () => {
        self.onScrollContentPanel();
     });
  }

  private updateRegisterCredentials() {
    this.registerCredentials.name = this.salonData.name;
    this.registerCredentials.additionalInfo = this.salonData.additionalInfo;
    this.registerCredentials.type = this.salonData.type;
    this.registerCredentials.address = this.salonData.address;
    this.registerCredentials.location = this.salonData.location;
  }

  dataValid(): ValidationMessage {
    this.updateRegisterCredentials();
    let toReturn = new ValidationMessage(true, 'Data valid');
    if (this.registerCredentials.userData.userName === '') {
      toReturn.update(false, "User name cannot by empty.");
    } else if (this.registerCredentials.userData.password === '') {
      toReturn.update(false, "Password cannot by empty.");
    } else if (this.registerCredentials.userData.email === '') {
      toReturn.update(false, "Email cannot by empty.");
    } else if (this.registerCredentials.userData.phoneNumber === '') {
      toReturn.update(false, "Phone number cannot by empty.");
    } else if (this.registerCredentials.userData.password !== this.registerCredentials.userData.confirmPassword) {
      toReturn.update(false, "Confirm password don't match");
    } else if (!this.registerCredentials.userData.email.includes('@')) {
      toReturn.update(false, "E-mail don't include @");
    } else if (this.registerCredentials.name === '') {
      toReturn.update(false, "Salon name cannot by empty.");
    } else if (this.registerCredentials.address.city === '') {
      toReturn.update(false, "City cannot by empty.");
    } else if (this.registerCredentials.address.street === '') {
      toReturn.update(false, "Street cannot by empty.");
    } else if (this.registerCredentials.address.zipCode === '') {
      toReturn.update(false, "Zip code cannot by empty.");
    }
    return toReturn;
  }

  onImageUpload(imageSource: any) {
    this.registerCredentials.imageData = imageSource;
  }

  submit() {
    this.validationMessage = this.dataValid();
    if (this.validationMessage.isValid) {
      this.authService.registerSalon(this.registerCredentials).subscribe(
        res => {
          this.closeDialog.emit(this.validationMessage.isValid);
          this.toastService.add({severity: 'success', summary: 'Register succeeded', detail: 'Salon account created'});
        },
        err => this.toastService.add({severity: 'error', summary: 'Register failed', detail: err.error})
      );
    }
  }

  private scrollToBookmark(bookmarkId: string) {
    setTimeout(() => {
      const element = document.getElementById(bookmarkId);
      element.focus();
      element.scrollIntoView({
        behavior: 'smooth'
      });

    }, 200);
  }

  private getBookmarkScrollTopOffset(bookmarkId: string): number {
    return $('#' + bookmarkId).offset().top;
  }

  private onScrollContentPanel() {
    const switchOffset = 170;
    if (this.getBookmarkScrollTopOffset(this.imageBookmarkId) < switchOffset) {
      this.registerStepsIndex = 3;
    } else if (this.getBookmarkScrollTopOffset(this.scheduleBookmarkId) < switchOffset) {
      this.registerStepsIndex = 2;
    } else if (this.getBookmarkScrollTopOffset(this.salonDataBookmarkId) < switchOffset) {
      this.registerStepsIndex = 1;
    } else {
      this.registerStepsIndex = 0;
    }
  }

  toggleSteps(index) {
    switch (index) {
      case 0: this.scrollToBookmark(this.userDataBookmarkId); break;
      case 1: this.scrollToBookmark(this.salonDataBookmarkId); break;
      case 2: this.scrollToBookmark(this.scheduleBookmarkId); break;
      case 3: this.scrollToBookmark(this.imageBookmarkId); break;
    }
  }

  goToLoginPage() {

  }

}
