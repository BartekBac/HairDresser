import { Component, OnInit } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import { SalonService } from 'src/app/shared/services/salon.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  salon: Salon = null;

  constructor(
    private salonService: SalonService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    /*this.salonService.getSalon("3ad264a3-68ba-4220-aaff-729694d79a97").subscribe(
      res => this.salon = res
    );*/
    this.salon = this.route.snapshot.data.salon;
  }

}
