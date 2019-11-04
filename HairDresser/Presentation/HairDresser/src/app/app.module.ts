import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProgressBarModule, MenubarModule, ButtonModule, ScrollPanelModule, ConfirmDialogModule } from 'primeng/primeng';
import { ToastModule } from 'primeng/toast';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    CoreModule.forRoot(),
    AppRoutingModule,
    ProgressBarModule,
    ToastModule,
    MenubarModule,
    ButtonModule,
    ScrollPanelModule,
    ConfirmDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
