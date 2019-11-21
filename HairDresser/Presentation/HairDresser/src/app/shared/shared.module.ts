import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { SalonService } from './services/salon.service';
import { SalonResolver } from './resolvers/salon.resolver';
import { PanelModule, InputTextModule, ButtonModule, InputMaskModule, MessageModule,
         DialogModule, CheckboxModule, PasswordModule, SelectButtonModule, FileUploadModule, ProgressSpinnerModule, ScrollPanelModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule, NgbTimepickerModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { FormSalonDataComponent } from './components/form-salon-data/form-salon-data.component';
import { FormUserDataComponent } from './components/form-user-data/form-user-data.component';
import { FormScheduleComponent } from './components/form-schedule/form-schedule.component';
import { FormUploadImageComponent } from './components/form-upload-image/form-upload-image.component';
import { SalonTypePipe } from './pipes/salon-type.pipe';
import { EditableDivComponent } from './components/editable-div/editable-div.component';
import { ClientService } from './services/client.service';
import { ClientResolver } from './resolvers/client.resolver';
import { ViewScheduleComponent } from './components/view-schedule/view-schedule.component';
import { ViewServicesTableComponent } from './components/view-services-table/view-services-table.component';
import { TableModule } from 'primeng/table';
import { OverlayDivComponent } from './components/overlay-div/overlay-div.component';
import { ClientAddSalonResolver } from './resolvers/client-add-salon.resolver';
import { VisitStatusPipe } from './pipes/visit-status.pipe';
import { VisitStatusIconPipe } from './pipes/visit-status-icon.pipe';
import { SelectCalendarComponent } from './components/select-calendar/select-calendar.component';
import { FullCalendarModule } from 'primeng/fullcalendar';
import { FormVisitChangeTermComponent } from './components/form-visit-change-term/form-visit-change-term.component';

@NgModule({
  declarations: [
    FormSalonDataComponent,
    FormUserDataComponent,
    FormScheduleComponent,
    FormUploadImageComponent,
    SalonTypePipe,
    EditableDivComponent,
    ViewScheduleComponent,
    ViewServicesTableComponent,
    OverlayDivComponent,
    VisitStatusPipe,
    VisitStatusIconPipe,
    SelectCalendarComponent,
    FormVisitChangeTermComponent
  ],
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
    FileUploadModule,
    TableModule,
    FullCalendarModule,
    ProgressSpinnerModule,
    ScrollPanelModule
  ],
  exports: [
    CommonModule,
    FormSalonDataComponent,
    FormUserDataComponent,
    FormScheduleComponent,
    FormUploadImageComponent,
    SalonTypePipe,
    EditableDivComponent,
    ViewScheduleComponent,
    ViewServicesTableComponent,
    OverlayDivComponent,
    VisitStatusPipe,
    VisitStatusIconPipe,
    SelectCalendarComponent,
    FormVisitChangeTermComponent
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        SalonService,
        SalonResolver,
        ClientService,
        ClientResolver,
        ClientAddSalonResolver
      ]
    };
  }
}
