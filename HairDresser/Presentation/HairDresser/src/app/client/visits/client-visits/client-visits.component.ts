import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { SelectItem } from 'primeng/primeng';
import { VisitStatus } from 'src/app/shared/enums/VisitStatus';

@Component({
  selector: 'app-client-visits',
  templateUrl: './client-visits.component.html',
  styleUrls: ['./client-visits.component.css']
})
export class ClientVisitsComponent implements OnInit {

  @Input() visits: Visit[] = [];
  @Input() userId: string = null;
  displayingVisits: Visit[] = [];

  sortOptions: SelectItem[] = [
    {label: 'Status', value: 'status'},
    {label: 'Term ascending', value: 'term'},
    {label: 'Term descending', value: '!term'}
  ];

  filterOptions: SelectItem[] = [
    {label: 'Accepted', icon: 'pi pi-check-circle', value: VisitStatus.Accepted},
    {label: 'Change requested', icon: 'pi pi-question-circle', value: VisitStatus.ChangeRequested},
    {label: 'Pending', icon: 'pi pi-clock', value: VisitStatus.Pending},
    {label: 'Rejected', icon: 'pi pi-times-circle', value: VisitStatus.Rejected}
  ];
  selectedFilters: VisitStatus[] = [VisitStatus.Accepted, VisitStatus.ChangeRequested, VisitStatus.Pending, VisitStatus.Rejected];
  showHistoryFlag = false;

  sortKey: string;
  sortField: string;
  sortOrder: number;

  constructor() { }

  ngOnInit() {
    this.showHistory(false);
  }

  onSortChange(event) {
    const value = event.value;
    if (value.indexOf('!') === 0) {
        this.sortOrder = -1;
        this.sortField = value.substring(1, value.length);
    } else {
        this.sortOrder = 1;
        this.sortField = value;
    }
  }

  filterVisits(filters: VisitStatus[]) {
    this.displayingVisits = this.visits.filter(v => filters.includes(v.status));
  }

  showHistory(show: boolean) {
    this.filterVisits(this.selectedFilters);
    console.log(this.selectedFilters);
    console.log(this.displayingVisits);
    if (!show) {
      const now = new Date();
      console.log(now);
      this.displayingVisits = this.displayingVisits.filter(v => new Date(v.term) > now);
    }
  }

}
