import { Component } from '@angular/core';
import { NavigationStart, NavigationEnd, Event, Router, NavigationCancel, NavigationError,
   RoutesRecognized, GuardsCheckStart, GuardsCheckEnd, ResolveStart, ResolveEnd} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HairDresser';
  showProgressBar = false;
  progressBarValue = 0;

  constructor(private router: Router) {
    this.router.events.subscribe((event: Event) => {
      this.loadingBarInterceptor(event);
    });
  }

  private loadingBarInterceptor(event: Event) {
    if (event instanceof NavigationStart) {
      this.showProgressBar = true;
      this.progressBarValue = 0;
    } else if (event instanceof RoutesRecognized) {
      this.progressBarValue = 20;
    } else if (event instanceof GuardsCheckStart) {
      this.progressBarValue = 40;
    } else if (event instanceof GuardsCheckEnd) {
      this.progressBarValue = 60;
    } else if (event instanceof ResolveStart) {
      this.progressBarValue = 90;
    } else if (event instanceof ResolveEnd) {
      this.progressBarValue = 95;
    } else if (event instanceof NavigationEnd ||
               event instanceof NavigationCancel ||
               event instanceof NavigationError) {
      this.progressBarValue = 100;
      setTimeout( () => this.showProgressBar = false, 700 );
    }
  }
}
