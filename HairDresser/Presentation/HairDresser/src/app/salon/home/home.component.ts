import { Component, OnInit } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import { SalonService } from 'src/app/shared/services/salon.service';
import { ActivatedRoute } from '@angular/router';
import { UploadImage } from 'src/app/shared/models/UploadImage';
import { Constants } from 'src/app/shared/constants/Constants';
import * as jwt_decode from 'jwt-decode';
import { MessageService } from 'primeng/primeng';
import { AuthService } from 'src/app/authentication/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  salon: Salon = null;
  userId: string = null;

  editImageIconVisible = false;
  displayEditImage = false;

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
  }

  toggleEditImageIcon(show: boolean) {
    this.editImageIconVisible = show;
  }

  onImageUpload(imageSource: any) {
    this.salon.imageSource = imageSource;
    console.log(imageSource);
  }

  showEditImageDialog() {
    this.displayEditImage = true;
  }

 saveImage() {
    const uploadImage: UploadImage = {
      entityId: this.userId,
      imageSource: this.salon.imageSource
    };
    console.log(uploadImage.imageSource);
    this.salonService.uploadSalonImage(uploadImage).subscribe(
      res => this.toastService.add({severity: 'success', summary: 'Image saved to database', detail: ''}),
      err => this.toastService.add({severity: 'error', summary: 'Cannot save image to database', detail: err.error})
    );
  }

}
