import { Component, OnInit } from '@angular/core';
import { SalonData } from 'src/app/shared/models/SalonData';
import { SalonService } from 'src/app/shared/services/salon.service';
import { ActivatedRoute } from '@angular/router';
import { UploadImage } from 'src/app/shared/models/UploadImage';
import { Constants } from 'src/app/shared/constants/Constants';
import * as jwt_decode from 'jwt-decode';
import { MessageService } from 'primeng/primeng';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  salon: SalonData = null;
  userId: string = null;
  imageHeader = 'data:image/png;base64,';

  constructor(
    private salonService: SalonService,
    private route: ActivatedRoute,
    private toastService: MessageService) { }

  ngOnInit() {
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.salon = this.route.snapshot.data.salon;
    this.salon.imageSource = this.imageHeader + this.salon.imageSource;
    console.log(this.salon);
  }

  onImageUpload(imageSource: any) {
    this.salon.imageSource = imageSource;
    console.log(imageSource);
  }

  uploadImage() {
    const uploadImage: UploadImage = {
      entityId: this.userId,
      imageSource: this.salon.imageSource,
      entityType: null
    };
    console.log(uploadImage.imageSource);
    this.salonService.uploadSalonImage(uploadImage).subscribe(
      res => this.toastService.add({severity: 'success', summary: 'Image saved to database', detail: ''}),
      err => console.log(err)//this.toastService.add({severity: 'error', summary: 'Cannot save image to database', detail: err.error})
    );
  }

}
