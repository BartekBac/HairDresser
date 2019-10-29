import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { SalonService } from './services/salon.service';
import { SalonResolver } from './resolvers/salon.resolver';
import { PanelModule, InputTextModule, ButtonModule, InputMaskModule, MessageModule,
         DialogModule, CheckboxModule, PasswordModule, SelectButtonModule, FileUploadModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule, NgbTimepickerModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { FormSalonDataComponent } from './components/form-salon-data/form-salon-data.component';
import { FormUserDataComponent } from './components/form-user-data/form-user-data.component';
import { FormScheduleComponent } from './components/form-schedule/form-schedule.component';
import { FormUploadImageComponent } from './components/form-upload-image/form-upload-image.component';
import { SalonTypePipe } from './pipes/salon-type.pipe';


@NgModule({
  declarations: [FormSalonDataComponent, FormUserDataComponent, FormScheduleComponent, FormUploadImageComponent, SalonTypePipe],
  imports: [
    CommonModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    InputMaskModule,
    MessageModule,
    DialogModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    NgbTimepickerModule,
    NgbTooltipModule,
    CheckboxModule,
    PasswordModule,
    SelectButtonModule,
    FileUploadModule
  ],
  exports: [
    CommonModule,
    FormSalonDataComponent,
    FormUserDataComponent,
    FormScheduleComponent,
    FormUploadImageComponent,
    SalonTypePipe
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        SalonService,
        SalonResolver
      ]
    };
  }
}
